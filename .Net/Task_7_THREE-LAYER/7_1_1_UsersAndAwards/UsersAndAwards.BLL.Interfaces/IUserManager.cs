﻿using System;
using UsersAndAwards.Entities;
using System.Collections.Generic;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IUserManager
    {
        User AddUser(string name, DateTime dateOfBirth, int age);
        bool RemoveUser(User user);
        bool IsUserAdded(Guid id);
        User GetUserByID(Guid id);
        List<User> GetAllUsers();
    }
}