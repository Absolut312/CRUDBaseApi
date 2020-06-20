using System;
using System.Threading.Tasks;
using BaseApi.BLL.Core.FindById;
using BaseApi.PAL.Core;
using Moq;
using NUnit.Framework;
using Range = System.Range;

namespace BaseApi.Test.Core.FindById
{
    [TestFixture]
    public class BaseFindByIdServiceTest
    {
        private BaseFindByIdService<BaseModel> _baseFindByIdService;

        [SetUp]
        public void Setup()
        {
            var mockBaseFindByIdRepository = new Mock<IBaseFindByIdRepository<BaseModel>>();
            mockBaseFindByIdRepository.Setup(x => x.FindById(It.IsInRange(1, 10, Moq.Range.Inclusive)))
                .Returns((int id) => new BaseModel
                {
                    Id = id,
                    Name = "Name " + id,
                    Description = "Beschreibung " + id,
                    IsDeleted = false,
                    CreationDate = DateTime.Now,
                    ModificationTime = DateTime.Now
                });
            mockBaseFindByIdRepository.Setup(x => x.FindById(It.IsNotIn<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)))
                .Returns(() => null);
            _baseFindByIdService = new BaseFindByIdService<BaseModel>(mockBaseFindByIdRepository.Object);
        }

        static object[] _availableFindByIdTestCases =
        {
            new object[] {1},
            new object[] {2},
            new object[] {3},
            new object[] {4},
            new object[] {5},
            new object[] {6},
            new object[] {7},
            new object[] {8},
            new object[] {9},
            new object[] {10}
        };

        static object[] _notAvailableFindByIdTestCases =
        {
            new object[] {-1},
            new object[] {0},
            new object[] {11},
        };

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnNotNullWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            Assert.NotNull(_baseFindByIdService.FindById(id));
        }

        [Test]
        [TestCaseSource(nameof(_notAvailableFindByIdTestCases))]
        public void ShouldReturnNullWhenIdLessOneOrGreaterTen(int id)
        {
            Assert.Null(_baseFindByIdService.FindById(id));
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelWithSameIdWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            var expectedId = id;
            var actualId = (_baseFindByIdService.FindById(id)).Id;
            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelNameWithIdAtEndWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            var expectedName = "Name " + id;
            var actualName = (_baseFindByIdService.FindById(id)).Name;
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelDescriptionWithIdAtEndWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            var expectedDescription = "Beschreibung " + id;
            var actualDescription = (_baseFindByIdService.FindById(id)).Description;
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelIsNotDeletedWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            Assert.False((_baseFindByIdService.FindById(id)).IsDeleted);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelCreationDateIsNotNullWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            Assert.NotNull((_baseFindByIdService.FindById(id)).CreationDate);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelModificationTimeIsNotNullWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            Assert.NotNull((_baseFindByIdService.FindById(id)).ModificationTime);
        }
    }
}