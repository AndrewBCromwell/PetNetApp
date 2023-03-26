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
        List<PostVM> SelectAllPosts();
        List<PostVM> SelectActivePosts();
        int InsertPost(Post post);
        int UpdatePost(Post post, Post newPost);
        PostVM SelectPostByPostId(int postId);
    }
}
