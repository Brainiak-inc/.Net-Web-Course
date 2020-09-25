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
        List<User> GetAllAwardedUsers(Award award);
        List<Award> GetAllGivenAwards(User user);
        Dictionary<User, List<Award>> GetAllUsersAwards();
        Dictionary<Award, List<User>> GetAllAwardsUsers();
    }
}
