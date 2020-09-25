using System.IO;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.Interfaces
{
    public interface IEmblemDAL
    {
        string CreateEmblem(IGetID item, string ext, BinaryReader reader);
        bool IsElementGetEmblem(IGetID item);
        string EmblemPath(IGetID item);
        bool RemoveEmblem(IGetID item);
    }
}
