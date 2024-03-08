using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class CreateProductValidator : AbstractValidator<ProductDTO>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.DataValidade)
                .GreaterThan(x => x.DataFabricacao)
                .WithMessage("Data de Validade deve ser maior que Data de Fabricação");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Descrição não deve ser vazia");
        }
    }
}
