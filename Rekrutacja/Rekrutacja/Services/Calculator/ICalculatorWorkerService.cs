using Rekrutacja.Parameters;
using Soneta.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekrutacja.Services.Calculator
{
    public interface ICalculatorWorkerService
    {
        void ExecuteAction(CalculatorWorkerParameters parametry);
    }
}
