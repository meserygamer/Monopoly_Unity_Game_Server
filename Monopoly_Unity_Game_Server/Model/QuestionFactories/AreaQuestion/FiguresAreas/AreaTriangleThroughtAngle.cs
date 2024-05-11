using Monopoly_Unity_Game_Server.Model.AreaQuestion;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas
{
    public class AreaTriangleThroughtAngle : IFigureAreaQuestion
    {
        public AreaTriangleThroughtAngle(Random random)
        {
            _random = random;
        }

        private readonly int[] POSSIBLE_ANGLES = [30, 60, 45]; 


        private Random _random;

        private double _a = 0;
        private double _b = 0;
        private double _alphaAngle = 0;


        public string QuestionText => 
            "Найдите площадь треугольника, если сторона a = " + _a + ", сторона b = " + _b + ", а угол между ними alpha = " + _alphaAngle + "°";

        public double FigureArea => 0.5 * _a * _b * Math.Sin((_alphaAngle / 180D) * Math.PI);

        public void GenerateFigure()
        {
            _a = (double)_random.Next(0, 50) / 2;
            _b = (double)_random.Next(0, 50) / 2;
            _alphaAngle = POSSIBLE_ANGLES[_random.Next(0, POSSIBLE_ANGLES.Length)];
        }
    }
}
