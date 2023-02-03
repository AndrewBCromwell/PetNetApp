using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;
using DataAccessLayerFakes;
using System.Security.Cryptography;

namespace LogicLayer
{
    public class UserManager : IUserManager
    {
        
        IUserAccessor _userAccessor;

        public UserManager()
        {
            _userAccessor = new UserAccessor();
        }

        public UserManager(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }


        /// <summary>
        /// Chris Dreismeier
        /// Created: 2023/03/02
        /// 
        /// 
        /// </summary>
        /// Retrieves all users with a certain role
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <param name="RoleId"></param>
        public List<UserVM> RetrieveUserByRole(string RoleId)
        {
            List<UserVM> users = new List<UserVM>();

            try
            {
                users = _userAccessor.SelectUserByRole(RoleId);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return users;
        }
    }
}
