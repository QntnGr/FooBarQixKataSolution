using System.Text;

namespace ApplicationFooBarQix;


public class NumberInterpreter : INumberInterpreter
{
    private ulong InputNumber { get; set; }
    private string OutputExpression { get; set; }

    public NumberInterpreter(string number)
    {
        if (ulong.TryParse(number, out ulong numberLong))
        { 
            InputNumber = numberLong;
            OutputExpression = string.Empty;
        }
        else
        {
            InputNumber = 0;
            OutputExpression = "Ce n'est pas un nombre valide.";
        }
    }

    public void ComputeNumber()
    {
        var rslt = new StringBuilder();
        if(InputNumber != 0)
        {
            foreach (var expression in Expressions.ExpressionDictionary)
            {
                if(expression.Key != '0')
                {
                    rslt.Append(GetDivisibility(expression, InputNumber));
                }
            }
            rslt.Append(GetContainedChar(InputNumber));

            if (rslt.Length == 0 || rslt.ToString().Distinct().Count() == 1)
            {
                OutputExpression = InputNumber.ToString().Replace("0", "*");
            }
            else
            {
                OutputExpression = rslt.ToString();
            }
        }
    }

    public string GetOutputExpression()
    {
        return OutputExpression;
    }

    private string GetDivisibility(KeyValuePair<char, string> keyValuePair, ulong number)
    {
        ulong.TryParse(keyValuePair.Key.ToString(), out ulong keyValue);
        return number % keyValue == 0 ? keyValuePair.Value : string.Empty;
    }

    private static string GetContainedChar(ulong number)
    {
        var rslt = new StringBuilder();
        foreach (char c in number.ToString())
        {
            if(Expressions.ExpressionDictionary.TryGetValue(c, out string value))
            {
                rslt.Append(value);
            }
        }

        return rslt.ToString();
    }

}
