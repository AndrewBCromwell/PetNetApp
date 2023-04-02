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
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Retrieves all replies that an admin or moderator could see by post id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        List<ReplyVM> RetrieveAllRepliesByPostId(int postId);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Retrieves active replies 
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        List<ReplyVM> RetrieveActiveRepliesByPostId(int postId);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Retrieves count of replies for an admin or moderator
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        int RetrieveCountRepliesByPostId(int postId);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Retrieves count of active replies
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        int RetrieveCountActiveRepliesByPostId(int postId);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-04-01
        /// Description: Adds a reply
        /// </summary>
        /// <param name="reply"></param>
        /// <returns></returns>
        int AddReply(Reply reply);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-04-01
        /// Description: Edits a reply
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="newReply"></param>
        /// <returns></returns>
        bool EditReply(Reply reply, Reply newReply);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-04-01
        /// Description: Retrieves reply by reply id
        /// </summary>
        /// <param name="replyId"></param>
        /// <returns></returns>
        ReplyVM RetrieveReplyByReplyId(int replyId);
    }
}
