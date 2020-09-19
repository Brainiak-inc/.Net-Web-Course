using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAO.Interfaces
{
    public interface IUserAwardsDAO
    {
        bool AddAward(Award award);
        bool RemoveAward(Award award);
        bool RemoveAwardByID(Guid id);
        bool UpdateAward(Award award);
        bool IsAwardAdded(Guid id);
        Award GetAwardByID(Guid id);
        List<Award> GetAllAwards();
    }
}
