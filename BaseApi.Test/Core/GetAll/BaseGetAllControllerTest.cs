using System.Collections.Generic;
using System.Threading.Tasks;
using BaseApi.PAL.Core;
using BaseApi.PAL.Core.GetAll;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace BaseApi.Test.Core.GetAll
{
    [TestFixture]
    public class BaseGetAllControllerTest
    {
        private BaseGetAllController<BaseModel> _baseGetAllController;

        [SetUp]
        public void Setup()
        {
            var mockBaseGetAllService = new Mock<IBaseGetAllService<BaseModel>>();
            mockBaseGetAllService.Setup(x => x.GetAll()).Returns(new List<BaseModel>
            {
                new BaseModel
                {
                    Id = 1
                }
            });

            _baseGetAllController = new BaseGetAllController<BaseModel>(mockBaseGetAllService.Object);
        }

        [Test]
        public void ShouldReturnNotEmpty()
        {
            Assert.IsNotEmpty((_baseGetAllController.GetAll() as OkObjectResult)?.Value as List<BaseModel>);
        }

        [Test]
        public void ShouldReturnInstanceOfListBaseModel()
        {
            Assert.IsInstanceOf<List<BaseModel>>((_baseGetAllController.GetAll() as OkObjectResult)?.Value);
        }

        [Test]
        public void ShoulReturnNotNull()
        {
            Assert.NotNull(((_baseGetAllController.GetAll() as OkObjectResult)?.Value as List<BaseModel>));
        }
    }
}