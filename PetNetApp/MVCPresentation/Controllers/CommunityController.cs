using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using DataObjects;

namespace MVCPresentation.Controllers
{
    //[Authorize]
    public class CommunityController : Controller
    {
        private MasterManager masterManager = MasterManager.GetMasterManager();
        private List<PostVM> posts;
        // GET: Community
        public ActionResult Index()
        {
            try
            {
                if (masterManager.User.Roles.Contains("Admin") || masterManager.User.Roles.Contains("Moderator"))
                {
                    posts = masterManager.PostManager.RetrieveAllPosts();
                    foreach (var post in posts)
                    {
                        post.ReplyCount = masterManager.ReplyManager.RetrieveCountRepliesByPostId(post.PostId);
                    }
                }
                else
                {
                    posts = masterManager.PostManager.RetrieveActivePosts();
                    foreach (var post in posts)
                    {
                        post.ReplyCount = masterManager.ReplyManager.RetrieveCountActiveRepliesByPostId(post.PostId);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + "\n" + ex.InnerException;
                return View("Error");
            }
            ViewBag.User = masterManager.User;
            return View(posts);
        }

        public ActionResult ShowReplies(int? id)
        {
            return View();
        }

        // GET: Community/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Community/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            post.PostAuthor = masterManager.User.UsersId;
            post.PostDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                try
                {
                    masterManager.PostManager.AddPost(post);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message + "\n\n" + ex.InnerException.Message;
                    return View("Error");
                }
            }
            else
            {
                return View("Index");
            }
        }

        // GET: Community/Edit/5
        public ActionResult Edit(int? id)
        {
            Post postToEdit = null;
            if(id != null)
            {
                try
                {
                    postToEdit = masterManager.PostManager.RetrievePostByPostId(id.Value);

                    if(postToEdit.PostAuthor != masterManager.User.UsersId)
                    {
                        ViewBag.Message = "Invaild Request";
                        return View("Error");
                    }


                    Session["postToEdit"] = postToEdit;

                    if(postToEdit == null)
                    {
                        throw new Exception("Post not found");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View("Error");
                }
            } else
            {
                ViewBag.Message = "Not a valid post";
                return View("Error");
            }
            return View(postToEdit);
        }

        // POST: Community/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post newPost)
        {
            if (((Post)Session["postToEdit"]).PostAuthor != masterManager.User.UsersId)
            {
                ViewBag.Message = "Invaild Request";
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    newPost.PostDate = DateTime.Now;
                    masterManager.PostManager.EditPost((Post)Session["postToEdit"], newPost);
                    Session["postToEdit"] = null;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message + ex.InnerException;
                    return View("Error");
                }
            } 
            else
            {
                return View(newPost);
            }
        }

        // GET: Community/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Community/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}