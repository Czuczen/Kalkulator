using NUnit.Framework;
using Moq;
using Rekrutacja.Data.Repositories;
using Rekrutacja.Data.UnitOfWork;
using Rekrutacja.Parameters;
using Soneta.Business;
using Soneta.Kadry;
using System;
using System.Collections.Generic;
using System.Linq;
using Soneta.Types;

namespace Rekrutacja.Tests.Repositories
{
    public class RepositoryTests
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Repository<Pracownik, KadryModule> _repository;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _repository = new Repository<Pracownik, KadryModule>(TestSessionFixture.TestContext, new SessionParameters(false, false, "TestSession"));
        }

        [Test]
        public void GetSelected_NoItemsSelected_ThrowsInvalidOperationException()
        {
            // Arrange
            var mockContext = new Mock<Context>(TestSessionFixture.TestSession);
            mockContext.Setup(c => c.Contains(typeof(Pracownik[]))).Returns(false);
            var repository = new Repository<Pracownik, KadryModule>(mockContext.Object, new SessionParameters(false, false, "TestSession"));

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => repository.GetSelected());
            //Assert.Throws<InvalidOperationException>(() => _repository.GetSelected());
        }

        [Test]
        public void Save_Entities_SuccessfullySaved()
        {
            // Arrange
            var mockEntities = new List<Pracownik>
            {
                new Mock<Pracownik>().Object,
                new Mock<Pracownik>().Object
            };

            var updateObj = new Dictionary<string, object>
            {
                {"Wynik", 100},
                {"DataObliczen", Date.Today}
            };

            _mockUnitOfWork.Setup(uow => uow.GetEntity(It.IsAny<Pracownik>())).Returns((Pracownik e) => e);

            // Act
            _repository.Save(mockEntities, updateObj);

            // Assert
            _mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }
    }
}
