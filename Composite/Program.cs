using StructuralPattern.Composite;
using StructuralPattern.Composite.IndividualCartons;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Welcome to the Tea Carbonizer");

try
{
    Console.WriteLine("How many cartons of Green Tea would you like to add?");
    var greenCartonsQty = int.Parse(Console.ReadLine() ?? "0");

    Console.WriteLine("How many cartons of White Tea would you like to add?");
    var whiteCartonsQty = int.Parse(Console.ReadLine() ?? "0");

    MixAndMatchBundle customerBundle = new();

    Dictionary<TeaCarton, int> customerOrder = new()
    {
        { new GreenTeaCarton(), greenCartonsQty },
        { new WhiteTeaCarton(), whiteCartonsQty },
    };

    customerBundle.BuildBundle(customerOrder);

    var bundleServings = customerBundle.GetNumberOfServing();

    Console.WriteLine($"Your Mix and Match Bundle Contains {bundleServings} servings.");

}
catch (Exception)
{
    Console.WriteLine("Error cartonizing order. Please try again.");
}
