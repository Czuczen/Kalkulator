//using Moq;
//using NUnit.Framework;
//using Rekrutacja.Data.UnitOfWork;
//using Soneta.Business;

//namespace Rekrutacja.Tests.UnitOfWork
//{
//    public class UnitOfWorkTests
//    {
//        private Mock<Session> _mockSession;
//        private Data.UnitOfWork.UnitOfWork _unitOfWork;

//        [SetUp]
//        public void Setup()
//        {
//            _mockSession = new Mock<Session>();
//            _unitOfWork = new Data.UnitOfWork.UnitOfWork(_mockSession.Object);
//        }

//        [Test]
//        public void BeginTransaction_CreatesTransaction_Successfully()
//        {
//            // Act
//            _unitOfWork.BeginTransaction();

//            // Assert
//            _mockSession.Verify(s => s.Logout(true), Times.Once);
//        }

//        [Test]
//        public void Commit_TransactionCommitted_Successfully()
//        {
//            // Arrange
//            var mockTransaction = new Mock<ITransaction>();
//            _mockSession.Setup(s => s.Logout(true)).Returns(mockTransaction.Object);

//            // Act
//            _unitOfWork.BeginTransaction();
//            _unitOfWork.Commit();

//            // Assert
//            mockTransaction.Verify(t => t.CommitUI(), Times.Once);
//        }

//        [Test]
//        public void Save_SessionSaved_Successfully()
//        {
//            // Act
//            _unitOfWork.Save();

//            // Assert
//            _mockSession.Verify(s => s.Save(), Times.Once);
//        }
//    }
//}
