using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndAwards.Entities
{
    public class UsersList
    {
        public List<User> usersList;
        public List<Award> awardsList;
        public List<Guid> awardedUsers;

        public UsersList(List<User> users, List<Award> awards, List<Guid> awardsId)
        {
            this.usersList = users;
            this.awardsList = awards;
            this.awardedUsers = awardsId;
        }
    }
}
