public interface ISaveServise
{
    public void Save(string key, object data);

    public string Load(string key);

    public void DeleteData(string key);
}