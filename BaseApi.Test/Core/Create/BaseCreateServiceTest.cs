using BaseApi.BLL.Core.Create;
using BaseApi.PAL.Core;
using Moq;
using NUnit.Framework;

namespace BaseApi.Test.Core.Create
{
    [TestFixture]
    public class BaseCreateServiceTest
    {
        private BaseCreateService<BaseModel> _baseCreateService;
        private int _lastCreatedId;
        
        [SetUp]
        public void Setup()
        {
            var mockedBaseCreateRepository = new Mock<IBaseCreateRepository<BaseModel>>();
            mockedBaseCreateRepository.Setup(x => x.Create(It.IsAny<BaseModel>())).Returns((BaseModel baseModel) =>
            {
                baseModel.Id = _lastCreatedId + 1;
                _lastCreatedId++;
                return baseModel;
            });
            _lastCreatedId = 0;
            _baseCreateService = new BaseCreateService<BaseModel>(mockedBaseCreateRepository.Object);
        }

        [Test]
        public void ShouldReturnBaseModelWithIdOneWhenCreateOneBaseModel()
        {
            var expectedBaseModelId = 1;
            var baseModel = new BaseModel();
            var actualBaseModel = _baseCreateService.Create(baseModel);
            Assert.AreEqual(expectedBaseModelId, actualBaseModel.Id);
        }
        
        [Test]
        public void ShouldReturnBaseModelWithIdTwoWhenCreateTwoBaseModel()
        {
            var expectedBaseModelId = 2;
            var baseModel = new BaseModel();
            var actualBaseModel = _baseCreateService.Create(baseModel);
            actualBaseModel = _baseCreateService.Create(baseModel);
            Assert.AreEqual(expectedBaseModelId, actualBaseModel.Id);
        }
        
        
    }
}