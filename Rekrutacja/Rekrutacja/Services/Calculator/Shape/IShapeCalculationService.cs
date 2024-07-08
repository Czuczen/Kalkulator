using Rekrutacja.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Services.Calculator.Shape
{
    public interface IShapeCalculationService
    {
        double CalculateArea(Figure figure, double a, double b);
    }
}
