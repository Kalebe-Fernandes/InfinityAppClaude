using Aplication.DTOs.Fichas;
using FluentValidation;

namespace Aplication.Validadores.FluentValidation;

/// <summary>
/// Validador para ApontamentoViagemCBDto.
/// </summary>
public class ApontamentoViagemCBValidator : AbstractValidator<ApontamentoViagemCBDto>
{
    public ApontamentoViagemCBValidator()
    {
        RuleFor(a => a.EquipamentoId)
            .NotEmpty()
            .WithMessage("O equipamento é obrigatório.");

        RuleFor(a => a.MaterialId)
            .NotEmpty()
            .WithMessage("O material é obrigatório.");

        RuleFor(a => a.QtdViagens)
            .GreaterThan(0)
            .WithMessage("A quantidade de viagens deve ser maior que zero.");

        RuleFor(a => a.VolumeM3)
            .GreaterThan(0)
            .WithMessage("O volume deve ser maior que zero.");

        When(a => a.HoraCarregamento.HasValue && a.HoraDescarregamento.HasValue, () =>
        {
            RuleFor(a => a)
                .Must(a => a.HoraCarregamento!.Value < a.HoraDescarregamento!.Value)
                .WithMessage("A hora de carregamento deve ser anterior à hora de descarregamento.");
        });
    }
}
