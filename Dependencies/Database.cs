namespace Dependencies;

public class Database : IDatabase
{
    private readonly string _connectionString;
    private readonly IApplicationLogger _logger;
    private bool _isConnected;
    private readonly Dictionary<string, string> _data = new();

    public Database(string connectionStirng, IApplicationLogger logger)
    {
        _connectionString = connectionStirng;
        _logger = logger;
    }

    public async Task Connect()
    {
        await Task.Delay(2500);
        _isConnected = true;
        _logger.LogInfo($"{DateTime.UtcNow} - Connected to Database.", ConsoleColor.Magenta);
    }

    public async Task Disconnect()
    {
        await Task.Delay(2500);
        _isConnected = false;
        _logger.LogInfo($"{DateTime.UtcNow} - Disconnected from Database.", ConsoleColor.Magenta);
    }

    public async Task<List<string>> DumpData()
    {
        if (!_isConnected)
            throw new NotSupportedException("Cannot read from database without open connection");

        await Task.Delay(2000);

        try
        {
            return _data.Values.Select(v => v).ToList();
        }
        catch (KeyNotFoundException)
        {
            return new();
        }
    }

    public async Task<string> ReadData(string key)
    {
        if (!_isConnected)
            throw new NotSupportedException("Cannot read from database without open connection");

        if (string.IsNullOrWhiteSpace(key))
            return "";

        await Task.Delay(500);

        try
        {
            return _data[key];
        }
        catch (KeyNotFoundException)
        {
            return "";
        }
    }

    public async Task WriteData(string key, string value)
    {
        if (!_isConnected)
            throw new NotSupportedException("Cannot write to database without open connection");

        if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
            return;

        await Task.Delay(250);

        _data[key] = value;
    }
}