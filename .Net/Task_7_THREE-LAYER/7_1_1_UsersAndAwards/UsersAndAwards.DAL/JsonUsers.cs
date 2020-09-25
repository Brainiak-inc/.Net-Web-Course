using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL
{
    class JsonUsers : IUsersDAO
    {
        private readonly string _path;
        private readonly JsonDataBase _dataBase;
        private readonly IAwardsConnectionsDAO _awardsConnections;
        public bool AddUser(User user)
        {
            Data data = _dataBase.LoadAll();

            if (data != null && _dataBase.userList.Where(item => item.Value.Name == user.Name  && item.Value.Age == user.Age && item.Value.DateOfBirth == user.DateOfBirth).Count() == 0)
            {
                data.usersList.Add(user);

                if (_dataBase.SaveAll(data))
                {
                    _dataBase.userList.Add(user.Id, user);
                    return true;
                }
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            return _dataBase.userList.Select(KeyValuePair => KeyValuePair.Value).ToList();
        }

        public User GetUserByID(Guid id)
        {
            if (_dataBase.userList.ContainsKey(id))
            {
                return _dataBase.userList[id];
            }
            return null;
        }

        public bool IsUserAdded(Guid id)
        {
            return _dataBase.userList.ContainsKey(id);
        }

        public bool RemoveUser(User user)
        {
            Data data = _dataBase.LoadAll();

            if (data != null && _dataBase.userList.ContainsKey(user.Id))
            {
                data.usersList = data.usersList.Where(item => item.Id != user.Id).ToList();

                if (data.emblemList.ContainsKey(user.Id))
                {
                    try
                    {
                        data.emblemList.Remove(user.Id);
                        File.Delete($"{_path}{_dataBase.emblemList[user.Id].Path.Substring(1)}");
                    }
                    catch (IOException)
                    {

                        throw;
                    }
                }
                if (_dataBase.SaveAll(data))
                {
                    if (_awardsConnections.RemoveUserAwardFromConnections(user.Id, true))
                    {
                        _dataBase.userList.Remove(user.Id);
                        return true;
                    }

                }
            }
            return false;
        }

        public bool RemoveUserByID(Guid id)
        {
            Data data = _dataBase.LoadAll();

            if (data != null && _dataBase.userList.ContainsKey(id))
            {
                data.usersList = data.usersList.Where(item => item.Id != id).ToList();

                if (_dataBase.SaveAll(data))
                {
                    _dataBase.userList.Remove(id);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateUser(User user)
        {
            Data data = _dataBase.LoadAll();
            User tempUser = _dataBase.userList[user.Id];

            if (data != null && _dataBase.userList.ContainsKey(user.Id))
            {
                int index = data.usersList.FindIndex(item => item.Id == user.Id);

                data.usersList[index].Age = user.Age;
                data.usersList[index].Name = user.Name;
                data.usersList[index].DateOfBirth = user.DateOfBirth;
                _dataBase.userList[user.Id].Age = user.Age;
                _dataBase.userList[user.Id].Name = user.Name;
                _dataBase.userList[user.Id].DateOfBirth = user.DateOfBirth;

                if (_dataBase.SaveAll(data))
                {
                    return true;
                }
                _dataBase.userList[user.Id] = tempUser;
            }
            return false;
        }
    }
}
