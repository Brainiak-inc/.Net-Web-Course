using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.DAO.Interfaces;
using UsersAndAwards.DAL;
using UsersAndAwards.DAO;
using UsersAndAwards.DAL.Interfaces;
using UsersAndAwards.BLL;

namespace UsersAndAwards.Common
{
    public class DependencyResolver
    {
        private readonly IUserManager _userManager;
        private readonly IUserAwardsDAO _awardsDAO;
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
            _awardConnectionsDAO = new JsonAwardsConnectionsDAO(path);
            _userDAO = new UserDAO(_awardConnectionsDAO, path);
            _awardsDAO = new JsonAwards(_awardConnectionsDAO, path);
            _emblemDAL = new JsonEmblem(path);
            _userManager = new UserManager(_userDAO);
            _awardManager = new AwardsManager(_awardsDAO);
            _emblemManager = new EmblemManager(_emblemDAL);
            _awardsConnections = new AwardsConnectionsBLO(_awardConnectionsDAO);
        }
    }
}
