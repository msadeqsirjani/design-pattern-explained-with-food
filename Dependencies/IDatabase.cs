namespace Dependencies;

public interface IDatabase
{
    Task Connect();
    Task Disconnect();
    Task<List<string>> DumpData();
    Task<string> ReadData(string key);
    Task WriteData(string key, string value);
}