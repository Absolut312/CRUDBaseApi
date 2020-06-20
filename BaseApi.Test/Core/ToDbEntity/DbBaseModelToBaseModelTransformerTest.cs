using System;
using BaseApi.DAL.Core;
using BaseApi.DAL.Core.ToDbEntity;
using BaseApi.PAL.Core;
using BaseApi.Test.TestCaseSources.DateTimes;
using BaseApi.Test.TestCaseSources.Ints;
using BaseApi.Test.TestCaseSources.Strings;
using NUnit.Framework;

namespace BaseApi.Test.Core.ToDbEntity
{
    [TestFixture]
    public class BaseModelToDbBaseModelTransformerTest
    {
        private BaseModelToDbBaseModelTransformer _baseModelToBaseModelTransformer;

        [SetUp]
        public void Setup()
        {
            _baseModelToBaseModelTransformer = new BaseModelToDbBaseModelTransformer();
        }

        [Test]
        [TestCaseSource(typeof(IntTestCaseSource), nameof(IntTestCaseSource.IntTestCases))]
        public void ShouldReturnSameId(int id)
        {
            var expectedDbBaseModel = new DbBaseModel
            {
                Id = id
            };
            var baseModel = new BaseModel
            {
                Id = id
            };
            var actualBaseModel = _baseModelToBaseModelTransformer.ToDbEntity(baseModel);
            Assert.AreEqual(expectedDbBaseModel.Id, actualBaseModel.Id);
        }

        [Test]
        [TestCaseSource(typeof(StringTestCaseSource), nameof(StringTestCaseSource.StringCases))]
        public void ShouldReturnSameName(string name)
        {
            var expectedDbBaseModel = new DbBaseModel
            {
                Name = name
            };
            var baseModel = new BaseModel
            {
                Name = name
            };
            var actualBaseModel = _baseModelToBaseModelTransformer.ToDbEntity(baseModel);
            Assert.AreEqual(expectedDbBaseModel.Name, actualBaseModel.Name);
        }
        
        [Test]
        [TestCaseSource(typeof(StringTestCaseSource), nameof(StringTestCaseSource.StringCases))]
        public void ShouldReturnSameDescription(string description)
        {
            var expectedDbBaseModel = new DbBaseModel
            {
                Description = description
            };
            var baseModel = new BaseModel
            {
                Description = description
            };
            var actualBaseModel = _baseModelToBaseModelTransformer.ToDbEntity(baseModel);
            Assert.AreEqual(expectedDbBaseModel.Description, actualBaseModel.Description);
        }
        
        [Test]
        [TestCaseSource(typeof(DateTimeTestCaseSource), nameof(DateTimeTestCaseSource.DateTimeCases))]
        public void ShouldReturnSameCreationDate(DateTime dateTime)
        {
            var expectedDbBaseModel = new DbBaseModel
            {
                CreationDate = dateTime
            };
            var baseModel = new BaseModel
            {
                CreationDate = dateTime
            };
            var actualBaseModel = _baseModelToBaseModelTransformer.ToDbEntity(baseModel);
            Assert.AreEqual(expectedDbBaseModel.CreationDate, actualBaseModel.CreationDate);
        }
        
        [Test]
        [TestCaseSource(typeof(DateTimeTestCaseSource), nameof(DateTimeTestCaseSource.DateTimeCases))]
        public void ShouldReturnSameModificationTime(DateTime dateTime)
        {
            var expectedDbBaseModel = new DbBaseModel
            {
                ModificationTime = dateTime
            };
            var baseModel = new BaseModel
            {
                ModificationTime = dateTime
            };
            var actualBaseModel = _baseModelToBaseModelTransformer.ToDbEntity(baseModel);
            Assert.AreEqual(expectedDbBaseModel.ModificationTime, actualBaseModel.ModificationTime);
        }
    }
}