using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.PAL.Core.Create
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseCreateController<TEntity, TValidator>
        where TValidator : AbstractValidator<TEntity>, new()
    {
        private readonly IBaseCreateService<TEntity> _baseCreateService;
        private readonly TValidator _validator;

        public BaseCreateController(IBaseCreateService<TEntity> baseCreateService)
        {
            _baseCreateService = baseCreateService;
            _validator = new TValidator();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] TEntity entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult);
            }

            return new OkObjectResult(_baseCreateService.Create(entity));
        }
    }
}