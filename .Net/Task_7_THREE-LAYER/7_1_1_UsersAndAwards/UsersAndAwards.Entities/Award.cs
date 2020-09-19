using System;

namespace UsersAndAwards.Entities
{
    public class Award
    {
        private string v;
        private string name;
        private Guid guid;
        private object id;

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Award(Guid id, string name)
        {
            this.Title = name;
            this.Id = id;
        }

        public Award(string v, string name, Guid guid, object id)
        {
            this.v = v;
            this.name = name;
            this.guid = guid;
            this.id = id;
        }
    }
}
