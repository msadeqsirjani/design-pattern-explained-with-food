using Dependencies.PaymentProcessing;
using StructuralPattern.Bridge.Vendors;

Console.WriteLine("Welcome to the Farmer's Market!");
Console.OutputEncoding = System.Text.Encoding.UTF8;

const string organicGardens = "Organic Gardens";
const string olsenFarm = "Olsen Farm";
const string andersenFarm = "Andersen Farm";
const string pleasantValley = "Pleasant Valley";
const string hillsideRanch = "Hillside Ranch";

CreditCardProcessor creditCardProcessor = new();
GiftCardProcessor giftCardProcessor = new();

VegetableFarmer booth1 = new(creditCardProcessor);
VegetableFarmer booth2 = new(giftCardProcessor);
CattleFarmer booth3 = new(creditCardProcessor);
Florist booth4 = new(creditCardProcessor);
Florist booth5 = new(giftCardProcessor);

booth1.ProcessPayment(10.00m, organicGardens);
booth1.ProcessPayment(12.00m, organicGardens);
booth1.ProcessPayment(1.50m, organicGardens);

booth2.ProcessPayment(15.50m, olsenFarm);

booth3.ProcessPayment(5.00m, andersenFarm);
booth3.ProcessPayment(5.00m, andersenFarm);
booth3.ProcessPayment(5.00m, andersenFarm);

booth4.ProcessPayment(12.00m, pleasantValley);
booth4.ProcessPayment(11.00m, pleasantValley);

booth5.ProcessPayment(12.00m, hillsideRanch);