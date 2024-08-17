using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.FiapTC5.Domain.Entidades
{
    [Table("TB_TRANSACAO")]
    public class Transacao
    {
        //Identificador único da transacao
        [Key]
        [Column("CD_TRANSACAO")]
        public int? Id { get; set; }

        //Referência ao portfólio em que a transação foi realizar
        [Column("CD_PORTFOLIO")]
        [ForeignKey("FK_TRANSACAO_PORTFOLIO")]
        public int? PortfolioId { get; set; }

        [NotMapped]
        public Portifolio? Portifolio { get; set; }

        //Referência ao ativo negociado
        [Column("CD_ATIVO")]
        [ForeignKey("FK_TRANSACAO_ATIVO")]
        public int? AtivoId { get; set; }

        [NotMapped]
        public Ativo? Ativo { get; set; }

        //Tipo de transação (Compra ou Venda)
        [Column("NM_TIPO_TRANSACAO")]
        public string? TipoTransacao { get; set; }
       

        //Quantidade de ativos negociados
        [Column("NR_QUANTIDADE")]
        public int? Quantidade { get; set; }


        //Preço por unidade do ativo no momento da transação
        [Column("VL_TRANSACAO")]
        public decimal Preco { get; set; } = 0m;

        // Data e hora em que a transação foi efetuada
        [Column("DT_TRANSACAO")]
        public DateTime DataTransacao { get; set; }

        public Transacao() { }

        public Transacao(int? id, int? portfolioId, int? ativoId, string? tipoTransacao, int? quantidade, decimal preco, DateTime dataTransacao)
        {
            Id = id;
            PortfolioId = portfolioId;
            AtivoId = ativoId;
            TipoTransacao = tipoTransacao;
            Quantidade = quantidade;
            Preco = preco;
            DataTransacao = dataTransacao;
        }
    }
}
