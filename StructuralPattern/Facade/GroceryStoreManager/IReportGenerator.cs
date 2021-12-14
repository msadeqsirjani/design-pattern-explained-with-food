namespace StructuralPattern.Facade.GroceryStoreManager;

public interface IReportGenerator
{
    string GenerateReportLog(ReportGenerator.Report report);
}