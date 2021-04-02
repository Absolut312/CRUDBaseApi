using System;
using BaseApi.PAL.Core;
using BaseApi.PAL.Core.FindById;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BaseApi.Test.Core.FindById
{
    public class BaseFindByIdControllerTest
    {
        private BaseFindByIdController<BaseModel> _baseFindByIdController;

        [SetUp]
        public void Setup()
        {
            var mockBaseFindByIdService = new Mock<IBaseFindByIdService<BaseModel>>();
            mockBaseFindByIdService.Setup(x => x.FindById(It.IsInRange(1, 10, Moq.Range.Inclusive)))
                .Returns((int id) => new BaseModel
                {
                    Id = id,
                    Name = "Name " + id,
                    Description = "Beschreibung " + id,
                    IsDeleted = false,
                    CreationDate = DateTime.Now,
                    ModificationTime = DateTime.Now
                });
            mockBaseFindByIdService.Setup(x => x.FindById(It.IsNotIn(1, 2, 3, 4, 5, 6, 7, 8, 9, 10)))
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
        public void ShouldReturnNullWhenIdLessOneOrGreaterTen(int id)
        {
            Assert.IsNull(((OkObjectResult) _baseFindByIdController.FindById(id)).Value);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelWithSameIdWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            var expectedId = id;
            var actualId = ((_baseFindByIdController.FindById(id) as OkObjectResult)?.Value as BaseModel)?.Id;
            Assert.AreEqual(expectedId, actualId);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelNameWithIdAtEndWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            var expectedName = "Name " + id;
            var actualName = ((_baseFindByIdController.FindById(id) as OkObjectResult)?.Value as BaseModel)?.Name;
            Assert.AreEqual(expectedName, actualName);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelDescriptionWithIdAtEndWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            var expectedDescription = "Beschreibung " + id;
            var actualDescription = ((_baseFindByIdController.FindById(id) as OkObjectResult)?.Value as BaseModel)
                ?.Description;
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelIsNotDeletedWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            Assert.False(((_baseFindByIdController.FindById(id) as OkObjectResult)?.Value as BaseModel)?.IsDeleted);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelCreationDateIsNotNullWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            Assert.NotNull(((_baseFindByIdController.FindById(id) as OkObjectResult)?.Value as BaseModel)
                ?.CreationDate);
        }

        [Test]
        [TestCaseSource(nameof(_availableFindByIdTestCases))]
        public void ShouldReturnBaseModelModificationTimeIsNotNullWhenIdIsGreaterZeroOrLessEleven(int id)
        {
            Assert.NotNull(((_baseFindByIdController.FindById(id) as OkObjectResult)?.Value as BaseModel)
                ?.ModificationTime);
        }
    }
}