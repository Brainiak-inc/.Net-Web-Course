using System.Collections.Generic;
using UsersAndAwards.Entities;
using UsersAndAwards.DAL.Interfaces;
using System;

namespace UsersAndAwards.DAO
{
    public class UserDAO : IUsersDAO
    {
        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUserByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsUserAdded(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUserByID(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
