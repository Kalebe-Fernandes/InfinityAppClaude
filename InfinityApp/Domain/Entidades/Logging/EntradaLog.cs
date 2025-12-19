using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades.Logging;

/// <summary>
/// Representa uma entrada de log no sistema.
/// </summary>
[Table("Logs")]
public class EntradaLog
{
    /// <summary>
    /// Identificador único do log.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Data e hora em que o log foi registrado (UTC).
    /// </summary>
    [Required]
    public DateTime Timestamp { get; set; }

    /// <summary>
    /// Nível de severidade do log.
    /// </summary>
    [Required]
    public NivelLog Nivel { get; set; }

    /// <summary>
    /// Categoria do log para classificação.
    /// </summary>
    [Required]
    public CategoriaLog Categoria { get; set; }

    /// <summary>
    /// Origem do log (classe e método que gerou).
    /// Exemplo: "ServicoAutenticacao.RealizarLoginAsync"
    /// </summary>
    [Required]
    [MaxLength(500)]
    public string Origem { get; set; } = string.Empty;

    /// <summary>
    /// Mensagem descritiva do log.
    /// </summary>
    [Required]
    [MaxLength(2000)]
    public string Mensagem { get; set; } = string.Empty;

    /// <summary>
    /// Stack trace da exceção (se houver).
    /// </summary>
    [MaxLength(5000)]
    public string? Excecao { get; set; }

    /// <summary>
    /// Contexto adicional em formato JSON.
    /// Usado para armazenar dados extras relevantes.
    /// </summary>
    [MaxLength(5000)]
    public string? ContextoJson { get; set; }

    /// <summary>
    /// ID do usuário que gerou o log (se disponível).
    /// </summary>
    [MaxLength(100)]
    public string? UsuarioId { get; set; }

    /// <summary>
    /// Nome da tela/página atual quando o log foi gerado.
    /// </summary>
    [MaxLength(200)]
    public string? Tela { get; set; }

    /// <summary>
    /// Construtor padrão.
    /// </summary>
    public EntradaLog()
    {
        Id = Guid.NewGuid();
        Timestamp = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return $"Hora: [{Timestamp:dd/MM/yyyy HH:mm:ss}]\nNível: [{Nivel}]\nCategoria: [{Categoria}]\nOrigem: {Origem} - {Mensagem}\nUsuário: {UsuarioId}\nTela: {Tela}\nContexto: {ContextoJson}\nExceção {Excecao}";
    }
}