using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<List<TEntity>> GetAll()
        {
            return _baseGetAllService.GetAll();
        }
    }
}