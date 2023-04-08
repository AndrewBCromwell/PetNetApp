using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IPostAccessor
    {
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Selects all posts that an admin or moderator could see
        /// </summary>
        /// <returns></returns>
        List<PostVM> SelectAllPosts();
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Selects all actives post
        /// </summary>
        /// <returns></returns>
        List<PostVM> SelectActivePosts();
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Inserts a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        int InsertPost(Post post);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Updates a post
        /// </summary>
        /// <param name="post"></param>
        /// <param name="newPost"></param>
        /// <returns></returns>
        int UpdatePost(Post post, Post newPost);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Selects a post by post id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        PostVM SelectPostByPostId(int postId);

        int SelectUserPostReportedByPostIdandUserId(int postId, int userId);
    }
}
