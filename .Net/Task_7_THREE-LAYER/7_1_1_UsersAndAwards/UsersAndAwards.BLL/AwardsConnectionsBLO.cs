using System.Collections.Generic;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.Entities;

namespace UsersAndAwards.BLL
{
    public class AwardsConnectionsBLO : IAwardsConnections
    {
        private readonly IAwardsConnectionsDAO _awardsConnectionsDAO;
        public AwardsConnectionsBLO(IAwardsConnectionsDAO awardsConnectionsDAO)
        {
            this._awardsConnectionsDAO = awardsConnectionsDAO;
        }
        public bool AddAwardtoUser(User user, Award award)
        {
            return _awardsConnectionsDAO.AddAwardToUser(user, award);
        }

        public List<User> GetAllAwardedUsers(Award award)
        {
            return _awardsConnectionsDAO.GetAllUsersWithAwards(award);
        }

        public Dictionary<Award, List<User>> GetAllAwardsUsers()
        {
            return _awardsConnectionsDAO.GetAllAwardsWithUsers();
        }

        public List<Award> GetAllGivenAwards(User user)
        {
            return _awardsConnectionsDAO.GetAllUserAwards(user);
        }

        public Dictionary<User, List<Award>> GetAllUsersAwards()
        {
            return _awardsConnectionsDAO.GetAllUsersWithAwards();
        }

        public bool RemoveAwardFromAllUsers(Award award)
        {
            return _awardsConnectionsDAO.RemoveUserAwardFromConnections(award.Id, false);
        }

        public bool RemoveAwardFromSingleUser(User user, Award award)
        {
            return _awardsConnectionsDAO.RemoveAwardFromUser(user, award);
        }
    }
}

