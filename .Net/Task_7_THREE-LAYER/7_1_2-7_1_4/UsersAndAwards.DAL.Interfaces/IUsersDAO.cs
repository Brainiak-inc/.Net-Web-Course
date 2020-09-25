using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.Interfaces
{
    public interface IUsersDAO
    {
        bool AddUser(User user);
        bool RemoveUser(User user);
        bool RemoveUserByID(Guid id);
        bool UpdateUser(User user);
        bool IsUserAdded(Guid id);
        User GetUserByID(Guid id);
        List<User> GetAllUsers();
    }
}
