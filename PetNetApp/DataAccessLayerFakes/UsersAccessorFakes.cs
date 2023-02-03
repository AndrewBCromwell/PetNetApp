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
        private List<UsersVM> fakeUsers = new List<UsersVM>();


        public UsersAccessorFakes()
        {
            fakeUsers.Add(new UsersVM()
            {
                UserId = 1000,
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
                UserId = 1001,
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
                UserId = 1002,
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
                UserId = 1003,
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
        }

        public List<UsersVM> SelectUserByRole(string RoleId)
        {
            List<UsersVM> users = new List<UsersVM>();

            foreach (var user in fakeUsers)
            {
                foreach (var role in user.Roles)
                {
                    if(role == RoleId)
                    {
                        users.Add(user);
                    }
                }
            }
            return users;
        }
    }
}