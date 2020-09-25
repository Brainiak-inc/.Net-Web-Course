using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAndAwards.Entities
{
    public class Emblem
    {
        public string Path { get; set; }
        public Emblem(string path)
        {
            Path = path;
        }
    }
}
