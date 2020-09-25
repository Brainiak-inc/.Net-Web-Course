using System;

namespace UsersAndAwards.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

        public User(string name, DateTime dateOfBirth, int age, Guid id)
        {
            this.Name = name;
            this.Age = age;
            this.DateOfBirth = dateOfBirth;
            this.Age = age;
            this.Id = id;
        }
    }
}
