using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using DataObjects;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Diagnostics;

namespace MVCPresentation.Controllers
{
    //[Authorize]
    public class CommunityController : Controller
    {
        private MasterManager masterManager = MasterManager.GetMasterManager();
        private List<PostVM> posts;
        private PostVM postVM;
        // GET: Community
        public ActionResult Index()
        {
            try
            {
                if (masterManager.User.Roles.Contains("Admin") || masterManager.User.Roles.Contains("Moderator"))
                {
                    posts = masterManager.PostManager.RetrieveAllPosts();
                }
                else
                {
                    posts = masterManager.PostManager.RetrieveActivePosts();
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
            if(id != null)
            {
                try
                {
                    postVM = masterManager.PostManager.RetrievePostByPostId(id.Value);

                    if(postVM.PostVisibility)
                    {
                        //if (User.IsInRole("Admin") || User.IsInRole("Moderator"))

                        if (masterManager.User.Roles.Contains("Admin") || masterManager.User.Roles.Contains("Moderator"))
                        {
                            postVM.Replies = masterManager.ReplyManager.RetrieveAllRepliesByPostId(postVM.PostId);
                        }
                        else
                        {
                            postVM.Replies = masterManager.ReplyManager.RetrieveActiveRepliesByPostId(postVM.PostId);
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Invaild Request";
                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message + "\n" + ex.InnerException;
                    return View("Error");
                }

                ViewBag.UserId = masterManager.User.UsersId;
                ViewBag.HasAdminRole = masterManager.User.Roles.Contains("Admin");
                ViewBag.HasModeratorRole = masterManager.User.Roles.Contains("Moderator");

                //ViewBag.HasAdminRole = User.IsInRole("Admin");
                //ViewBag.HasModeratorRole = User.IsInRole("Moderator");
                Session["PostId"] = id;
                return View(postVM);
            }
            else
            {
                ViewBag.Message = "Please select a post";
                return View("Error");
            }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReply(Reply reply)
        {
            reply.ReplyAuthor = masterManager.User.UsersId;
            reply.ReplyDate = DateTime.Now;
            reply.PostId = (int)Session["PostId"];
            ViewBag.UserId = masterManager.User.UsersId;
            ViewBag.HasAdminRole = User.IsInRole("Admin");
            ViewBag.HasModeratorRole = User.IsInRole("Moderator");

            try
            {
                postVM = masterManager.PostManager.RetrievePostByPostId(reply.PostId);

                if (postVM.PostVisibility)
                {
                    //if (User.IsInRole("Admin") || User.IsInRole("Moderator"))

                    if (masterManager.User.Roles.Contains("Admin") || masterManager.User.Roles.Contains("Moderator"))
                    {
                        postVM.Replies = masterManager.ReplyManager.RetrieveAllRepliesByPostId(postVM.PostId);
                    }
                    else
                    {
                        postVM.Replies = masterManager.ReplyManager.RetrieveActiveRepliesByPostId(postVM.PostId);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message + "\n\n" + ex.InnerException.Message;
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    masterManager.ReplyManager.AddReply(reply);
                    Session["PostId"] = null;
                    return RedirectToAction("ShowReplies", new { id = reply.PostId });
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message + "\n\n" + ex.InnerException.Message;
                    return View("Error");
                }
            }
            else
            {
                return View("ShowReplies", postVM);
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
            } 
            else
            {
                ViewBag.Message = "Not a valid post";
                return View("Error");
            }
            return View(postToEdit);
        }

        // POST: Community/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post newPost)
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

        // GET: Community/EditReply/5
        public ActionResult EditReply(int? id)
        {
            Reply replyToEdit = null;
            if (id != null)
            {
                try
                {
                    replyToEdit = masterManager.ReplyManager.RetrieveReplyByReplyId(id.Value);

                    if (replyToEdit.ReplyAuthor != masterManager.User.UsersId)
                    {
                        ViewBag.Message = "Invaild Request";
                        return View("Error");
                    }


                    Session["replyToEdit"] = replyToEdit;

                    if (replyToEdit == null)
                    {
                        throw new Exception("Reply not found");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View("Error");
                }
            }
            else
            {
                ViewBag.Message = "Not a valid reply";
                return View("Error");
            }
            return View(replyToEdit);
        }

        // POST: Community/EditReply/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditReply(Reply newReply)
        {
            if (((Reply)Session["replyToEdit"]).ReplyAuthor != masterManager.User.UsersId)
            {
                ViewBag.Message = "Invaild Request";
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    newReply.ReplyDate = DateTime.Now;
                    masterManager.ReplyManager.EditReply((Reply)Session["replyToEdit"], newReply);

                    int postId = ((Reply)Session["replyToEdit"]).PostId;
                    Session["replyToEdit"] = null;
                    return RedirectToAction("ShowReplies", new { id = postId });
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message + ex.InnerException;
                    return View("Error");
                }
            }
            else
            {
                return View(newReply);
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