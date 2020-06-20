using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.PAL.Core.FindById
{
    [ApiController]
    [Route("api/[controller]/{id}")]
    public class BaseFindByIdController<TEntity>: ControllerBase
    {
        private readonly IBaseFindByIdService<TEntity> _baseFindByIdService;

        public BaseFindByIdController(IBaseFindByIdService<TEntity> baseFindByIdService)
        {
            _baseFindByIdService = baseFindByIdService;
        }

        [HttpGet]
        public async Task<TEntity> FindById([FromRoute] int id)
        {
            var entity = _baseFindByIdService.FindById(id);
            return entity;
        }
    }
}