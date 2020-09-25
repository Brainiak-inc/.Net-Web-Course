using System;
using System.Collections.Generic;
using UsersAndAwards.DAO.Interfaces;
using UsersAndAwards.Entities;
using UsersAndAwards.DAL.Interfaces;
using System.Linq;
using System.IO;

namespace UsersAndAwards.DAL
{
    public class JsonAwards : IUserAwardsDAO
    {
        private readonly string _path;
        private readonly JsonDataBase _dataBase;
        private readonly IAwardsConnectionsDAO _awardsConnections;

        public JsonAwards(IAwardsConnectionsDAO awardsConnections, string path)
        {
            this._path = path;
            this._awardsConnections = awardsConnections;
            this._dataBase = JsonDAO.Get(path);

        }

        public bool AddAward(Award award)
        {
            Data data = _dataBase.LoadAll();

            if (data != null && _dataBase.awardList.Where(item => item.Value.Title == award.Title).Count() == 0)
            {
                data.awardList.Add(award);

                if (_dataBase.SaveAll(data))
                {
                    _dataBase.awardList.Add(award.Id, award);
                    return true;
                }
            }
            return false;
        }

        public List<Award> GetAllAwards()
        {
            return _dataBase.awardList.Select(KeyValuePair => KeyValuePair.Value).ToList();
        }

        public Award GetAwardByID(Guid id)
        {
            if (_dataBase.awardList.ContainsKey(id))
            {
                return _dataBase.awardList[id];
            }
            return null;
            
        }

        public bool IsAwardAdded(Guid id)
        {
            return _dataBase.awardList.ContainsKey(id);
        }

        public bool RemoveAward(Award award)
        {
            Data data = _dataBase.LoadAll();

            if (data != null && _dataBase.awardList.ContainsKey(award.Id))
            {
                data.awardList = data.awardList.Where(item => item.Id != award.Id).ToList();

                if (data.emblemList.ContainsKey(award.Id))
                {
                    try
                    {
                        data.emblemList.Remove(award.Id);
                        File.Delete($"{_path}{_dataBase.emblemList[award.Id].Path.Substring(1)}");
                    }
                    catch (IOException)
                    {
                        throw;
                    }
                }
                if (_dataBase.SaveAll(data))
                {
                    if (_awardsConnections.RemoveUserAwardFromConnections(award.Id, false))
                    {
                        _dataBase.awardList.Remove(award.Id);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool RemoveAwardByID(Guid id)
        {
            Data data = _dataBase.LoadAll();

            if (data != null && _dataBase.awardList.ContainsKey(id))
            {
                data.awardList = data.awardList.Where(item => item.Id != id).ToList();

                if (_dataBase.SaveAll(data))
                {
                    _dataBase.awardList.Remove(id);
                    return true;
                }
            }
            return false;
        }

        public bool UpdateAward(Award award)
        {
            Data data = _dataBase.LoadAll();
            Award tempAward = _dataBase.awardList[award.Id];

            if (data != null && _dataBase.awardList.ContainsKey(award.Id))
            {
                int index = data.awardList.FindIndex(item => item.Id == award.Id);

                data.awardList[index].Title = award.Title;
                _dataBase.awardList[award.Id].Title = award.Title;

                if (_dataBase.SaveAll(data))
                {
                    return true;
                }
                _dataBase.awardList[award.Id] = tempAward;
            }
            return false;
        }
    }
}
