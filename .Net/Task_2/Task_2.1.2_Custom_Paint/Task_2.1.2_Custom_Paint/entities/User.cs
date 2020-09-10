using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2_Custom_Paint
{
    class User
    {
        private string userName;
        private string userSurname;

        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public string UserSurname
        {
            get
            {
                return userSurname;
            }
            set
            {
                userSurname = value;
            }
        }
        public override string ToString()
        {
            return $"Username: {UserName} {UserSurname} \n";
        }
    }
}
