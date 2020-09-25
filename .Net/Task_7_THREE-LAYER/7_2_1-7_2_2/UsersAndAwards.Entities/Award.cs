using System;

namespace UsersAndAwards.Entities
{
    public class Award
    {
        private string _v;
        private string _name;
        private Guid _guid;
        private object _id;

        public Guid Id { get; set; }
        public string Title { get; set; }
        public Award(Guid id, string name)
        {
            this.Title = name;
            this.Id = id;
        }

        public Award(string v, string name, Guid guid, object id)
        {
            this._v = v;
            this._name = name;
            this._guid = guid;
            this._id = id;
        }
    }
}
