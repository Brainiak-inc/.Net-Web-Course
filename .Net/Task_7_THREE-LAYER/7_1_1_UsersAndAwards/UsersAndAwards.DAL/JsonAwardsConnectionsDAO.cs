using System;
using System.Collections.Generic;
using System.IO;
using UsersAndAwards.Entities;
using Newtonsoft.Json;
using UsersAndAwards.DAL.Interfaces;
using System.Linq;

namespace UsersAndAwards.DAL
{
    class JsonAwardsConnectionsDAO : IAwardsConnectionsDAO
    {
		private readonly JsonDataBase dataBase;

		public JsonAwardsConnectionsDAO(string path)
		{
			dataBase = JsonDAO.Get(path);
		}

		public List<Guid[]> GetListOfAwardedUsers() => dataBase.awardedList;

		public List<Award> GetAllUserAwards(User user) => GetAllUsersWithAwards()[user];

		public List<User> GetAllUsersWithAwards(Award award) => GetAllAwardsWithUsers()[award];


		public Dictionary<User, List<Award>> GetAllUsersWithAwards()
		{
			Dictionary<User, List<Award>> temp = new Dictionary<User, List<Award>>();

			foreach (User user in dataBase.userList.Values)
			{
				List<Award> awards = dataBase.awardedList.Where(value => value[0] == user.Id).Select(value => dataBase.awardList[value[1]]).ToList();

				temp.Add(user, awards);
			}

			return temp;
		}


		public Dictionary<Award, List<User>> GetAllAwardsWithUsers()
		{
			Dictionary<Award, List<User>> temp = new Dictionary<Award, List<User>>();

			foreach (Award award in dataBase.awardList.Values)
			{
				List<User> users = dataBase.awardedList.Where(value => value[1] == award.Id).Select(value => dataBase.userList[value[0]]).ToList();

				temp.Add(award, users);
			}

			return temp;
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
				Guid[] pair = new Guid[] { user.Id, award.Id };

				data.awardedUsers.Add(pair);
				dataBase.awardedList.Add(pair);

				if (dataBase.SaveAll(data))
				{
					return true;
				}

				dataBase.awardedList.Remove(pair);
			}

			return false;
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
			List<Guid[]> temp;

			Data data = dataBase.LoadAll();

			if (data != null)
			{
				if (user)
				{
					temp = dataBase.awardedList.Where(item => item[0] != id).ToList();
				}
				else
				{
					temp = dataBase.awardedList.Where(item => item[1] != id).ToList();
				}

				data.awardedUsers = temp;

				if (dataBase.SaveAll(data))
				{
					dataBase.awardedList = temp;
					return true;
				}
			}

			return false;
		}
	}
}
