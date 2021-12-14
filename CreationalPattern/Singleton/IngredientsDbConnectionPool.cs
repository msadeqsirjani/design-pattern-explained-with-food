using Dependencies;

namespace CreationalPattern.Singleton;

public class IngredientsDbConnectionPool
{
    private readonly IApplicationLogger _logger;
    private readonly IDatabase _database;
    private int _connections = 0;

    private static readonly Lazy<IngredientsDbConnectionPool> _instance
        = new(() =>
        {
            ConsoleLogger logger = new();
            Database database = new(Configuration.ConnectionString, logger);
            return new IngredientsDbConnectionPool(database, logger);
        });

    private IngredientsDbConnectionPool(IDatabase database, IApplicationLogger logger)
    {
        _database = database;
        _logger = logger;
    }

    public static IngredientsDbConnectionPool Instance => _instance.Value;

    public async Task Connect(string client)
    {
        if (_connections >= Configuration.MaxConnection)
        {
            _logger.LogError($"ERROR - Cannot acquire new connection. Max connections of {Configuration.MaxConnection} is met or exceeded.");
            return;
        }

        _connections++;

        _logger.LogInfo($"Added connection to pool from ${client}", ConsoleColor.Blue);
        await _database.Connect();
    }

    public async Task Disconnect()
    {
        if (_connections <= 0)
        {
            _logger.LogInfo("There are no connections to close.", ConsoleColor.Blue);
            return;
        }

        _connections--;

        _logger.LogInfo($"Released connection. Now managing ({_connections}) open connections.", ConsoleColor.Blue);
        await _database.Disconnect();
    }
}