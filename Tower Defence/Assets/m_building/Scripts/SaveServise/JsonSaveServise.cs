using System.IO;
using UnityEngine;

public class JsonSaveServise : ISaveServise
{
    public void Save(string key, object data)
    {
        string path = BuildPath(key);
        string json = JsonUtility.ToJson(data);

        using (var streamWriter = new StreamWriter(path))
            streamWriter.Write(json);       
    }

    public string Load(string key)
    {
        string path = BuildPath(key);

        if (File.Exists(path) == false)
            return null;

        using (var fileStream = new StreamReader(path))    
            return fileStream.ReadToEnd();
    }

    public void DeleteData(string key)
    {
        string path = BuildPath(key);

        if (File.Exists(path))
            File.Delete(path);
    } 

    private string BuildPath(string key)
    {
        return Path.Combine(Application.persistentDataPath, key);
    }
}