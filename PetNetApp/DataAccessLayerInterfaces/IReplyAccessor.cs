using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IReplyAccessor
    {
        List<ReplyVM> SelectAllRepliesByPostId(int postId);
        List<ReplyVM> SelectActiveRepliesByPostId(int postId);
        int SelectCountRepliesByPostId(int postId);
        int SelectCountActiveRepliesByPostId(int postId);
    }
}
