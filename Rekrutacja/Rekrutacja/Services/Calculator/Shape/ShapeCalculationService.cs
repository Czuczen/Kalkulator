using Rekrutacja.Enums;
using Rekrutacja.Services.Calculator.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Services.Calculator.Shape
{
    public class ShapeCalculationService : IShapeCalculationService
    {
        private readonly Dictionary<Figure, IShapeStrategy> _strategies;

        public ShapeCalculationService()
        {
            _strategies = new Dictionary<Figure, IShapeStrategy>
            {
                { Figure.Kwadrat, new SquareStrategy() },
                { Figure.Prostokat, new RectangleStrategy() },
                { Figure.Trojkat, new TriangleStrategy() },
                { Figure.Kolo, new CircleStrategy() }
            };
        }

        public double CalculateArea(Figure figure, double a, double b)
        {
            if (!_strategies.ContainsKey(figure))
                throw new InvalidOperationException("Unknown figure.");

            return _strategies[figure].CalculateArea(a, b);
        }
    }
}
