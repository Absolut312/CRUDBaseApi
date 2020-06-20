using System.Threading.Tasks;
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
        public async Task ShouldReturnInstanceOfBadRequestObjectResultWhenBaseModelNameIsNull()
        {
            var baseModel = new BaseModel
            {
                Name = null
            };
            Assert.IsInstanceOf<BadRequestObjectResult>(await _baseCreateController.Create(baseModel));
        }
        
        [Test]
        public async Task ShouldReturnInstanceOfOkObjectResultWhenBaseModelNameIsNotNull()
        {
            var baseModel = new BaseModel
            {
                Name = ""
            };
            Assert.IsInstanceOf<OkObjectResult>(await _baseCreateController.Create(baseModel));
        }
    }
}