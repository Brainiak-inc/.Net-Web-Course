using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndAwards.DAL.Interfaces
{
    public interface IAuthDAO
    {
        bool CreateUser(string name, string password);
        bool CheckUser(string name, string password);
    }
}
