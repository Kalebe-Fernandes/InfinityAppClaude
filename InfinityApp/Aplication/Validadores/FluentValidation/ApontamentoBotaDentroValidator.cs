using Aplication.DTOs.Fichas;
using FluentValidation;

namespace Aplication.Validadores.FluentValidation;

/// <summary>
/// Validador para ApontamentoBotaDentroDto.
/// </summary>
public class ApontamentoBotaDentroValidator : AbstractValidator<ApontamentoBotaDentroDto>
{
    public ApontamentoBotaDentroValidator()
    {
        RuleFor(a => a.MaterialId)
            .NotEmpty()
            .WithMessage("O material é obrigatório.");

        RuleFor(a => a.QtdViagens)
            .GreaterThan(0)
            .WithMessage("A quantidade de viagens deve ser maior que zero.");

        RuleFor(a => a.VolumeM3)
            .GreaterThan(0)
            .WithMessage("O volume deve ser maior que zero.");
    }
}
