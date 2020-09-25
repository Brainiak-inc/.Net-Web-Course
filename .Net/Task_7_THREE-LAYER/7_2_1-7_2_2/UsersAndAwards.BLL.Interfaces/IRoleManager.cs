using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IRoleManager
    {
        string GetRoleOfUser(string name);
        bool IsUserInRole(string name, string role);
        bool AddRoleToUser(string name, string role);
    }
}
