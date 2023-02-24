﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerFakes;
using DataAccessLayerInterfaces;
using DataObjects;

namespace DataAccessLayerFakes
{
    public class UsersAccessorFakes : IUsersAccessor
    {
        private List<Users> _fakeUsers = new List<Users>(); 
        private List<UsersVM> fakeUsers = new List<UsersVM>();
        private List<string> fakePassword = new List<string>();
        private Users fakeUser = new Users();


        public UsersAccessorFakes()
        {
            fakeUser = new Users()
            {
                UsersId = 1000,
                GivenName = "Stephan",
                FamilyName = "technowiz",
                Email = "Stephan@company.com",
                Address = "4150 riverview road",
                Zipcode = "52411",
                Phone = "319-123-1325",
                Active = true

            };
            fakeUsers.Add(new UsersVM()
            {
                UsersId = 1000,
                ShelterId = 1,
                GivenName = "Stephan",
                FamilyName = "technowiz",
                Email = "Stephan@company.com",
                Address = "4150 riverview road",
                Zipcode = "52411",
                Phone = "319-123-1325",
                Active = true,
                Roles = new List<string>()
            }) ;
            fakeUsers.Add(new UsersVM()
            {
                UsersId = 1001,
                ShelterId = 1,
                GivenName = "Chris",
                FamilyName = "Dreismeier",
                Email = "Chris@company.com",
                Address = "4150 Chestnut road",
                Zipcode = "52411",
                Phone = "319-789-1325",
                Active = true,
                Roles = new List<string>()
            });
            fakeUsers.Add(new UsersVM()
            {
                UsersId = 1002,
                ShelterId = 1,
                GivenName = "Asa",
                FamilyName = "arm",
                Email = "Asa@company.com",
                Address = "1234 Minden road",
                Zipcode = "12345",
                Phone = "319-567-1325",
                Active = true,
                Roles = new List<string>()
            });
            fakeUsers.Add(new UsersVM()
            {
                UsersId = 1003,
                ShelterId = 2,
                GivenName = "Andrew",
                FamilyName = "bob",
                Email = "Andrew@company.com",
                Address = "5678 mapleview road",
                Zipcode = "54321",
                Phone = "319-321-1325",
                Active = true,
                Roles = new List<string>()
            });


            fakeUsers[0].Roles.Add("Volunteer");
            fakeUsers[1].Roles.Add("Volunteer");
            fakeUsers[2].Roles.Add("Volunteer");
            fakeUsers[3].Roles.Add("Admin");

            fakePassword.Add("9c9064c59f1ffa2e174ee754d2979be80dd30db552ec03e7e327e9b1a4bd594e");

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

        public List<UsersVM> SelectAllEmployees()
        {
            return fakeUsers;
        }

        public int AuthenticateUserWithEmailAndPasswordHash(string email, string passwordHash)
        {
            int numAuthenticated = 0;

            for (int i = 0; i < fakeUsers.Count; i++)
            {
                if (fakeUsers[i].Email == email)
                {
                    if (fakePassword[i] == passwordHash && fakeUsers[i].Active && !fakeUsers[i].SuspendEmployee)
                    {
                        numAuthenticated += 1;
                    }
                }
            }

            return numAuthenticated;
        }

        public List<string> SelectAllGenders()
        {
            throw new NotImplementedException();
        }

        public List<string> SelectAllPronouns()
        {
            throw new NotImplementedException();
        }

        public List<string> SelectRolesByUserID(int userId)
        {
            List<string> roles = new List<string>();

            foreach (var fakeUser in fakeUsers)
            {
                if (fakeUser.UsersId == userId)
                {
                    roles = fakeUser.Roles;
                    break;
                }

            }

            return roles;
        }

        public UsersVM SelectUserByEmail(string email)
        {
            UsersVM user = new UsersVM();

            foreach (var fakeUser in fakeUsers)
            {
                if (fakeUser.Email == email)
                {
                    user = fakeUser;
                    user.Roles = new List<string>();
                    break;
                }

            }

            if (user == null)
            {
                throw new ApplicationException("User not found.");
            }

            return user;
        }

        public List<UsersVM> SelectUserByRole(string roleId, int shelterId)
        {
            List<UsersVM> users = new List<UsersVM>();

            foreach (var user in fakeUsers)
            {
                foreach (var role in user.Roles)
                {
                    if(role == roleId)
                    {
                        users.Add(user);
                    }
                }
            }
            return users;
        }

       
        public int DeactivateUserAccount(int UserId)
        {
            var matchUsers = fakeUsers.Where(user => user.UsersId == UserId);

            foreach (Users currentUser in matchUsers)
            {
                currentUser.Active = false; 
            }

            return matchUsers.Count(); 
            
        }

        public int CreateNewUser(Users user, string PasswordHash)
        {
            _fakeUsers.Add(user);

            return _fakeUsers.Count(); 
        }

        /// <summary>
        /// Zaid Rachman
        /// Created:2023/02/15
        /// 
        /// Used to check if the user exists in the database.
        /// </summary>
        /// <returns>List<Users></returns>
        public List<UsersVM> SelectUsersByUsersId(int usersId)
        {
            List<UsersVM> userfakes = new List<UsersVM>();
            foreach (UsersVM fakeUser in fakeUsers)
            {
                if (usersId == fakeUser.UsersId)
                {
                    userfakes.Add(fakeUser);
                }
            }
            return userfakes;
        }
        public Users SelectUserByUsersId(int UsersId)
        {
            return fakeUser;
            //throw new NotImplementedException();
        }
        public UsersVM SelectUserByUsersIdWithRoles(int UsersId)
        {
            throw new NotImplementedException();
        }
    }
}
