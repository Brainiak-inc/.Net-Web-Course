using System;
using System.Collections.Generic;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Entities;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.DAL;

namespace UsersAndAwards.BLL
{
    public class RoleManager : IRoleManager
    {
        public bool AddRoleToUser(string name, string role)
        {
            throw new NotImplementedException();
        }

        public string GetRoleOfUser(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsUserInRole(string name, string role)
        {
            throw new NotImplementedException();
        }
    }
}
