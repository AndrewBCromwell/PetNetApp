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
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Selects all replies that an admin or moderator could see
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        List<ReplyVM> SelectAllRepliesByPostId(int postId);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Selects active replies
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        List<ReplyVM> SelectActiveRepliesByPostId(int postId);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Selects a count of replies for an admin or moderator
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        int SelectCountRepliesByPostId(int postId);
        /// <summary>
        /// Author: Gwen Arman
        /// Date: 2023-03-26
        /// Description: Selects active replies
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        int SelectCountActiveRepliesByPostId(int postId);
    }
}
