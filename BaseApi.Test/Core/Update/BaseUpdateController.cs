using System.Threading.Tasks;
using BaseApi.PAL.Core;
using BaseApi.PAL.Core.Update;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BaseApi.Test.Core.Update
{
    [TestFixture]
    public class BaseUpdateController
    {
        private BaseUpdateController<BaseModel, BaseModelValidator> _baseUpdateController;

        [SetUp]
        public void Setup()
        {
            var mockedBaseCreateService = new Mock<IBaseUpdateService<BaseModel>>();
            mockedBaseCreateService.Setup(x => x.Update(It.IsAny<BaseModel>())).Returns((BaseModel baseModel) => baseModel);
            _baseUpdateController =
                new BaseUpdateController<BaseModel, BaseModelValidator>(mockedBaseCreateService.Object);
        }

        [Test]
        public async Task ShouldReturnInstanceOfBadRequestObjectResultWhenBaseModelNameIsNull()
        {
            var baseModel = new BaseModel
            {
                Name = null
            };
            Assert.IsInstanceOf<BadRequestObjectResult>(await _baseUpdateController.Update(baseModel));
        }

        [Test]
        public async Task ShouldReturnInstanceOfOkObjectResultWhenBaseModelNameIsNotNull()
        {
            var baseModel = new BaseModel
            {
                Name = ""
            };
            Assert.IsInstanceOf<OkObjectResult>(await _baseUpdateController.Update(baseModel));
        }
    }
}