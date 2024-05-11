﻿using Monopoly_Unity_Game_Server.Model.AreaQuestion;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas
{
    public class AreaTrapezoid : IFigureAreaQuestion
    {
        public AreaTrapezoid(Random random)
        {
            _random = random;
        }


        private Random _random;

        private double _a = 0;
        private double _b = 0;
        private double _h = 0;


        public string QuestionText => "Найдите площадь трапеции, если длина основания a = " + _a + ", длина основания b = " + _b + ", а высота = " + _h;

        public double FigureArea => ((_a + _b) / 2) * _h;

        public void GenerateFigure()
        {
            _a = (double)_random.Next(0, 25);
            _b = (double)_random.Next(0, 25);
            _h = (double)_random.Next(0, 25);
        }
    }
}
