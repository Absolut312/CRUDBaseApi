using BaseApi.PAL.Core;
using BaseApi.PAL.Core.Create;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BaseApi.Test.Core.Create
{
    [TestFixture]
    public class BaseCreateControllerTest
    {
        private BaseCreateController<BaseModel, BaseModelValidator> _baseCreateController;
        private int _lastCreatedId;
        
        [SetUp]
        public void Setup()
        {
            var mockedBaseCreateService = new Mock<IBaseCreateService<BaseModel>>();
            mockedBaseCreateService.Setup(x => x.Create(It.IsAny<BaseModel>())).Returns((BaseModel baseModel) =>
            {
                baseModel.Id = _lastCreatedId + 1;
                _lastCreatedId++;
                return baseModel;
            });
            _lastCreatedId = 0;
            _baseCreateController = new BaseCreateController<BaseModel, BaseModelValidator>(mockedBaseCreateService.Object);
        }

        [Test]
        public void ShouldReturnInstanceOfBadRequestObjectResultWhenBaseModelNameIsNull()
        {
            var baseModel = new BaseModel
            {
                Name = null
            };
            Assert.IsInstanceOf<BadRequestObjectResult>(_baseCreateController.Create(baseModel));
        }
        
        [Test]
        public void ShouldReturnInstanceOfOkObjectResultWhenBaseModelNameIsNotNull()
        {
            var baseModel = new BaseModel
            {
                Name = ""
            };
            Assert.IsInstanceOf<OkObjectResult>(_baseCreateController.Create(baseModel));
        }
    }
}