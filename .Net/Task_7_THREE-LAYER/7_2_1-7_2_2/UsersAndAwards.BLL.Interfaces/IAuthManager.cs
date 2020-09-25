using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IAuthManager
    {
        bool CreateUser(string name, string password);
        bool CheckUser(string name, string password);
    }
}
