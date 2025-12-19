namespace Aplication.DTOs.Autenticacao
{
    public class ResultadoAutenticacao
    {
        /// <summary>
        /// Indica se a operação foi bem-sucedida.
        /// </summary>
        public bool EhSucesso { get; set; }

        /// <summary>
        /// Mensagem de erro caso a operação falhe.
        /// </summary>
        public string? MensagemErro { get; set; }

        /// <summary>
        /// Código de erro específico (opcional).
        /// </summary>
        public string? CodigoErro { get; set; }

        /// <summary>
        /// Informações do usuário autenticado (se sucesso).
        /// </summary>
        public UsuarioDto? Usuario { get; set; }

        /// <summary>
        /// Cria resultado de sucesso.
        /// </summary>
        public static ResultadoAutenticacao Sucesso(UsuarioDto? usuario = null)
        {
            return new ResultadoAutenticacao
            {
                EhSucesso = true,
                Usuario = usuario
            };
        }

        /// <summary>
        /// Cria resultado de erro.
        /// </summary>
        public static ResultadoAutenticacao Erro(string mensagem, string? codigo = null)
        {
            return new ResultadoAutenticacao
            {
                EhSucesso = false,
                MensagemErro = mensagem,
                CodigoErro = codigo
            };
        }
    }
}
