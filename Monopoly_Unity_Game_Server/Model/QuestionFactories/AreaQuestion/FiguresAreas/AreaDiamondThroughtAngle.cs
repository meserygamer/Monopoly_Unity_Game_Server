using Monopoly_Unity_Game_Server.Model.AreaQuestion;

namespace Monopoly_Unity_Game_Server.Model.QuestionFactories.AreaQuestion.FiguresAreas
{
    public class AreaDiamondThroughtAngle : IFigureAreaQuestion
    {
        public AreaDiamondThroughtAngle(Random random)
        {
            _random = random;
        }

        private readonly int[] POSSIBLE_ANGLES = [30, 60, 45]; 


        private Random _random;

        private double _a1 = 0;
        private double _alphaAngle = 0;


        public string QuestionText => 
            "Найдите площадь ромба, если сторона a1 = " + _a1 + ", сторона a2 = " + _a1 + ", а угол между ними alpha = " + _alphaAngle + "°";

        public double FigureArea => Math.Pow(_a1, 2) * Math.Sin((_alphaAngle / 180D) * Math.PI);

        public void GenerateFigure()
        {
            _a1 = (double)_random.Next(0, 50) / 2;
            _alphaAngle = POSSIBLE_ANGLES[_random.Next(0, POSSIBLE_ANGLES.Length)];
        }
    }
}
