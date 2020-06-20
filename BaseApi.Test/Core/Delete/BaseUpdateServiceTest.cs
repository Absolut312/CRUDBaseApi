using System.Threading.Tasks;
using BaseApi.BLL.Core.Delete;
using BaseApi.BLL.Core.Update;
using BaseApi.PAL.Core;
using Moq;
using NUnit.Framework;

namespace BaseApi.Test.Core.Delete
{
    [TestFixture]
    public class BaseDeleteServiceTest
    {
        private BaseDeleteService<BaseModel> _baseDeleteService;

        [SetUp]
        public void Setup()
        {
            var mockedBaseUpdateRepository = new Mock<IBaseUpdateRepository<BaseModel>>();
            mockedBaseUpdateRepository.Setup(x => x.Update(It.IsAny<BaseModel>()))
                .Returns((BaseModel baseModel) => baseModel);
            _baseDeleteService = new BaseDeleteService<BaseModel>(mockedBaseUpdateRepository.Object);
        }

        [Test]
        public void ShouldReturnSameIdOneWhenDeleteOneBaseModel()
        {
            var expectedId = 1;
            var baseModel = new BaseModel {Id = 1};
            var actualBaseModel = _baseDeleteService.Delete(baseModel);
            Assert.AreEqual(expectedId, actualBaseModel.Id);
        }

        [Test]
        public void ShouldReturnSameIdTwoWhenDeleteTwoBaseModel()
        {
            var expectedBaseModelId = 1;
            var baseModel = new BaseModel {Id = 1};
            var actualBaseModel = _baseDeleteService.Delete(baseModel);
            actualBaseModel = _baseDeleteService.Delete(baseModel);
            Assert.AreEqual(expectedBaseModelId, actualBaseModel.Id);
        }
        
        [Test]
        public void ShouldReturnTrueForIsDeleted()
        {
            Assert.True((_baseDeleteService.Delete(new BaseModel())).IsDeleted);
        } 
    }
}