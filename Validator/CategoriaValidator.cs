using FluentValidation;
using kotlins.Model;

namespace kotlins.Validator
{
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            RuleFor(c => c.Tipo)
                    .NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(100);
        }
    }
}

