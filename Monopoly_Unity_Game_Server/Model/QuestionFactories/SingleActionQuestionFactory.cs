using Monopoly_Unity_Game_Server.Model;

namespace Monopoly_Unity_Game_Server;

/// <summary>
/// Генератор примеров вида x (+|-|*|/) y
/// </summary>
public class SingleActionQuestionFactory : IQuestionFactory
{
    public SingleActionQuestionFactory(Random random)
    {
        _random = random;
    }


    private Random _random;


    public Question GetQuestion()
    {
        Example example = GetExample();
        return new Question() { QuestionText = example.ExampleInString(), Answer = example.GetExampleResult() };
    }

    public Example GetExample()
    {
        ActionType exampleActionType = (ActionType)_random.Next(0, 4);
        SimpleNumberAsExample firstNumber  = new SimpleNumberAsExample(_random.Next(10, 1000));

        SimpleNumberAsExample secondNumber;
        if (exampleActionType == ActionType.Addition || exampleActionType == ActionType.Subtraction)                        //Если числа складываются или вычитаются, то второе число 2 или 3 значное, иначе 1 значное
            secondNumber = new SimpleNumberAsExample(_random.Next(10, 1000));
        else
            secondNumber = new SimpleNumberAsExample(_random.Next(1, 10));
        return new ExampleWithTwoArguments(firstNumber, secondNumber, exampleActionType);
    }
}
