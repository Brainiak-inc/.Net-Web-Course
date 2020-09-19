using UsersAndAwards.BLL;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAO.Interfaces;
using UsersAndAwards.DAO;
using UsersAndAwards.DAL.Interfaces;

namespace UsersAndAwards.Common
{
    public class DependencyResolver
    {
        private readonly IUserManager _userManager;
        private readonly IUserAwardsDAO _usersDAO;
        private readonly IUsersDAO _userDAO;
        private readonly IAwardManager _awardManager;
        private readonly IEmblemDAL _emblemDAL;
        private readonly IEmblemManager _emblemManager;
        private readonly IAwardsConnections _awardsConnections;
        private readonly IAwardsConnectionsDAO _awardConnectionsDAO;

        public IUserManager UserLogic => _userManager;
        public IAwardManager awardManager => _awardManager;
        public IEmblemManager emblemManager => _emblemManager;
        public IAwardsConnections awardsConnections => _awardsConnections;


        public DependencyResolver(string path)
        {
            _awardConnectionsDAO = 
        }
    }
}
