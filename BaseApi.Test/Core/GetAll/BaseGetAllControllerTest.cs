using System.Collections.Generic;
using System.Threading.Tasks;
using BaseApi.PAL.Core;
using BaseApi.PAL.Core.GetAll;
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
        public async Task ShouldReturnNotEmpty()
        {
            Assert.IsNotEmpty(await _baseGetAllController.GetAll());
        }

        [Test]
        public async Task ShouldReturnInstanceOfListBaseModel()
        {
            Assert.IsInstanceOf<List<BaseModel>>(await _baseGetAllController.GetAll());
        }

        [Test]
        public async Task ShoulReturnNotNull()
        {
            Assert.NotNull(await _baseGetAllController.GetAll());
        }
    }
}