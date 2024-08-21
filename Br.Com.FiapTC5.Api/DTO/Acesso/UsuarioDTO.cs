namespace Br.Com.FiapTC5.Api.DTO.Acesso
{
    public class UsuarioDTO(string? nome, string? email, string? situacao, DateTime cadastradoEm, DateTime? aprovadoEm, DateTime? ultimaAtualizacaoEm)
    {
        public string? Nome { get; set; } = nome;

        public string? Email { get; set; } = email;

        public string? Situacao { get; set; } = situacao;

        public string? CadastradoEm { get; set; } = cadastradoEm.ToString("dd/MM/yyyy HH:mm:ss");

        public string? AprovadoEm { get; set; } = (aprovadoEm != null) ? ((DateTime)aprovadoEm).ToString("dd/MM/yyyy HH:mm:ss") : null;

        public string? UltimaAtualizacaoEm { get; set; } = (ultimaAtualizacaoEm != null) ? ((DateTime)ultimaAtualizacaoEm).ToString("dd/MM/yyyy HH:mm:ss") : null;
    }
}
