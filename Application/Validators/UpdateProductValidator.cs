using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateProductValidator : AbstractValidator<ProductDTO>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.DataValidade)
                .GreaterThan(x => x.DataFabricacao)
                .WithMessage("Data de Validade deve ser maior que Data de Fabricação");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Descrição não deve ser vazia");
        }
    }
}
