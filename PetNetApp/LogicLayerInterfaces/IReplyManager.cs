using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IReplyManager
    {
        List<ReplyVM> RetrieveAllRepliesByPostId(int postId);
        List<ReplyVM> RetrieveActiveRepliesByPostId(int postId);
        int RetrieveCountRepliesByPostId(int postId);
        int RetrieveCountActiveRepliesByPostId(int postId);
    }
}
