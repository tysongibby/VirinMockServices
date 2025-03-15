using VirinMockServices;

VirinGenerator generator = new VirinGenerator();

Console.Write("Enter the number of VIRINs to generate: ");
if (int.TryParse(Console.ReadLine(), out int numberToCreate) && numberToCreate > 0)
{
    for (int i = 0; i < numberToCreate; i++)
    {
        string virin = generator.CreateVirin();
        Console.WriteLine(virin);
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter a positive integer.");
}
