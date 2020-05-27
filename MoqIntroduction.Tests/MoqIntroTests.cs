using Moq;
using MoqIntroduction.Database;
using System;
using Xunit;

namespace MoqIntroduction.Tests
{
    public class MoqIntroTests
    {
        private MoqIntro _moqIntro;

        private Mock<IDatabase> _db;

        public MoqIntroTests()
        {
            _db = new Mock<IDatabase>();

            _moqIntro = new MoqIntro(_db.Object);
        }

        [Fact]
        public void GetSumOfValues_ShouldReturnSum()
        {
            // Arrange
            _db.Setup(x => x.GetValue(1)).Returns(2);
            _db.Setup(x => x.GetValue(2)).Returns(3);

            // Act
            var sum = _moqIntro.GetSumOfValues(1, 2);

            // Assert
            Assert.Equal(5, sum);
        }

        [Fact]
        public void GetSumOfValuesByReference_ShouldAssignSum()
        {
            var expectedModel = new MyModel();

            // Arrange
            _db
                .Setup(x => x.TryGetValue(It.IsAny<int>(), It.IsAny<MyModel>()))
                .Callback<int, MyModel>((id, model) => 
                {
                    model.Id = id;
                    model.Value = id;
                })
                .Returns(true);

            // Act
            var sum = _moqIntro.GetSumByReference(1, 2);

            // Assert
            Assert.Equal(3, sum);
        }

        [Fact]
        public void AddValue_ShouldInsertValueIntoDatabase()
        {
            // Arrange

            // Act
            _moqIntro.AddValue(10);

            // Assert
            _db.Verify(x => x.InsertValue(10), Times.Once);
        }
    }

    #region Spoilers

    #region Setup
    //private readonly MoqIntro _moqIntro;

    //private readonly Mock<IDatabase> _db;


    //_db = new Mock<IDatabase>();

    //_moqIntro = new MoqIntro(_db.Object);
    #endregion

    #region GetSumOfValues_ShouldReturnSum
    //_db.Setup(x => x.GetValue(1)).Returns(1);
    //_db.Setup(x => x.GetValue(2)).Returns(2);
    #endregion

    #region GetSumOfValuesByReference_ShouldAssignSum
    //_db
    //    .Setup(x => x.TryGetValue(It.IsAny<int>(), It.IsAny<MyModel>()))
    //            .Callback<int, MyModel>((i, m) =>
    //            {
    //                m.Id = i;
    //                m.Value = i;
    //            })
    //            .Returns(true);
    #endregion

    #region AddValue_ShouldInsertValueIntoDatabase
    //_db.Verify(x => x.InsertValue(10), Times.Once);
    #endregion

    #endregion
}
