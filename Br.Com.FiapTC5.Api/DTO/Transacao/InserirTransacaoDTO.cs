namespace Br.Com.FiapTC5.Api.DTO.Transacao
{
    public class InserirTransacaoDTO
    {
        public string CodigoTipoTransacao { get; set; }

        public int CodigoPortfolio { get; set; }

        public int CodigoUsuario { get; set; }

        public int CodigoAtivo { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }

    }
}
