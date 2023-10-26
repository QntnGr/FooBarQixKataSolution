
using ApplicationFooBarQix;

while (true)
{
    Console.Write("Entrer le nombre à calculer: ");

    string userInput = Console.ReadLine();

    if (ulong.TryParse(userInput, out ulong number))
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