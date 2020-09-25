using UsersAndAwards.DAL.Interfaces;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace UsersAndAwards.DAL
{
    public class AuthDAO : IAuthDAO
    {
        private static readonly string _connectionString = ConfigurationManager.
        public bool CheckUser(string name, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateUser(string name, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
