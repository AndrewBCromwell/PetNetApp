using DataAccessLayer;
using DataAccessLayerInterfaces;
using DataObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class ReplyManager : IReplyManager
    {
        private IReplyAccessor replyAccessor = null;
        public ReplyManager()
        {
            replyAccessor = new ReplyAccessor();
        }
        public ReplyManager(IReplyAccessor ra)
        {
            replyAccessor = ra;
        }

        public List<ReplyVM> RetrieveActiveRepliesByPostId(int postId)
        {
            List<ReplyVM> replies = new List<ReplyVM>();

            try
            {
                replies = replyAccessor.SelectActiveRepliesByPostId(postId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Replies not found", ex);
            }

            return replies;
        }

        public List<ReplyVM> RetrieveAllRepliesByPostId(int postId)
        {
            List<ReplyVM> replies = new List<ReplyVM>();

            try
            {
                replies = replyAccessor.SelectActiveRepliesByPostId(postId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Replies not found", ex);
            }

            return replies;
        }

        public int RetrieveCountActiveRepliesByPostId(int postId)
        {
            int count = 0;

            try
            {
                count = replyAccessor.SelectCountActiveRepliesByPostId(postId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not retrieve a count", ex);
            }
            return count;
        }

        public int RetrieveCountRepliesByPostId(int postId)
        {
            int count = 0;

            try
            {
                count = replyAccessor.SelectCountActiveRepliesByPostId(postId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not retrieve a count", ex);
            }
            return count;
        }
    }
}
