using System.Collections.Generic;
using System.Threading.Tasks;
using BaseApi.BLL.Core.GetAll;
using BaseApi.PAL.Core;
using Moq;
using NUnit.Framework;

namespace BaseApi.Test.Core.GetAll
{
    [TestFixture]
    public class BaseGetAllServiceTest
    {
        private BaseGetAllService<BaseModel> _baseGetAllService;
        [SetUp]
        public void Setup()
        {
            var mockBaseGetAllRepository = new Mock<IBaseGetAllRepository<BaseModel>>();
            mockBaseGetAllRepository.Setup(x => x.GetAll()).Returns(new List<BaseModel>
            {
                new BaseModel
                {
                    Id = 1
                }
            });
            
            _baseGetAllService = new BaseGetAllService<BaseModel>(mockBaseGetAllRepository.Object);
        }

        [Test]
        public void ShouldReturnNotEmpty()
        {
            Assert.IsNotEmpty(_baseGetAllService.GetAll());
        }

        [Test]
        public void ShouldReturnInstanceOfListBaseModel()
        {
            Assert.IsInstanceOf<List<BaseModel>>(_baseGetAllService.GetAll());
        }

        [Test]
        public void ShoulReturnNotNull()
        {
            Assert.NotNull(_baseGetAllService.GetAll());
        }
    }
}