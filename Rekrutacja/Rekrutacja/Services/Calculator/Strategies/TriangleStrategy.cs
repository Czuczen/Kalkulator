using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Services.Calculator.Strategies
{
    public class TriangleStrategy : IShapeStrategy
    {
        public double CalculateArea(double a, double b) => 0.5 * a * b;
    }
}
