namespace Br.Com.FiapTC5.Api.DTO.Acesso
{
    public class SolicitacaoDTO
    {
        public int? Codigo { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public required string RecebidaEm { get; set; }

    }
}
