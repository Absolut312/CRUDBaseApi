using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.PAL.Core.Update
{
    public class BaseUpdateController<TEntity, TValidator>
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] TEntity entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return new BadRequestObjectResult(validationResult);
            }

            return new OkObjectResult(_baseUpdateService.Update(entity));
        }
    }
}