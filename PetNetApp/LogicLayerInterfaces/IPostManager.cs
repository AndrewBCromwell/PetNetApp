using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IPostManager
    {
        List<PostVM> RetrieveAllPosts();
        List<PostVM> RetrieveActivePosts();
        int AddPost(Post post);
        bool EditPost(Post post, Post newPost);
        PostVM RetrievePostByPostId(int postId);
    }
}
