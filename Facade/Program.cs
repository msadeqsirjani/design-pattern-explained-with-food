using StructuralPattern.Facade;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Welcome to the Grocery Reporting System");

var reporter = new DailyReporter();

reporter.KickOffProduceReport();