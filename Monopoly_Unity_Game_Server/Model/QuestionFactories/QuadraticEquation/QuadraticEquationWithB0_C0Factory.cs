using System;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories
{
    public class QuadraticEquationWithB0_C0Factory : IQuestionFactory
    {
        public QuadraticEquationWithB0_C0Factory(Random random)
        {
            _random = random;
        }


        private readonly double[] POSSIBLE_DISCRIMINANT_VALUES = [0, 1, 4, 9, 16, 25, 36, 49, 64, 81, 100];


        private Random _random;


        public Question GetQuestion()
        {
            Question question = new Question();

            double aArgument, bArgument, cArgument;
            if (_random.Next(0, 2) == 0)
                GenerateQuadraticEquationArgs_B0(out aArgument, out bArgument, out cArgument);
            else
                GenerateQuadraticEquationArgs_C0(out aArgument, out bArgument, out cArgument);

            question.QuestionText = GenerateQuadraticEquationString(aArgument, bArgument, cArgument);
            question.Answers = CalculateQuadraticEquationResult(aArgument, bArgument, cArgument);

            return question;
        }

        private void GenerateQuadraticEquationArgs_B0(out double aArgument, out double bArgument, out double cArgument)
        {
            aArgument = 0;
            while (aArgument == 0)
                aArgument = _random.Next(-10, 11);
            bArgument = 0;
            double Discriminant = POSSIBLE_DISCRIMINANT_VALUES[_random.Next(0, POSSIBLE_DISCRIMINANT_VALUES.Length)];
            cArgument = -Discriminant / (4 * aArgument);
        }

        private void GenerateQuadraticEquationArgs_C0(out double aArgument, out double bArgument, out double cArgument)
        {
            aArgument = 0;
            while (aArgument == 0)
                aArgument = _random.Next(-10, 11);
            cArgument = 0;
            double Discriminant = POSSIBLE_DISCRIMINANT_VALUES[_random.Next(0, POSSIBLE_DISCRIMINANT_VALUES.Length)];
            bArgument = Math.Sqrt(Discriminant + (4 * aArgument * cArgument));
        }

        private string GenerateQuadraticEquationString(double aArgument, double bArgument, double cArgument) => 
            aArgument + "x^2 + " + ((bArgument != 0)? bArgument + "x" : "") + ((cArgument != 0) ? " + " + cArgument + " = 0" : " = 0");

        private string[] CalculateQuadraticEquationResult(double aArgument, double bArgument, double cArgument)
        {
            string[] result;
            double Discimenant = Math.Pow(bArgument, 2) - 4 * aArgument * cArgument;
            if (Discimenant == 0)
                result = new string[]
                {
                    (-bArgument / (2 * aArgument)).ToString()
                };
            else
                result = new string[]
                {
                    ((-bArgument + Math.Sqrt(Discimenant)) / (2 * aArgument)).ToString(),
                    ((-bArgument - Math.Sqrt(Discimenant)) / (2 * aArgument)).ToString()
                };
            return result;
        }
    }
}
