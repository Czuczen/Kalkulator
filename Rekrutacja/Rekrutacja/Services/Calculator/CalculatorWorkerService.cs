using Rekrutacja.Data.Repositories;
using Rekrutacja.Helpers;
using Rekrutacja.Parameters;
using Rekrutacja.Services.Calculator.Shape;
using Soneta.Business;
using Soneta.Kadry;
using Soneta.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rekrutacja.Services.Calculator
{
    public class CalculatorWorkerService : ICalculatorWorkerService
    {
        private readonly IRepository<Pracownik, KadryModule> _repository;
        private readonly IShapeCalculationService _shapeCalculationService;


        public CalculatorWorkerService(
            IRepository<Pracownik, KadryModule> repository, 
            IShapeCalculationService shapeCalculationService)
        {
            _repository = repository;
            _shapeCalculationService = shapeCalculationService;
        }


        public void ExecuteAction(CalculatorWorkerParameters parametry)
        {
            var selectedEmployees = _repository.GetSelected().ToList();
            
            double wynik = default;
            try
            {
                int zmiennaA = StringToIntParser.Parse(parametry.VariableA);
                int zmiennaB = StringToIntParser.Parse(parametry.VariableB);
                wynik = _shapeCalculationService.CalculateArea(parametry.Figure, zmiennaA, zmiennaB);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Calculate error: {ex.Message}");
            }

            var toUpdate = new Dictionary<string, object>
            {
                ["Wynik"] = wynik,
                ["DataObliczen"] = Date.Today // DateTime.UtcNow.Date ?
            };

            _repository.Save(selectedEmployees, toUpdate);
        }
    }
}
