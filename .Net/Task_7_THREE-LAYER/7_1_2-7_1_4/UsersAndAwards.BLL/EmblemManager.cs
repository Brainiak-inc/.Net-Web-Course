using System;
using System.Collections.Generic;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Entities;
using UsersAndAwards.DAL.Interfaces;
using System.IO;

namespace UsersAndAwards.BLL
{
    public class EmblemManager : IEmblemManager
    {
        private readonly IEmblemDAL _emblemDAL;
        public EmblemManager(IEmblemDAL emblemDAL)
        {
            this._emblemDAL = emblemDAL;
        }

        public string CreateEmblem(IGetID item, string ext, BinaryReader reader)
        {
            return _emblemDAL.CreateEmblem(item, ext, reader);
        }

        public string EmblemPath(IGetID item)
        {
            return _emblemDAL.EmblemPath(item);
        }

        public bool IsElementGetEmblem(IGetID item)
        {
            return _emblemDAL.IsElementGetEmblem(item);
        }

        public bool RemoveEmblem(IGetID item)
        {
            return _emblemDAL.RemoveEmblem(item);
        }
    }
}
