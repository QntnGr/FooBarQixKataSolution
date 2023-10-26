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
                rslt.Append(GetDivisibilityByEnum(expression, InputNumber));
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

    private static string GetDivisibilityByEnum(KeyValuePair<int, string> keyValuePair, ulong number)
    {
        if (number % (ulong)keyValuePair.Key == 0)
        {
            return keyValuePair.Value;
        }
        return string.Empty;
    }

    private static string GetContainedChar(ulong number)
    {
        var rslt = new StringBuilder();
        foreach (char c in number.ToString())
        {
            foreach (var keyValuePair in Expressions.ExpressionDictionary)
            {
                if (c.ToString() == keyValuePair.Key.ToString())
                {
                    rslt.Append(keyValuePair.Value);
                }
            }
            if (c == '0')
            {
                rslt.Append('*');
            }
        }

        return rslt.ToString();
    }

}
