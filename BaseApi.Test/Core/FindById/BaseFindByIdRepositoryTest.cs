using BaseApi.DAL.Core;
using BaseApi.DAL.Core.FindById;
using BaseApi.DAL.Core.ToDbEntity;
using BaseApi.DAL.Core.ToEntity;
using BaseApi.PAL.Core;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BaseApi.Test.Core.FindById
{
    [TestFixture(typeof(BaseModel), typeof(DbBaseModel), typeof(DbBaseModelToBaseModelTransformer))]
    public class BaseFindByIdRepositoryTest<TEntity, TDbEntity, TTransformer>
        where TEntity : BaseModel, new()
        where TDbEntity : DbBaseModel, new()
        where TTransformer : IToEntityTransformer<TEntity, TDbEntity>, new()
    {
        private BaseFindByIdRepository<TestContext, TEntity, TDbEntity, TTransformer> _baseFindByIdRepository;
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
            _baseFindByIdRepository =
                new BaseFindByIdRepository<TestContext, TEntity, TDbEntity, TTransformer>(_testContext);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ShouldReturnNullIfIdIsNotInDatabase(int id)
        {
            Assert.IsNull((_baseFindByIdRepository.FindById(id)));
        }

        [Test]
        public void ShouldReturnNotNullWhenNotDbSetIsNotEmptyAndHasEntryWithIdOne()
        {
            var actualEntity = _baseFindByIdRepository.FindById(1);
            Assert.IsNotNull(actualEntity);
        }

        [Test]
        public void ShouldReturnInstanceOfTypeTEntityWhenNotDbSetIsNotEmptyAndHasEntryWithIdOne()
        {
            var actualEntity = _baseFindByIdRepository.FindById(1);
            Assert.IsInstanceOf<TEntity>(actualEntity);
        }

        [Test]
        public void ShouldReturnNotDeletedWhenNotDbSetIsNotEmptyAndHasEntryWithIdOne()
        {
            var actualEntity = _baseFindByIdRepository.FindById(1);
            Assert.False(actualEntity.IsDeleted);
        }

        [Test]
        [TestCase(2)]
        public void ShouldReturnNullForEntityIsDeleted(int id)
        {
            Assert.IsNull((_baseFindByIdRepository.FindById(id)));
        }
    }
}