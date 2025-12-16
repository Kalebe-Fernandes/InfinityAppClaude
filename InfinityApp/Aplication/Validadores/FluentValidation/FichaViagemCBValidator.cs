using Aplication.DTOs.Fichas;
using FluentValidation;

namespace Aplication.Validadores.FluentValidation;

/// <summary>
/// Validador para FichaViagemCBDto.
/// </summary>
public class FichaViagemCBValidator : AbstractValidator<FichaViagemCBDto>
{
    public FichaViagemCBValidator()
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

        RuleFor(f => f.DepositoOrigemId)
            .NotEmpty()
            .WithMessage("O depósito de origem é obrigatório.");

        RuleFor(f => f.Capacidade)
            .GreaterThan(0)
            .WithMessage("A capacidade deve ser maior que zero.");

        RuleFor(f => f.Equipamentos)
            .NotEmpty()
            .WithMessage("A ficha deve ter pelo menos um equipamento de transporte.")
            .Must(equipamentos => equipamentos.Count <= 8)
            .WithMessage("A ficha pode ter no máximo 8 equipamentos de transporte.");

        RuleFor(f => f.Apontamentos)
            .NotEmpty()
            .WithMessage("A ficha deve ter pelo menos um apontamento.");

        RuleForEach(f => f.Apontamentos)
            .SetValidator(new ApontamentoViagemCBValidator());

        RuleFor(f => f.Observacoes)
            .MaximumLength(1000)
            .WithMessage("As observações não podem ter mais de 1000 caracteres.");
    }
}