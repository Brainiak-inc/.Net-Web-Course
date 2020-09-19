using System;
using UsersAndAwards.Entities;
using System.Collections.Generic;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IAwardsConnections
    {
        bool AddAwardtoUser(User user, Award award);
        bool RemoveAwardFromSingleUser(User user, Award award);
        bool RemoveAwardFromAllUsers(Award award);
        List<User> GetAllAwardedUsers(User user);
        List<Award> GetAllGivenAwards(Award award);
        Dictionary<User, List<Award>> GetAllUsersAwards();
        Dictionary<Award, List<User>> GetAllAwardsUsers();
    }
}
