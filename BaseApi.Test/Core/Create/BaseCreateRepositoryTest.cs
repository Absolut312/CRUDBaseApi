using BaseApi.DAL.Core;
using BaseApi.DAL.Core.Create;
using BaseApi.DAL.Core.ToDbEntity;
using BaseApi.DAL.Core.ToEntity;
using BaseApi.PAL.Core;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BaseApi.Test.Core.Create
{
    [TestFixture(typeof(BaseModel), typeof(DbBaseModel), typeof(DbBaseModelToBaseModelTransformer), typeof(BaseModelToDbBaseModelTransformer))]
    public class BaseCreateRepositoryTest<TEntity, TDbEntity, TToEntityTransformer, TToDbEntityTransformer>
        where TEntity : BaseModel, new()
        where TDbEntity : DbBaseModel, new()
        where TToEntityTransformer : IToEntityTransformer<TEntity, TDbEntity>, new()
        where TToDbEntityTransformer : IToDbEntityTransformer<TEntity, TDbEntity>, new()
    {
        private BaseCreateRepository<TestContext, TEntity, TDbEntity, TToEntityTransformer,TToDbEntityTransformer> _baseCreateRepository;
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
                IsDeleted = false
            });
            _testContext.Set<TDbEntity>().Add(new TDbEntity
            {
                Id = 3,
                IsDeleted = true
            });
            _testContext.SaveChanges();
            _baseCreateRepository =
                new BaseCreateRepository<TestContext, TEntity, TDbEntity, TToEntityTransformer,TToDbEntityTransformer>(_testContext);
        }

        [Test]
        public void ShouldReturnNull()
        {
            Assert.IsNull(_baseCreateRepository.Create(null));
        }

        [Test]
        public void ShouldReturnEntityWithIdFour()
        {
            var expectedId = 4;
            var actualEntityId = (_baseCreateRepository.Create(new TEntity())).Id;
            Assert.AreEqual(expectedId, actualEntityId);
        }
        
        [Test]
        public void ShouldReturnNotEqualCreationDate()
        {
            var entity = new TEntity();
            var expectedCreationDate = entity.CreationDate;
            var actualEntityCreationDate = (_baseCreateRepository.Create(entity)).CreationDate;
            Assert.AreNotEqual(expectedCreationDate, actualEntityCreationDate);
        }
        
        [Test]
        public void ShouldReturnNotEqualModificationTime()
        {
            var entity = new TEntity();
            var expectedModificationTime = entity.ModificationTime;
            var actualEntityModificationTime = (_baseCreateRepository.Create(entity)).ModificationTime;
            Assert.AreNotEqual(expectedModificationTime, actualEntityModificationTime);
        }
        
        [Test]
        public void ShouldReturnSameName()
        {
            var entity = new TEntity();
            var expectedName = entity.Name;
            var actualEntityName = (_baseCreateRepository.Create(entity)).Name;
            Assert.AreEqual(expectedName, actualEntityName);
        }
    }
}