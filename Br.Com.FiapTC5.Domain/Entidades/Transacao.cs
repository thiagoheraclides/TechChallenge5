using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.FiapTC5.Domain.Entidades
{
    [Table("TB_TRANSACAO")]
    public class Transacao
    {
        private decimal _quantidade;

        //Identificador único da transacao
        [Key]
        [Column("CD_TRANSACAO")]
        public int? Id { get; set; }

        //Referência ao portfólio em que a transação foi realizar
        [Column("CD_PORTFOLIO")]
        [ForeignKey("FK_TRANSACAO_PORTFOLIO")]
        public int? CodigoPortifolio { get; set; }

        [NotMapped]
        public Portifolio? Portifolio { get; set; }

        //Referência ao ativo negociado
        [Column("CD_ATIVO")]
        [ForeignKey("FK_TRANSACAO_ATIVO")]
        public int? CodigoAtivo { get; set; }

        [NotMapped]
        public Ativo? Ativo { get; set; }

        //Tipo de transação (Compra ou Venda)
        [Column("CD_TIPO_TRANSACAO")]
        public string? TipoTransacao { get; set; }
       

        //Quantidade de ativos negociados
        [Column("NR_QUANTIDADE")]
        public decimal Quantidade 
        {
            get { return _quantidade; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException(nameof(value), "Informe apenas valores positivos superiores à 0.");

                _quantidade = value;
            }
        }

        //Preço por unidade do ativo no momento da transação
        [Column("VL_TRANSACAO")]
        public decimal Preco { get; set; } = 0m;

        // Data e hora em que a transação foi efetuada
        [Column("DT_TRANSACAO")]
        public DateTime DataTransacao { get; set; }

        [Column("CD_USUARIO")]
        public int CodigoUsuario { get; set; }

        [NotMapped]
        public Usuario? Usuario { get; set; }

        public Transacao() { }

        public Transacao(int portfolioId, int codigoUsuario, int ativoId, string tipoTransacao, decimal quantidade, decimal preco, DateTime dataTransacao)
        {           
            CodigoPortifolio = portfolioId;
            CodigoUsuario = codigoUsuario;
            CodigoAtivo = ativoId;
            TipoTransacao = tipoTransacao;
            Quantidade = quantidade;
            Preco = preco;
            DataTransacao = dataTransacao;
        }
    }
}
