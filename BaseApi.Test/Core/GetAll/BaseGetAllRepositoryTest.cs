using System.Collections.Generic;
using BaseApi.DAL.Core;
using BaseApi.DAL.Core.GetAll;
using BaseApi.DAL.Core.ToDbEntity;
using BaseApi.DAL.Core.ToEntity;
using BaseApi.PAL.Core;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BaseApi.Test.Core.GetAll
{
    [TestFixture(typeof(BaseModel), typeof(DbBaseModel), typeof(DbBaseModelToBaseModelTransformer))]
    public class BaseGetAllRepositoryTest<TEntity, TDbEntity, TTransformer>
        where TEntity : BaseModel, new()
        where TDbEntity : DbBaseModel, new()
        where TTransformer : IToEntityTransformer<TEntity, TDbEntity>, new()
    {
        private BaseGetAllRepository<TestContext, TEntity, TDbEntity, TTransformer> _baseGetAllRepository;
        private TestContext _testContext;
        [SetUp]
        public void Setup()
        {
            var securityCenterContextOptions =
                new DbContextOptionsBuilder<TestContext>().UseInMemoryDatabase("Test").Options;
            _testContext = new TestContext(securityCenterContextOptions);
            _testContext.Database.EnsureDeleted();
            _testContext.Database.EnsureCreated();
            _testContext.Set<TDbEntity>().Add(new TDbEntity
            {
                Id = 2,
                IsDeleted = true
            });
            _testContext.SaveChanges();
            _baseGetAllRepository =
                new BaseGetAllRepository<TestContext, TEntity, TDbEntity, TTransformer>(_testContext);
        }

        [Test]
        public void ShouldReturnNotEmpty()
        {
            Assert.IsNotEmpty(_baseGetAllRepository.GetAll());
        }

        [Test]
        public void ShouldReturnExactlyOneUndeletedEntry()
        {
            Assert.AreEqual(1, (_baseGetAllRepository.GetAll()).Count);
        }

        [Test]
        public void ShouldReturnInstanceOfListTEntity()
        {
            Assert.IsInstanceOf<List<TEntity>>(_baseGetAllRepository.GetAll());
        }
    }
}