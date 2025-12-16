using Aplication.DTOs.Fichas;
using FluentValidation;

namespace Aplication.Validadores.FluentValidation;

/// <summary>
/// Validador para ApontamentoFresagemDto.
/// </summary>
public class ApontamentoFresagemValidator : AbstractValidator<ApontamentoFresagemDto>
{
    public ApontamentoFresagemValidator()
    {
        RuleFor(a => a.Lado)
            .NotEmpty()
            .WithMessage("O lado é obrigatório.")
            .Must(lado => new[] { "LD", "LE", "LD_LE", "CC" }.Contains(lado))
            .WithMessage("O lado deve ser LD, LE, LD_LE ou CC.");

        RuleFor(a => a.EstacaInicial)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A estaca inicial deve ser maior ou igual a zero.");

        RuleFor(a => a.FracaoInicial)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A fração inicial deve ser maior ou igual a zero.")
            .LessThan(20)
            .WithMessage("A fração inicial deve ser menor que 20.");

        RuleFor(a => a.EstacaFinal)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A estaca final deve ser maior ou igual a zero.");

        RuleFor(a => a.FracaoFinal)
            .GreaterThanOrEqualTo(0)
            .WithMessage("A fração final deve ser maior ou igual a zero.")
            .LessThan(20)
            .WithMessage("A fração final deve ser menor que 20.");

        RuleFor(a => a)
            .Must(a =>
            {
                var estacaInicialTotal = a.EstacaInicial + a.FracaoInicial / 20;
                var estacaFinalTotal = a.EstacaFinal + a.FracaoFinal / 20;
                return estacaInicialTotal < estacaFinalTotal;
            })
            .WithMessage("A estaca inicial deve ser menor que a estaca final.");

        RuleFor(a => a.Largura)
            .GreaterThan(0)
            .WithMessage("A largura deve ser maior que zero.");

        RuleFor(a => a.EspessuraCm)
            .GreaterThan(0)
            .WithMessage("A espessura deve ser maior que zero.");

        RuleFor(a => a.Extensao)
            .GreaterThan(0)
            .WithMessage("A extensão deve ser maior que zero.");

        RuleFor(a => a.AreaM2)
            .GreaterThan(0)
            .WithMessage("A área deve ser maior que zero.");

        RuleFor(a => a.VolumeM3)
            .GreaterThan(0)
            .WithMessage("O volume deve ser maior que zero.");
    }
}
