using Aplication.DTOs.Fichas;
using FluentValidation;

namespace Aplication.Validadores.FluentValidation;

/// <summary>
/// Validador para FichaLimpezaPistaDto.
/// </summary>
public class FichaLimpezaPistaValidator : AbstractValidator<FichaLimpezaPistaDto>
{
    public FichaLimpezaPistaValidator()
    {
        RuleFor(f => f.DataProducao)
            .NotEmpty()
            .WithMessage("A data de produção é obrigatória.")
            .LessThanOrEqualTo(DateTime.Today)
            .WithMessage("A data de produção não pode ser futura.");

        RuleFor(f => f.ObraId)
            .NotEmpty()
            .WithMessage("A obra é obrigatória.");

        RuleFor(f => f.ServicoId)
            .NotEmpty()
            .WithMessage("O serviço é obrigatório.");

        RuleFor(f => f.TrechoId)
            .NotEmpty()
            .WithMessage("O trecho é obrigatório.");

        RuleFor(f => f.EquipamentoExecucaoId)
            .NotEmpty()
            .WithMessage("O equipamento de execução é obrigatório.");

        RuleFor(f => f.Apontamentos)
            .NotEmpty()
            .WithMessage("A ficha deve ter pelo menos um apontamento.");

        RuleForEach(f => f.Apontamentos)
            .SetValidator(new ApontamentoLimpezaPistaValidator());

        RuleFor(f => f.Observacoes)
            .MaximumLength(1000)
            .WithMessage("As observações não podem ter mais de 1000 caracteres.");
    }
}