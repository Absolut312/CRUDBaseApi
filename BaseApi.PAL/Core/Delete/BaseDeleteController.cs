using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.PAL.Core.Delete
{
    public class BaseDeleteController<TEntity, TValidator> : ControllerBase
        where TValidator : AbstractValidator<TEntity>, new()
    {
        private readonly IBaseDeleteService<TEntity> _baseDeleteService;
        private readonly TValidator _validator;

        public BaseDeleteController(IBaseDeleteService<TEntity> baseDeleteService)
        {
            _baseDeleteService = baseDeleteService;
            _validator = new TValidator();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] TEntity entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            return Ok(_baseDeleteService.Delete(entity));
        }
    }
}