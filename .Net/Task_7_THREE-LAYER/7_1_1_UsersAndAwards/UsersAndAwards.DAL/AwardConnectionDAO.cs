using System.Collections.Generic;
using UsersAndAwards.DAO.Interfaces;
using UsersAndAwards.Entities;
using UsersAndAwards.DAL.Interfaces;
using System;
using System.Linq;

namespace UsersAndAwards.DAL
{
    class AwardConnectionDAO : IAwardsConnectionsDAO
    {
        private readonly JsonDataBase dataBase;
        public List<Guid[]> GetListOfAwardedUsers()
        {
            return dataBase.awardedList;
        }
        public AwardConnectionDAO(string path)
        {
            dataBase = JsonDAO.Get(path);
        }
        public bool AddAwardToUser(User user, Award award)
        {
            if (dataBase.awardedList.Where(item => item[0] == user.Id && item[1] == award.Id).Count() > 0)
            {
                return false;
            }
            Data data = dataBase.LoadAll();
            if (data != null)
            {
                Guid[] bunch = new Guid[] { user.Id, award.Id };

                data.awardedUsers.Add(bunch);
                dataBase.awardedList.Add(bunch);

                if (dataBase.SaveAll(data))
                {
                    return true;
                }
                dataBase.awardedList.Remove(bunch);
            }
            return false;
        }

        public Dictionary<Award, List<User>> GetAllAwardsWithUsers()
        {
            Dictionary<Award, List<User>> temp = new Dictionary<Award, List<User>>();
            foreach (Award award in dataBase.awardList.Values)
            {
                List<User> users = dataBase.awardedList.Where(values => values[1] == award.Id).Select(value => dataBase.userList[value[0]]).ToList();
                temp.Add(award, users);
            }
            return temp;
        }

        public List<User> GetAllUsersWithAwards(Award award)
        {
            return GetAllAwardsWithUsers()[award];
        }

        public List<Award> GetAllUserAwards(User user)
        {
            return GetAllUsersWAwards()[user];
        }

        public Dictionary<User, List<Award>> GetAllUsersWAwards()
        {
            Dictionary<User, List<Award>> temp = new Dictionary<User, List<Award>>();

            foreach (User user in dataBase.userList.Values)
            {
                List<Award> awards = dataBase.awardedList.Where(value => value[0] == user.Id).Select(value => dataBase.awardList[value[1]]).ToList();

                temp.Add(user, awards);
            }
            return temp;
        }

        public bool RemoveAwardFromUser(User user, Award award)
        {
            int position = dataBase.awardedList.FindIndex(item => item[0] == user.Id && item[1] == award.Id);

            if (position < 0)
            {
                return false;
            }
            Data data = dataBase.LoadAll();

            if (data != null)
            {
                Guid[] temp = dataBase.awardedList[position];

                dataBase.awardedList.RemoveAt(position);
                data.awardedUsers = dataBase.awardedList;

                if (dataBase.SaveAll(data))
                {
                    return true;
                }
                dataBase.awardedList.Add(temp);
            }
            return false;
        }

        public bool RemoveUserAwardFromConnections(Guid id, bool user = true)
        {
            
        }
    }
}
