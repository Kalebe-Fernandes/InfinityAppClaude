using Aplication.DTOs.Fichas;
using FluentValidation;

namespace Aplication.Validadores.FluentValidation;

/// <summary>
/// Validador para MaterialQuantidadeDto.
/// </summary>
public class MaterialQuantidadeValidator : AbstractValidator<MaterialQuantidadeDto>
{
    public MaterialQuantidadeValidator()
    {
        RuleFor(m => m.MaterialId)
            .NotEmpty()
            .WithMessage("O material é obrigatório.");

        RuleFor(m => m.Quantidade)
            .GreaterThan(0)
            .WithMessage("A quantidade deve ser maior que zero.");
    }
}
