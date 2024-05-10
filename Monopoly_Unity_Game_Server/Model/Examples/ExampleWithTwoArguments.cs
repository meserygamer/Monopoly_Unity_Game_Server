using System.Text;

namespace Monopoly_Unity_Game_Server.Model;

public class ExampleWithTwoArguments : Example
{
    public ExampleWithTwoArguments(Example FirstArg, Example SecondArg, ActionType actionType)
    {
        _firstArg = FirstArg;
        _secondArg = SecondArg;
        _actionType = actionType;
    }


    private Example _firstArg;
    private Example _secondArg;
    private ActionType _actionType;


    public override string GetExampleResult()
    {
        switch (_actionType)
        {
            case ActionType.Addition: return (Convert.ToDouble(_firstArg.GetExampleResult()) + Convert.ToDouble(_secondArg.GetExampleResult())).ToString();
            case ActionType.Subtraction: return (Convert.ToDouble(_firstArg.GetExampleResult()) - Convert.ToDouble(_secondArg.GetExampleResult())).ToString();
            case ActionType.Multiplication: return (Convert.ToDouble(_firstArg.GetExampleResult()) * Convert.ToDouble(_secondArg.GetExampleResult())).ToString();
            case ActionType.Division: return (Convert.ToDouble(_firstArg.GetExampleResult()) / Convert.ToDouble(_secondArg.GetExampleResult())).ToString();
            case ActionType.Exponentiation: return Math.Pow(Convert.ToDouble(_firstArg.GetExampleResult()), Convert.ToDouble(_secondArg.GetExampleResult())).ToString();
            case ActionType.TakingRoot: return Math.Pow(Convert.ToDouble(_firstArg.GetExampleResult()), 1 / Convert.ToDouble(_secondArg.GetExampleResult())).ToString();
            default: return "NAN";
        }
    }

    public override string ExampleInString()
    {
        StringBuilder exampleInString = new StringBuilder();
        
        if(_firstArg is SimpleNumberAsExample)
            exampleInString.Append(_firstArg.ExampleInString());
        else
            exampleInString.Append("(" + _firstArg.ExampleInString() + ")");

        switch (_actionType)
        {
            case ActionType.Addition: exampleInString.Append(" + "); break;
            case ActionType.Subtraction:  exampleInString.Append(" - "); break;
            case ActionType.Multiplication:  exampleInString.Append(" * "); break;
            case ActionType.Division:  exampleInString.Append(" / "); break;
            case ActionType.Exponentiation:  exampleInString.Append(" ^ "); break;
            case ActionType.TakingRoot:  exampleInString.Append(" √ "); break;
        }

        if(_secondArg is SimpleNumberAsExample)
            exampleInString.Append(_secondArg.ExampleInString());
        else
            exampleInString.Append("(" + _secondArg.ExampleInString() + ")");
        return exampleInString.ToString();
    }
}