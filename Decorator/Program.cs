using Dependencies;
using StructuralPattern.Decorator;
using StructuralPattern.Decorator.Notifications;

ConsoleLogger logger = new();

logger.LogInfo("Welcome to the Front-of-House Service!");

bool isEmailCustomer;
bool isSmsCustomer;

logger.LogInfo("-----------------------------------------------------------------");
logger.LogInfo("Do you want to be notified by email when your table is ready? (y/n)");
var emailOption = Console.ReadLine();

if (emailOption != null)
    switch (emailOption.ToLower())
    {
        case "y":
            logger.LogInfo("OK, we'll send you an email.");
            isEmailCustomer = true;
            break;
        case "n":
            isEmailCustomer = false;
            break;
        default:
            logger.LogInfo("Invalid option. please try again");
            return;
    }
else
{

    logger.LogInfo("Invalid option. please try again");
    return;
}

logger.LogInfo("-----------------------------------------------------------------");
logger.LogInfo("Do you want to be notified by text when your table is ready? (y/n)");

var smsOption = Console.ReadLine();

if (smsOption != null)
    switch (smsOption.ToLower())
    {
        case "y":
            logger.LogInfo("OK, we'll send you text.");
            isSmsCustomer = true;
            break;
        case "n":
            isSmsCustomer = false;
            break;
        default:
            logger.LogInfo("Invalid option. please try again");
            return;
    }
else
{

    logger.LogInfo("Invalid option. please try again");
    return;
}

logger.LogInfo("-----------------------------------------------------------------");

logger.LogInfo("Please wait while we arrange a table for you...");
Thread.Sleep(3000);

logger.LogInfo("Looks like we're just about ready...");
Thread.Sleep(1000);

Notifier notifier = new RestaurantIntercomNotifier();

if (isSmsCustomer)
{
    logger.LogInfo("Adding SMS");
    notifier = new SmsNotification(notifier, new Queue(logger));
}

if (isEmailCustomer)
{
    logger.LogInfo("Adding Email");
    notifier = new EmailNotification(notifier, new Emailer(logger));
}

await notifier.HandleTableReadyMessage();