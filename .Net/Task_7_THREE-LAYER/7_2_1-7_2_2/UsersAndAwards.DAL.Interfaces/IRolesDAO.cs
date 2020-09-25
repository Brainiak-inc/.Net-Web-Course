using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndAwards.DAL.Interfaces
{
    public interface IRolesDAO
    {
        string GetRolesOfUser(string name);
        bool IsUserInRole(string name, string role);
        bool AddRoleToUser(string name, string role);
    }
}
