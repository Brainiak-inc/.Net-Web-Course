using System;
using System.Collections.Generic;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Entities;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.DAL;

namespace UsersAndAwards.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IUsersDAO _usersDAO;
        public UserManager(IUsersDAO usersDAO)
        {
            this._usersDAO = usersDAO;
        }
        public User AddUser(string name, DateTime dateOfBirth, int age)
        {
            User user = new User(name, dateOfBirth, age, Guid.NewGuid());

            if (_usersDAO.AddUser(user))
            {
                return user;
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            return _usersDAO.GetAllUsers();
        }

        public User GetUserByID(Guid id)
        {
            return _usersDAO.GetUserByID(id);
        }

        public bool IsUserAdded(Guid id)
        {
            return _usersDAO.IsUserAdded(id);
        }

        public bool RemoveUser(User user)
        {
            return _usersDAO.RemoveUser(user);
        }
        public bool UpdateUser(Guid id, string name, int age, DateTime dateOfBirth)
        {
            return _usersDAO.UpdateUser(new User(name, dateOfBirth, age, id));
        }
    }
}
