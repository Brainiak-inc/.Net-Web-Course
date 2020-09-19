using System;
using System.Collections.Generic;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Entities;
using UsersAndAwards.DAO.Interfaces;

namespace UsersAndAwards.BLL
{
    class AwardsManager : IAwardManager
    {
        private readonly IUserAwardsDAO _userAwardsDAO;

        public AwardsManager(IUserAwardsDAO userAwardsDAO)
        {
            this._userAwardsDAO = userAwardsDAO;
        }
        public Award AddAward(string name)
        {
            Award award = new Award(Guid.NewGuid(), name);
            if (_userAwardsDAO.AddAward(award))
            {
                return award;
            }
            return null;
        }

        public List<Award> GetAllAwards()
        {
            return _userAwardsDAO.GetAllAwards();
        }

        public Award GetAwardByID(Guid id)
        {
            return _userAwardsDAO.GetAwardByID(id);
        }

        public bool IsAwardAdded(Guid id)
        {
            return _userAwardsDAO.IsAwardAdded(id);
        }

        public bool RemoveAward(Award award)
        {
            return _userAwardsDAO.RemoveAward(award);
        }

        public bool UpdateAward(Guid id, string name)
        {
            return _userAwardsDAO.UpdateAward(new Award(id, name));
        }
    }
}
