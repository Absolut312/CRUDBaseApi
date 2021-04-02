using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.PAL.Core.Update
{
    public class BaseUpdateController<TEntity, TValidator>: ControllerBase
        where TValidator : AbstractValidator<TEntity>, new()
    {
        private readonly IBaseUpdateService<TEntity> _baseUpdateService;
        private readonly TValidator _validator;

        public BaseUpdateController(IBaseUpdateService<TEntity> baseUpdateService)
        {
            _baseUpdateService = baseUpdateService;
            _validator = new TValidator();
        }

        [HttpPut]
        public IActionResult Update([FromBody] TEntity entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            return Ok(_baseUpdateService.Update(entity));
        }
    }
}