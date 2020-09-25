using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.Interfaces
{
    public interface IAwardsConnectionsDAO
    {
        bool AddAwardToUser(User user, Award award);
        bool RemoveAwardFromUser(User user, Award award);
        bool RemoveUserAwardFromConnections(Guid id, bool user);
        List<User> GetAllUsersWithAwards(Award award);
        List<Award> GetAllUserAwards(User user);
        Dictionary<User, List<Award>> GetAllUsersWithAwards();
        Dictionary<Award, List<User>> GetAllAwardsWithUsers();
    }
}
