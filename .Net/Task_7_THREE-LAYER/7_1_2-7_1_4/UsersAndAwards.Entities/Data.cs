using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndAwards.Entities
{
    public class Data
    {
        public List<User> usersList;
        public List<Award> awardList;
        public Dictionary<Guid, Emblem> emblemList;
        public List<Guid[]> awardedUsers;

        public Data(List<User> userList, List<Award> awardList, Dictionary<Guid, Emblem> emblemList, List<Guid[]> awardedUsers)
        {
            this.usersList = userList;
            this.awardList = awardList;
            this.emblemList = emblemList;
            this.awardedUsers = awardedUsers;
        }
    }
}
