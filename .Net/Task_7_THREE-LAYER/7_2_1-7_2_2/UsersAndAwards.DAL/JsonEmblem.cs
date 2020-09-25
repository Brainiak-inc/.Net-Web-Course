using System;
using UsersAndAwards.Entities;
using UsersAndAwards.DAL.Interfaces;
using System.IO;

namespace UsersAndAwards.DAL
{
    public class JsonEmblem : IEmblemDAL
    {
        private readonly string _path;
        private readonly JsonDataBase _dataBase;

        public JsonEmblem(string path)
        {
            this._path = path;
            this._dataBase = JsonDAO.Get(path);
        }

        public string CreateEmblem(IGetID item, string ext, BinaryReader reader)
        {
            Guid emblemID = Guid.NewGuid();
            string savePath = $"{_path}\\images\\avatars\\";

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }
            try
            {
                using (reader)
                {
                    int length = (int)reader.BaseStream.Length;
                    byte[] file = reader.ReadBytes(length);
                    File.WriteAllBytes($"{savePath}{emblemID}.{ext}", file);
                }
                Data data = _dataBase.LoadAll();
                if (data.emblemList.ContainsKey(item.ID))
                {
                    File.Delete($"{_path}{_dataBase.emblemList[item.ID].Path.Substring(1)}");
                    data.emblemList[item.ID].Path = $"./images/avatars/{emblemID}.{ext}";
                }
                else
                {
                    data.emblemList.Add(item.ID, new Emblem($"./images/avatars/{emblemID}.{ext}"));
                }
                if (_dataBase.SaveAll(data))
                {
                    _dataBase.emblemList = data.emblemList;
                    return $"./images/avatars/{emblemID}.{ext}";
                }
                return null;
            }
            catch (IOException)
            {

                return null;
            }
        }

        public string EmblemPath(IGetID item)
        {
            if (_dataBase.emblemList.ContainsKey(item.ID))
            {
                return _dataBase.emblemList[item.ID].Path;
            }
            return null;
        }

        public bool IsElementGetEmblem(IGetID item)
        {
            return _dataBase.emblemList.ContainsKey(item.ID);
        }

        public bool RemoveEmblem(IGetID item)
        {
            if (_dataBase.emblemList.ContainsKey(item.ID))
            {
                try
                {
                    File.Delete($"{_path}{_dataBase.emblemList[item.ID].Path.Substring(1)}");
                }
                catch (IOException)
                {

                    throw;
                }
                Data data = _dataBase.LoadAll();
                data.emblemList.Remove(item.ID);

                if (_dataBase.SaveAll(data))
                {
                    _dataBase.emblemList.Remove(item.ID);
                    return true;
                }
            }
            return false;
        }
    }
}
