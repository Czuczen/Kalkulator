using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Services.Calculator.Strategies
{
    public class SquareStrategy : IShapeStrategy
    {
        public double CalculateArea(double a, double b) => a * a;
    }
}
