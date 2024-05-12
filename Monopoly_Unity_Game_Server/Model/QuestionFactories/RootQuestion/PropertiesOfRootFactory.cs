﻿using System.Collections;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.RootQuestion
{
    public class PropertiesOfRootFactory : IQuestionFactory
    {
        public PropertiesOfRootFactory(Random random)
        {
            _random = random;

            _listForSquareRoot = new List<double>();
            foreach (var i in Enumerable.Range(1, 20))
            {
                _listForSquareRoot.Add(Math.Pow(i, 2));
            }

            _listForCubeRoot = new List<double>();
            foreach (var i in Enumerable.Range(-10, 21))
            {
                _listForCubeRoot.Add(Math.Pow(i, 3));
            }

            _possibleProperties = new List<Func<Example>>
            {
                GenerateExampleOnProperty_1,
                GenerateExampleOnProperty_2,
                GenerateExampleOnProperty_3,
                GenerateExampleOnProperty_4,
                GenerateExampleOnProperty_5
            };
        }

        private List<double>? _listForSquareRoot = null;
        private List<double>? _listForCubeRoot = null;

        private Random _random;

        private readonly List<Func<Example>> _possibleProperties;


        public Question GetQuestion()
        {
            Question question = new Question();
            
            Example example = _possibleProperties[_random.Next(0, _possibleProperties.Count)].Invoke();

            question.Answers = [example.GetExampleResult()];
            question.QuestionText = example.ExampleInString();

            return question;
        }

        private List<int> FindAllDivisioners(int Number)
        {
            List<int> Divioners = new List<int>();
            for (int i = 1; i * i < Number; i++)
                if (Number % i == 0) Divioners.AddRange([i, Number / i]);
            return Divioners;
        }

        /// <summary>
        /// Свойство n √ (a ^ n) = a
        /// </summary>
        /// <returns>Экземпляр Example для сгенерированного примера</returns>
        private Example GenerateExampleOnProperty_1()
        {
            double rootBase = _random.Next(-100, 101);
            double rootExponent = _random.Next(2, 30);
            Example firstPart = new ExampleWithTwoArguments(new SimpleNumberAsExample(rootBase), new SimpleNumberAsExample(rootExponent), ActionType.Exponentiation);
            Example finalExample = new ExampleWithTwoArguments(new SimpleNumberAsExample(rootExponent), firstPart, ActionType.TakingRoot);
            return new UserExample(rootBase, finalExample.ExampleInString());
        }

        /// <summary>
        /// Свойство  (n √ a) ^ n = a
        /// </summary>
        /// <returns>Экземпляр Example для сгенерированного примера</returns>
        private Example GenerateExampleOnProperty_2()
        {
            double rootBase = _random.Next(-100, 101);
            double rootExponent = _random.Next(2, 30);
            Example firstPart = new ExampleWithTwoArguments(new SimpleNumberAsExample(rootExponent), new SimpleNumberAsExample(rootBase), ActionType.TakingRoot);
            Example finalExample = new ExampleWithTwoArguments(firstPart, new SimpleNumberAsExample(rootExponent), ActionType.Exponentiation);
            return new UserExample(rootBase, finalExample.ExampleInString());
        }

        /// <summary>
        /// Свойство  n√(ab) = n√a * n√b
        /// </summary>
        /// <returns>Экземпляр Example для сгенерированного примера</returns>
        private Example GenerateExampleOnProperty_3()
        {
            double exponent = _random.Next(2,4);

            double aArgument = 0;
            double bArgument = 0;
            switch(exponent)
            {
                case 2:
                    aArgument = _listForSquareRoot[_random.Next(0, _listForSquareRoot.Count)];
                    bArgument = _listForSquareRoot[_random.Next(0, _listForSquareRoot.Count)];
                    break;
                case 3:
                    aArgument = _listForCubeRoot[_random.Next(0, _listForCubeRoot.Count)];
                    bArgument = _listForCubeRoot[_random.Next(0, _listForCubeRoot.Count)];
                    break;
            }

            Example exampleFirstPart = new ExampleWithTwoArguments(new SimpleNumberAsExample(aArgument), new SimpleNumberAsExample(bArgument), ActionType.Multiplication);
            Example finalExample = new ExampleWithTwoArguments(new SimpleNumberAsExample(exponent), exampleFirstPart, ActionType.TakingRoot);

            return finalExample;
        }

        /// <summary>
        /// Свойство n√(a/b) = (n√a)/(n√b)
        /// </summary>
        /// <returns>Экземпляр Example для сгенерированного примера</returns>
        private Example GenerateExampleOnProperty_4()
        {
            double exponent = _random.Next(2, 4);

            double aArgument = 0;
            double bArgument = 0;
            switch (exponent)
            {
                case 2:
                    aArgument = _listForSquareRoot[_random.Next(0, _listForSquareRoot.Count)];
                    bArgument = _listForSquareRoot[_random.Next(0, _listForSquareRoot.Count)];
                    break;
                case 3:
                    aArgument = _listForCubeRoot[_random.Next(0, _listForCubeRoot.Count)];
                    bArgument = _listForCubeRoot[_random.Next(0, _listForCubeRoot.Count)];
                    break;
            }

            Example exampleFirstPart = new ExampleWithTwoArguments(new SimpleNumberAsExample(aArgument), new SimpleNumberAsExample(bArgument), ActionType.Division);
            Example finalExample = new ExampleWithTwoArguments(new SimpleNumberAsExample(exponent), exampleFirstPart, ActionType.TakingRoot);

            return finalExample;
        }

        /// <summary>
        /// Свойство n√a * n√b = n√(ab)
        /// </summary>
        /// <returns>Экземпляр Example для сгенерированного примера</returns>
        private Example GenerateExampleOnProperty_5()
        {
            double exponent = _random.Next(2, 4);

            double sumArguments = 0;
            double aArgument = 0;
            double bArgument = 0;
            List<int> divioners = null;
            switch (exponent)
            {
                case 2:
                    sumArguments = _listForSquareRoot[_random.Next(0, _listForSquareRoot.Count)];
                    divioners = FindAllDivisioners((int)sumArguments);
                    aArgument = divioners[_random.Next(0, divioners.Count)];
                    bArgument = sumArguments / aArgument;
                    break;
                case 3:
                    sumArguments = _listForCubeRoot[_random.Next(11, _listForCubeRoot.Count)];
                    divioners = FindAllDivisioners((int)sumArguments);
                    aArgument = divioners[_random.Next(0, divioners.Count)];
                    bArgument = sumArguments / aArgument;
                    break;
            }

            Example exampleFirstPart = new ExampleWithTwoArguments(new SimpleNumberAsExample(exponent), new SimpleNumberAsExample(aArgument), ActionType.TakingRoot);
            Example exampleSecondPart = new ExampleWithTwoArguments(new SimpleNumberAsExample(exponent), new SimpleNumberAsExample(bArgument), ActionType.TakingRoot);
            Example exampleFinal = new ExampleWithTwoArguments(exampleFirstPart, exampleSecondPart, ActionType.Multiplication);

            return new UserExample(Math.Pow(sumArguments, 1 / exponent), exampleFinal.ExampleInString());
        }
    }
}
