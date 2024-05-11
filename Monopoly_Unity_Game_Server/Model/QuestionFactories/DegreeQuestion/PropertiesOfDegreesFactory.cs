namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.DegreeQuestion
{
    public class PropertiesOfDegreesFactory : IQuestionFactory
    {
        public PropertiesOfDegreesFactory(Random random)
        {
            _random = random;

            _possibleProperties = new List<Func<Example>>()
            {
                GenerateExampleOnPropertiesOfDegreesWithSameExponentAddition,
                GenerateExampleOnPropertiesOfDegreesWithSameExponentSubtraction,
                GenerateExampleOnPropertiesOfDegreesWithSameExponentMultiply
            };
        }


        private Random _random;

        private readonly List<Func<Example>> _possibleProperties;


        public Question GetQuestion()
        {
            Question question = new Question();

            Example example = _possibleProperties[_random.Next(0, 3)].Invoke();

            question.QuestionText = example.ExampleInString();
            question.Answers = [example.GetExampleResult()];

            return question;
        }

        private double GenerateDegreeBase() => _random.Next(1, 30);

        private double GenerateExponentResult(double degreeBase)
        {
            if (degreeBase <= 2)
                return _random.Next(0, 11);
            else if (degreeBase <= 5)
                return _random.Next(0, 6);
            else
                return _random.Next(0, 3);
        }

        private Example GenerateExampleOnPropertiesOfDegreesWithSameExponentAddition()
        {
            double degreeBase = GenerateDegreeBase();

            double exponentResult = GenerateExponentResult(degreeBase);

            Example FirstNumber = new SimpleNumberAsExample(_random.Next(-20, 21));
            Example SecondNumber = new SimpleNumberAsExample(exponentResult - Convert.ToDouble(FirstNumber.GetExampleResult()));

            Example FirstExamplePart = new ExampleWithTwoArguments(new SimpleNumberAsExample(degreeBase), FirstNumber, ActionType.Exponentiation);
            Example SecondExamplePart = new ExampleWithTwoArguments(new SimpleNumberAsExample(degreeBase), SecondNumber, ActionType.Exponentiation);

            Example finalExample = new ExampleWithTwoArguments(FirstExamplePart, SecondExamplePart, ActionType.Multiplication);

            return new UserExample(Math.Pow(degreeBase, exponentResult), finalExample.ExampleInString());
        }

        private Example GenerateExampleOnPropertiesOfDegreesWithSameExponentSubtraction()
        {
            double degreeBase = GenerateDegreeBase();

            double exponentResult = GenerateExponentResult(degreeBase);

            Example FirstNumber = new SimpleNumberAsExample(_random.Next(-20, 21));
            Example SecondNumber = new SimpleNumberAsExample(Convert.ToDouble(FirstNumber.GetExampleResult()) - exponentResult);

            Example FirstExamplePart = new ExampleWithTwoArguments(new SimpleNumberAsExample(degreeBase), FirstNumber, ActionType.Exponentiation);
            Example SecondExamplePart = new ExampleWithTwoArguments(new SimpleNumberAsExample(degreeBase), SecondNumber, ActionType.Exponentiation);

            Example finalExample = new ExampleWithTwoArguments(FirstExamplePart, SecondExamplePart, ActionType.Division);

            return new UserExample(Math.Pow(degreeBase, exponentResult), finalExample.ExampleInString());
        }

        private Example GenerateExampleOnPropertiesOfDegreesWithSameExponentMultiply()
        {
            double degreeBase = _random.Next(1, 6);
            double exponentResult = _random.Next(1, 6);

            double firstExponent = _random.Next(1, 6);
            double secondExponent = exponentResult / firstExponent;

            Example firstPartExample = new ExampleWithTwoArguments(new SimpleNumberAsExample(degreeBase), new SimpleNumberAsExample(firstExponent), ActionType.Exponentiation);

            Example finalExample = new ExampleWithTwoArguments(firstPartExample, new SimpleNumberAsExample(secondExponent), ActionType.Exponentiation);

            return new UserExample(Math.Pow(degreeBase, exponentResult), finalExample.ExampleInString());
        }
    }
}
