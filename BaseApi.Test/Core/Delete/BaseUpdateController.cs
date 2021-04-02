using System.Threading.Tasks;
using BaseApi.PAL.Core;
using BaseApi.PAL.Core.Delete;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BaseApi.Test.Core.Delete
{
    [TestFixture]
    public class BaseDeleteController
    {
        private BaseDeleteController<BaseModel, BaseModelValidator> _baseDeleteController;

        [SetUp]
        public void Setup()
        {
            var mockedBaseCreateService = new Mock<IBaseDeleteService<BaseModel>>();
            mockedBaseCreateService.Setup(x => x.Delete(It.IsAny<BaseModel>()))
                .Returns((BaseModel baseModel) =>
                {
                    baseModel.IsDeleted = true;
                    return baseModel;
                });
            _baseDeleteController =
                new BaseDeleteController<BaseModel, BaseModelValidator>(mockedBaseCreateService.Object);
        }

        [Test]
        public void ShouldReturnInstanceOfBadRequestObjectResultWhenBaseModelNameIsNull()
        {
            var baseModel = new BaseModel
            {
                Name = null
            };
            Assert.IsInstanceOf<BadRequestObjectResult>(_baseDeleteController.Delete(baseModel));
        }

        [Test]
        public void ShouldReturnInstanceOfOkObjectResultWhenBaseModelNameIsNotNull()
        {
            var baseModel = new BaseModel
            {
                Name = ""
            };
            Assert.IsInstanceOf<OkObjectResult>(_baseDeleteController.Delete(baseModel));
        }
    }
}