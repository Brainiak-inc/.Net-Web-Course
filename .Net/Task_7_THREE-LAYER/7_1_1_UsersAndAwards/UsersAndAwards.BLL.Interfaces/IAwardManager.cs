using System;
using UsersAndAwards.Entities;
using System.Collections.Generic;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IAwardManager
    {
        Award AddAward(string name);
        bool RemoveAward(Award award);
        bool UpdateAward(Guid id, string name);
        bool IsAwardAdded(Guid id);
        Award GetAwardByID(Guid id);
        List<Award> GetAllAwards();
    }
}
