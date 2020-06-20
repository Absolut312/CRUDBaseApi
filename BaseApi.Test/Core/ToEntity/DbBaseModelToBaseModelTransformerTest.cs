using System;
using BaseApi.DAL.Core;
using BaseApi.DAL.Core.ToEntity;
using BaseApi.PAL.Core;
using BaseApi.Test.TestCaseSources.DateTimes;
using BaseApi.Test.TestCaseSources.Ints;
using BaseApi.Test.TestCaseSources.Strings;
using NUnit.Framework;

namespace BaseApi.Test.Core.ToEntity
{
    [TestFixture]
    public class DbBaseModelToBaseModelTransformerTest
    {
        private DbBaseModelToBaseModelTransformer _dbBaseModelToBaseModelTransformer;

        [SetUp]
        public void Setup()
        {
            _dbBaseModelToBaseModelTransformer = new DbBaseModelToBaseModelTransformer();
        }

        [Test]
        [TestCaseSource(typeof(IntTestCaseSource), nameof(IntTestCaseSource.IntTestCases))]
        public void ShouldReturnSameId(int id)
        {
            var expectedBaseModel = new BaseModel
            {
                Id = id
            };
            var dbBaseModel = new DbBaseModel
            {
                Id = id
            };
            var actualBaseModel = _dbBaseModelToBaseModelTransformer.ToEntity(dbBaseModel);
            Assert.AreEqual(expectedBaseModel.Id, actualBaseModel.Id);
        }

        [Test]
        [TestCaseSource(typeof(StringTestCaseSource), nameof(StringTestCaseSource.StringCases))]
        public void ShouldReturnSameName(string name)
        {
            var expectedBaseModel = new BaseModel
            {
                Name = name
            };
            var dbBaseModel = new DbBaseModel
            {
                Name = name
            };
            var actualBaseModel = _dbBaseModelToBaseModelTransformer.ToEntity(dbBaseModel);
            Assert.AreEqual(expectedBaseModel.Name, actualBaseModel.Name);
        }
        
        [Test]
        [TestCaseSource(typeof(StringTestCaseSource), nameof(StringTestCaseSource.StringCases))]
        public void ShouldReturnSameDescription(string description)
        {
            var expectedBaseModel = new BaseModel
            {
                Description = description
            };
            var dbBaseModel = new DbBaseModel
            {
                Description = description
            };
            var actualBaseModel = _dbBaseModelToBaseModelTransformer.ToEntity(dbBaseModel);
            Assert.AreEqual(expectedBaseModel.Description, actualBaseModel.Description);
        }
        
        [Test]
        [TestCaseSource(typeof(DateTimeTestCaseSource), nameof(DateTimeTestCaseSource.DateTimeCases))]
        public void ShouldReturnSameCreationDate(DateTime dateTime)
        {
            var expectedBaseModel = new BaseModel
            {
                CreationDate = dateTime
            };
            var dbBaseModel = new DbBaseModel
            {
                CreationDate = dateTime
            };
            var actualBaseModel = _dbBaseModelToBaseModelTransformer.ToEntity(dbBaseModel);
            Assert.AreEqual(expectedBaseModel.CreationDate, actualBaseModel.CreationDate);
        }
        
        [Test]
        [TestCaseSource(typeof(DateTimeTestCaseSource), nameof(DateTimeTestCaseSource.DateTimeCases))]
        public void ShouldReturnSameModificationTime(DateTime dateTime)
        {
            var expectedBaseModel = new BaseModel
            {
                ModificationTime = dateTime
            };
            var dbBaseModel = new DbBaseModel
            {
                ModificationTime = dateTime
            };
            var actualBaseModel = _dbBaseModelToBaseModelTransformer.ToEntity(dbBaseModel);
            Assert.AreEqual(expectedBaseModel.ModificationTime, actualBaseModel.ModificationTime);
        }
    }
}