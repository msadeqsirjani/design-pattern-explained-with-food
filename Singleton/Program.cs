using CreationalPattern.Singleton;

const string EastClient = "East";
const string WestClient = "West";
const string NorthClient = "North";
const string SouthClient = "South";

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Connecting to ingredients database...");

var eastClient = IngredientsDbConnectionPool.Instance;
var westClient = IngredientsDbConnectionPool.Instance;
var northClient = IngredientsDbConnectionPool.Instance;
var southClient = IngredientsDbConnectionPool.Instance;

await eastClient.Connect(EastClient);
await westClient.Connect(WestClient);
await northClient.Connect(NorthClient);
await southClient.Connect(SouthClient);

await northClient.Disconnect();

await southClient.Connect(SouthClient);

await northClient.Disconnect();
await northClient.Disconnect();
await northClient.Disconnect();
await northClient.Disconnect();

Console.WriteLine("Session complete!");