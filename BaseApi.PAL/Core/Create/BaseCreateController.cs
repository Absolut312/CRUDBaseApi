using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.PAL.Core.Create
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseCreateController<TEntity, TValidator>: ControllerBase
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
        public IActionResult Create([FromBody] TEntity entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            return Ok(_baseCreateService.Create(entity));
        }
    }
}