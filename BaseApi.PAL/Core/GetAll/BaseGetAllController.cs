using Microsoft.AspNetCore.Mvc;

namespace BaseApi.PAL.Core.GetAll
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseGetAllController<TEntity> : ControllerBase
    {
        private readonly IBaseGetAllService<TEntity> _baseGetAllService;

        public BaseGetAllController(IBaseGetAllService<TEntity> baseGetAllService)
        {
            _baseGetAllService = baseGetAllService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_baseGetAllService.GetAll());
        }
    }
}