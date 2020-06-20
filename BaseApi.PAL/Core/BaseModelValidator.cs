using FluentValidation;

namespace BaseApi.PAL.Core
{
    public class BaseModelValidator: AbstractValidator<BaseModel>
    {
        public BaseModelValidator()
        {
            RuleFor(x => x.Name).NotNull();
        }
        
    }
}