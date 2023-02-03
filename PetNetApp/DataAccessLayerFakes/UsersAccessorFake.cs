using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;

namespace DataAccessLayerFakes
{
    public class UsersAccessorFake : IUsersAccessor
    {
        private List<Users> fakeUsers = new List<Users>();

        public UsersAccessorFake()
        {
            fakeUsers.Add(new Users()
            {
                UsersId = 100000,
                GenderId = "Unknow",
                ShelterId = 100000,
                GivenName = "Test",
                FamilyName = "User",
                Email = "test@gmail.com",
                PasswordHash = "123456789",
                Address = "33 Sage Road",
                Zipcode = "52404",
                Phone = "123456789",
                CreationDate = DateTime.Now,
                Active = true,
                Suspended = false
            });

            fakeUsers.Add(new Users()
            {
                UsersId = 100001,
                GenderId = "Unknow",
                ShelterId = 100000,
                GivenName = "Test",
                FamilyName = "User2",
                Email = "test2@gmail.com",
                PasswordHash = "123456789",
                Address = "33 Sage Road",
                Zipcode = "52404",
                Phone = "123456789",
                CreationDate = DateTime.Now,
                Active = true,
                Suspended = false
            });

            fakeUsers.Add(new Users()
            {
                UsersId = 100002,
                GenderId = "Unknow",
                ShelterId = 100000,
                GivenName = "Test",
                FamilyName = "User3",
                Email = "test3@gmail.com",
                PasswordHash = "123456789",
                Address = "33 Sage Road",
                Zipcode = "52404",
                Phone = "123456789",
                CreationDate = DateTime.Now,
                Active = true,
                Suspended = false
            });
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

        public List<Users> SelectAllEmployees()
        {
            return fakeUsers;
        }
    }
}
