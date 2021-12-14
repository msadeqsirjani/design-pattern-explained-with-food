using CreationalPattern.Prototype;
using CreationalPattern.Prototype.DiningRoomIcons.Chairs;
using CreationalPattern.Prototype.DiningRoomIcons.Tables;
using Dependencies;

ConsoleLogger logger = new();

logger.LogInfo("Welcome Dining Room Designer!");

CafeChairIcon chairPrototype = new();
RestaurantTableIcon tablePrototype = new();
PrototypeFactory roomDesigner = new(tablePrototype, chairPrototype, logger);

var chair1 = roomDesigner.CloneChair();
var chair2 = roomDesigner.CloneChair();
var chair3 = roomDesigner.CloneChair();
var chair4 = roomDesigner.CloneChair();
var table1 = roomDesigner.CloneTable();

var chairs = new List<IChairIcon> { chair1, chair2, chair3, chair4 };

var numberOfSeatCushionsToOrder = chairs.Count(chair => chair.HasSeatCushions);
var numberOfTableLegs = table1.GetTableNumberOfLegs();
var tableShape = table1.GetTableTopShape();

logger.LogInfo($"Current room design state includes a {tableShape}-shaped " +
    $"table with {numberOfTableLegs} legs.");

if (numberOfSeatCushionsToOrder == 0)
{
    logger.LogInfo("No chairs in the design take seat cushions.");
}

logger.LogInfo("Chair Prototype Object HashCode:");
logger.LogInfo(chairPrototype.GetHashCode().ToString(), ConsoleColor.Yellow);

logger.LogInfo("Chair Object HashCodes:");
logger.LogInfo(chair1.GetHashCode().ToString(), ConsoleColor.Yellow);
logger.LogInfo(chair2.GetHashCode().ToString(), ConsoleColor.Yellow);
logger.LogInfo(chair3.GetHashCode().ToString(), ConsoleColor.Yellow);
logger.LogInfo(chair4.GetHashCode().ToString(), ConsoleColor.Yellow);