//using Moq;
//using NUnit.Framework;
//using Rekrutacja.Data.Repositories;
//using Rekrutacja.Enums;
//using Rekrutacja.Helpers;
//using Rekrutacja.Parameters;
//using Rekrutacja.Services.Calculator;
//using Rekrutacja.Services.Calculator.Shape;
//using Soneta.Business;
//using Soneta.Kadry;
//using Soneta.Types;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Rekrutacja.Tests.Services.Calculator
//{
//    public class CalculatorWorkerServiceTests
//    {
//        private Mock<IRepository<Pracownik, KadryModule>> _mockRepository;
//        private Mock<IShapeCalculationService> _mockShapeCalculationService;
//        private CalculatorWorkerService _service;

//        [SetUp]
//        public void Setup()
//        {
//            _mockRepository = new Mock<IRepository<Pracownik, KadryModule>>();
//            _mockShapeCalculationService = new Mock<IShapeCalculationService>();
//            _service = new CalculatorWorkerService(_mockRepository.Object, _mockShapeCalculationService.Object);
//        }

//        [Test]
//        public void ExecuteAction_ValidParameters_SavesCorrectResults()
//        {
//            // Arrange
//            var parameters = new CalculatorWorkerParameters(new Mock<Context>().Object)
//            {
//                Figure = Figure.Kwadrat,
//                VariableA = "4",
//                VariableB = "4"
//            };

//            var mockEmployees = new List<Pracownik>
//            {
//                new Mock<Pracownik>().Object,
//                new Mock<Pracownik>().Object
//            };

//            _mockRepository.Setup(r => r.GetSelected()).Returns(mockEmployees.AsQueryable());
//            _mockShapeCalculationService.Setup(s => s.CalculateArea(Figure.Kwadrat, 4, 4)).Returns(16);

//            // Act
//            _service.ExecuteAction(parameters);

//            // Assert
//            var expectedUpdateObj = new Dictionary<string, object>
//            {
//                { "Wynik", 16 },
//                { "DataObliczen", Date.Today }
//            };

//            _mockRepository.Verify(r => r.Save(It.Is<IEnumerable<Pracownik>>(e => e.Count() == mockEmployees.Count), expectedUpdateObj), Times.Once);
//        }

//        [Test]
//        public void ExecuteAction_InvalidVariableA_ThrowsFormatException()
//        {
//            // Arrange
//            var parameters = new CalculatorWorkerParameters(new Mock<Context>().Object)
//            {
//                Figure = Figure.Kwadrat,
//                VariableA = "invalid",
//                VariableB = "4"
//            };

//            // Act & Assert
//            Assert.Throws<FormatException>(() => _service.ExecuteAction(parameters));
//        }
//    }
//}
