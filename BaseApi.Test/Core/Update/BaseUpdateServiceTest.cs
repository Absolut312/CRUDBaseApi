using System.Threading.Tasks;
using BaseApi.BLL.Core.Update;
using BaseApi.PAL.Core;
using Moq;
using NUnit.Framework;

namespace BaseApi.Test.Core.Update
{
    [TestFixture]
    public class BaseUpdateServiceTest
    {
        private BaseUpdateService<BaseModel> _baseUpdateService;

        [SetUp]
        public void Setup()
        {
            var mockedBaseUpdateRepository = new Mock<IBaseUpdateRepository<BaseModel>>();
            mockedBaseUpdateRepository.Setup(x => x.Update(It.IsAny<BaseModel>()))
                .Returns((BaseModel baseModel) => baseModel);
            _baseUpdateService = new BaseUpdateService<BaseModel>(mockedBaseUpdateRepository.Object);
        }

        [Test]
        public void ShouldReturnSameIdOneWhenUpdateOneBaseModel()
        {
            var expectedId = 1;
            var baseModel = new BaseModel {Id = 1};
            var actualBaseModel = _baseUpdateService.Update(baseModel);
            Assert.AreEqual(expectedId, actualBaseModel.Id);
        }

        [Test]
        public void ShouldReturnSameIdTwoWhenUpdateTwoBaseModel()
        {
            var expectedBaseModelId = 1;
            var baseModel = new BaseModel {Id = 1};
            var actualBaseModel = _baseUpdateService.Update(baseModel);
            actualBaseModel = _baseUpdateService.Update(baseModel);
            Assert.AreEqual(expectedBaseModelId, actualBaseModel.Id);
        }
    }
}