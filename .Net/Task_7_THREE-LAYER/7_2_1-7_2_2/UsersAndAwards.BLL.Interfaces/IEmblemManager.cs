using System.IO;
using UsersAndAwards.Entities;

namespace UsersAndAwards.BLL.Interfaces
{
    public interface IEmblemManager
    {
        string CreateEmblem(IGetID item, string ext, BinaryReader reader);
        bool IsElementGetEmblem(IGetID item);
        string EmblemPath(IGetID item);
        bool RemoveEmblem(IGetID item);
    }
}
