namespace StructuralPattern.Facade.GroceryStoreManager;

public class ReportGenerator : IReportGenerator
{
    public struct Report
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }

    public string GenerateReportLog(Report report)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Generating Report | {report.Title}");
        Console.ResetColor();
        return $"{report.Description}_{DateTime.UtcNow}";
    }
}