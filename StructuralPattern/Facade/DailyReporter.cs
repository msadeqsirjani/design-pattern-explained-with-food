using Dependencies;
using StructuralPattern.Facade.GroceryStoreManager;

namespace StructuralPattern.Facade;

public class DailyReporter
{
    private readonly IFinanceCalculator _finance;
    private readonly IInventoryManager _inventory;
    private readonly IReportGenerator _report;
    private readonly IVendorNotifier _vendors;

    private readonly ISendEmails _mailer = new Emailer(new ConsoleLogger());
    private readonly IDatabase _database = new Database(Configuration.ConnectionString, new ConsoleLogger());
    private readonly IQueue _queue = new Queue(new ConsoleLogger());
    private readonly IRecipeApi _api = new RecipeApi(new ConsoleLogger());
    private readonly IApplicationLogger _logger;

    public DailyReporter()
    {
        _finance = new FinanceCalculator();
        _inventory = new InventoryManager(_mailer, _queue, _database, _api);
        _report = new ReportGenerator();
        _vendors = new VendorNotifier(_database, _mailer);
        _logger = new ConsoleLogger();
    }

    public void KickOffProduceReport()
    {
        _finance.CalculateMonthTotalRevenue();
        _inventory.ProcessCurrentInventoryReport();

        var vendors = _vendors.GetVendorsForDepartment("produce");

        foreach (var vendor in vendors)
        {
            _vendors.NotifyVendorOfCurrentStock(vendor);
            _finance.CalculateMonthTotalRevenueForVendor(vendor);
        }

        var report = new ReportGenerator.Report
        {
            Title = "Daily Produce Report",
            Description = "The daily produce report details..."
        };

        var reportLog = _report.GenerateReportLog(report);

        _logger.LogInfo(reportLog);
    }
}