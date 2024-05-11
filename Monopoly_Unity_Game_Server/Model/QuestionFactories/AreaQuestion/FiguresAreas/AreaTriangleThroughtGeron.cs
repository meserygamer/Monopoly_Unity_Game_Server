using Monopoly_Unity_Game_Server.Model.AreaQuestion;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas
{
    public class AreaTriangleThroughtGeron : IFigureAreaQuestion
    {
        public AreaTriangleThroughtGeron(Random random)
        {
            _random = random;
        }


        private Random _random;

        private double _a = 0;
        private double _b = 0;
        private double _c = 0;


        public string QuestionText => "Найдите площадь треугольника, если сторона a = " + _a + ", сторона b = " + _b + ", а сторона c = " + _c;

        public double FigureArea
        {
            get
            {
                double p = (_a + _b + _c) / 2;
                return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
            }
        }

        public void GenerateFigure()
        {
            _a = (double)_random.Next(1, 10);
            _b = (double)_random.Next(1, 10);
            double baMin = _b - _a;
            double abMin = _a - _b;
            _c = (double)_random.Next((baMin < abMin)? (int)abMin : (int)baMin, (int)_a + (int)_b);
        }
    }
}
