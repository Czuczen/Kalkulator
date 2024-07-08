using Rekrutacja.Data.Repositories;
using Rekrutacja.Data.UnitOfWork;
using Rekrutacja.Enums;
using Rekrutacja.Helpers;
using Rekrutacja.Parameters;
using Rekrutacja.Services.Calculator;
using Rekrutacja.Services.Calculator.Shape;
using Rekrutacja.Workers.Calculator;
using Soneta.Business;
using Soneta.Kadry;
using Soneta.Types;
using System;

[assembly: Worker(typeof(CalculatorWorker), typeof(Pracownicy))]
namespace Rekrutacja.Workers.Calculator
{
    public class CalculatorWorker
    {
        private readonly ICalculatorWorkerService _workerService;
        private readonly CalculatorWorkerParameters _parameters;


        public CalculatorWorker(Context context, CalculatorWorkerParameters parameters)
        {
            _parameters = parameters;
            _workerService = new CalculatorWorkerService(
                    new Repository<Pracownik, KadryModule>(
                        context, 
                        new SessionParameters(false, false, "ModyfikacjaPracownika")),
                    new ShapeCalculationService());
        }


        [Action("Kalkulator",
           Description = "Kalkulator pola figur geometrycznych",
           Priority = 10,
           Mode = ActionMode.ReadOnlySession,
           Icon = ActionIcon.Accept,
           Target = ActionTarget.ToolbarWithText)]
        public void WykonajAkcje()
        {
            _parameters.Validate();

            try
            {
                //System.Diagnostics.Debugger.Break();
                DebuggerSession.MarkLineAsBreakPoint();

                _workerService.ExecuteAction(_parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new InvalidOperationException("Coś poszło nie tak. Spróbuj ponownie");
            }
        }
    }
}
