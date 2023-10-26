
using ApplicationFooBarQix;

while (true)
{
    Console.Write("Entrer le nombre à calculer: ");

    var interpreter = new NumberInterpreter(Console.ReadLine());
    interpreter.ComputeNumber();
    Console.WriteLine($"La valeur traduite est : {interpreter.GetOutputExpression()}");
}