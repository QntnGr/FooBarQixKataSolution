
using ApplicationFooBarQix;

while (true)
{
    Console.Write("Entrer le nombre à calculer: ");

    string userInput = Console.ReadLine();

    if (int.TryParse(userInput, out int number))
    {
        var interpreter = new NumberInterpreter(number);
        interpreter.ComputeNumber();

        Console.WriteLine($"La valeur traduite est : {interpreter.GetOutputExpression()}");
    }
    else
    {
        Console.WriteLine("Ce n'est pas un nombre valide.");
    }
}