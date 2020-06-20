using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.PAL.Core.Delete
{
    public class BaseDeleteController<TEntity, TValidator>
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] TEntity entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult);
            }

            return new OkObjectResult(_baseDeleteService.Delete(entity));
        }
    }
}