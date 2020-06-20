using System;
using System.Threading.Tasks;
using BaseApi.PAL.Core;
using BaseApi.PAL.Core.FindById;
using Moq;
using NUnit.Framework;
using Range = System.Range;

namespace BaseApi.Test.Core.FindById
{
    public class BaseFindByIdControllerTest
    {
        private BaseFindByIdController<BaseModel> _baseFindByIdController;

        [SetUp]
        public void Setup()
        {
            var mockBaseFindByIdService = new Mock<IBaseFindByIdService<BaseModel>>();
            mockBaseFindByIdService.Setup(x => x.FindById(It.IsInRange(1, 10,Moq.Range.Inclusive)))
                .Returns((int id) => new BaseModel
                {
                    Id = id,
                    Name = "Name " + id,
                    Description = "Beschreibung " + id,
                    IsDeleted = false,
                    CreationDate = DateTime.Now,
                    ModificationTime = DateTime.Now
                });
            mockBaseFindByIdService.Setup(x => x.FindById(It.IsNotIn<int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)))
                .Returns(() => null);
            _baseFindByIdController = new BaseFindByIdController<BaseModel>(mockBaseFindByIdService.Object);
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
            Assert.NotNull(_baseFindByIdController.FindById(id));
        }

        [Test]
        [TestCaseSource(nameof(_notAvailableFindByIdTestCases))]
        public async Task ShouldReturnNullWhenIdLessOneOrGreaterTen(int id)
        {
            Assert.Null(await _baseFindByIdController.FindById(id));
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public async Task ShouldReturnBaseModelWithSameIdWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            var expectedId = id;
            var actualId = (await _baseFindByIdController.FindById(id)).Id;
            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public async Task ShouldReturnBaseModelNameWithIdAtEndWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            var expectedName = "Name " + id;
            var actualName = (await _baseFindByIdController.FindById(id)).Name;
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public async Task ShouldReturnBaseModelDescriptionWithIdAtEndWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            var expectedDescription = "Beschreibung " + id;
            var actualDescription = (await _baseFindByIdController.FindById(id)).Description;
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public async Task ShouldReturnBaseModelIsNotDeletedWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            Assert.False((await _baseFindByIdController.FindById(id)).IsDeleted);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public async Task ShouldReturnBaseModelCreationDateIsNotNullWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            Assert.NotNull((await _baseFindByIdController.FindById(id)).CreationDate);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public async Task ShouldReturnBaseModelModificationTimeIsNotNullWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            Assert.NotNull((await _baseFindByIdController.FindById(id)).ModificationTime);
        }
    }
}