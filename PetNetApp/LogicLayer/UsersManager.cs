using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayer;
using DataAccessLayerInterfaces;

namespace LogicLayer
{
    public class UsersManager : IUsersManager
    {
        IUserAccessor _userAccessor = null;

        public UsersManager()
        {
            _userAccessor = new UserAccessor();
        }

        public UsersManager(IUserAccessor ua)
        {
            _userAccessor = ua;
        }

        /// <summary>
        /// Hoang Chu
        /// Created: 2023/02/01
        /// 
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// example: Fixed a problem when user inputs bad data
        /// </remarks>
        /// <returns>List<Users></returns>
        public List<Users> RetriveAllEmployees()
        {
            List<Users> employeeList = null;

            try
            {
                employeeList = _userAccessor.SelectAllEmployees();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }

            return employeeList;
        }
    }
}
