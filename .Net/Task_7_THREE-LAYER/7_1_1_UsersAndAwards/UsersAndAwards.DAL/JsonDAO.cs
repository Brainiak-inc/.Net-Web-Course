using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndAwards.DAL
{
    class JsonDAO
    {
        private static JsonDataBase dataBase;
        public static JsonDataBase Get(string path)
        {
            return dataBase ?? (dataBase = new JsonDataBase(path));
        }
    }
}
