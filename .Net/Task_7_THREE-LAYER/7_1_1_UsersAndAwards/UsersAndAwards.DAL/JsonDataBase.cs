using System;
using System.Collections.Generic;
using System.IO;
using UsersAndAwards.Entities;
using Newtonsoft.Json;

namespace UsersAndAwards.DAL
{
    public class JsonDataBase
    {
        private readonly string path = "data.sav";
        public readonly Dictionary<Guid, User> userList;
        public readonly Dictionary<Guid, Award> awardList;
        public Dictionary<Guid, Emblem> emblemList;
        public List<Guid[]> awardedList;

        public Data LoadAll()
        {
            if (File.Exists(path))
            {
                try
                {
                    Data data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(path));
                    return data;
                }
                catch (IOException)
                {

                    return null;
                }
                catch(SystemException)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public bool SaveAll(Data saveData)
        {
            string json = JsonConvert.SerializeObject(saveData);

            if (json != string.Empty)
            {
                try
                {
                    File.WriteAllText(path, json);
                    return true;
                }
                catch (IOException)
                {

                    return false; ;
                }
                catch (SystemException)
                {
                    return false;
                }       
            }
            else
            {
                return false;
            }
        }
        public JsonDataBase(string spath)
        {
            path = spath + path;

            if (File.Exists(path))
            {
                Data data = LoadAll();

                userList = new Dictionary<Guid, User>();
                awardList = new Dictionary<Guid, Award>();
                emblemList = new Dictionary<Guid, Emblem>();

                foreach (User user in data.usersList)
                {
                    userList.Add(user.Id, user);
                }
                foreach (Award award in data.awardList)
                {
                    awardList.Add(award.Id, award);
                }
                emblemList = data.emblemList;
                awardedList = data.awardedUsers;
            }
            else
            {
                userList = new Dictionary<Guid, User>();
                awardList = new Dictionary<Guid, Award>();
                emblemList = new Dictionary<Guid, Emblem>();
                awardedList = new List<Guid[]>();

                Data saveData = new Data(new List<User>(), new List<Award>(), new Dictionary<Guid, Emblem>(), new List<Guid[]>());

                SaveAll(saveData);
            }
        } 
    }
}
