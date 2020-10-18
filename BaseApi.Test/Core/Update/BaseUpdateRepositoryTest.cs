using BaseApi.DAL.Core;
using BaseApi.DAL.Core.ToDbEntity;
using BaseApi.DAL.Core.ToEntity;
using BaseApi.DAL.Core.Update;
using BaseApi.PAL.Core;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BaseApi.Test.Core.Update
{
    [TestFixture(typeof(BaseModel), typeof(DbBaseModel), typeof(DbBaseModelToBaseModelTransformer), typeof(BaseModelToDbBaseModelTransformer))]
     public class BaseUpdateRepositoryTest<TEntity, TDbEntity, TToEntityTransformer, TToDbEntityTransformer>
        where TEntity : BaseModel, new()
        where TDbEntity : DbBaseModel, new()
        where TToEntityTransformer : IToEntityTransformer<TEntity, TDbEntity>, new()
        where TToDbEntityTransformer : IToDbEntityTransformer<TEntity, TDbEntity>, new()
    {
        private BaseUpdateRepository<TestContext, TEntity, TDbEntity, TToEntityTransformer, TToDbEntityTransformer>
            _baseUpdateRepository;

        private TestContext _testContext;

        [SetUp]
        public void Setup()
        {
            var securityCenterContextOptions =
                new DbContextOptionsBuilder<TestContext>().UseInMemoryDatabase("SecurityCenter").Options;
            _testContext = new TestContext(securityCenterContextOptions);
            _testContext.Database.EnsureDeleted();
            _testContext.Database.EnsureCreated();
            _testContext.Set<TDbEntity>().Add(new TDbEntity
            {
                Id = 2,
                IsDeleted = true
            });
            _testContext.SaveChanges();
            _baseUpdateRepository =
                new BaseUpdateRepository<TestContext, TEntity, TDbEntity, TToEntityTransformer, TToDbEntityTransformer>(
                    _testContext);
        }

        [Test]
        public void ShouldReturnNull()
        {
            Assert.IsNull(_baseUpdateRepository.Update(null));
        }

        [Test]
        public void ShouldReturnEntityWithIdOne()
        {
            var expectedId = 1;
            var actualEntityId = (_baseUpdateRepository.Update(new TEntity{Id = 1})).Id;
            Assert.AreEqual(expectedId, actualEntityId);
        }

        [Test]
        public void ShouldReturnNullForEntityNotInDatabase()
        {
            Assert.IsNull(_baseUpdateRepository.Update(new TEntity()));
        }

        [Test]
        public void ShouldReturnEntityWithIdTwo()
        {
            var expectedId = 2;
            var actualEntityId = (_baseUpdateRepository.Update(new TEntity{Id = 2})).Id;
            Assert.AreEqual(expectedId, actualEntityId);
        }

        [Test]
        public void ShouldReturnFalseWhenEntityWithIdTwoIsNotDeleted()
        {
            Assert.False((_baseUpdateRepository.Update(new TEntity{Id = 2})).IsDeleted);
        }

        [Test]
        public void ShouldReturnSameCreationDate()
        {
            var entity = new TEntity{Id = 1};
            var expectedCreationDate = entity.CreationDate;
            var actualEntityCreationDate = (_baseUpdateRepository.Update(entity)).CreationDate;
            Assert.AreEqual(expectedCreationDate, actualEntityCreationDate);
        }

        [Test]
        public void ShouldReturnNotEqualModificationTime()
        {
            var entity = new TEntity{Id = 1};
            var expectedModificationTime = entity.ModificationTime;
            var actualEntityModificationTime = (_baseUpdateRepository.Update(entity)).ModificationTime;
            Assert.AreNotEqual(expectedModificationTime, actualEntityModificationTime);
        }

        [Test]
        public void ShouldReturnSameName()
        {
            var entity = new TEntity{Id = 1, Name = "Test"};
            var expectedName = entity.Name;
            var actualEntityName = (_baseUpdateRepository.Update(entity)).Name;
            Assert.AreEqual(expectedName, actualEntityName);
        }
    }
}