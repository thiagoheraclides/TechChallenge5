using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.FiapTC5.Domain.Entidades
{
    [Table("TB_ATIVO")]
    public class Ativo
    {
        private string? _codigo;

        //Identificador único do ativo
        [Key]
        [Column("CD_ATIVO")]
        public int? Id { get; set; }

        //Tipo do ativo (e.g., Ações, Títulos, Criptomoedas)
        [Column("CD_TIPO_ATIVO")]
        public int? CodigoTipoAtivo { get; set; }

        [NotMapped]
        public TipoAtivo? TipoAtivo { get; set; }

        //Nome do ativo
        [Column("NM_ATIVO")]
        public string? Nome { get; set; }

        //Código de negociação do ativo (e.g., AAPL para Apple, BTC para Bitcoin)
        [Column("CD_NEGOCIACAO_ATIVO")]
        public string? Codigo
        {
            get { return _codigo; }
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Código de negociação inválido", nameof(Codigo));

                _codigo = value;
            }
        }

        public Ativo() { }

        public Ativo(int? id, int? codigoTipoAtivo, TipoAtivo tipoAtivo, string? nome, string codigo)
        {
            Id = id;
            CodigoTipoAtivo = codigoTipoAtivo;
            TipoAtivo = tipoAtivo;
            Nome = nome;
            Codigo = codigo;
        }
    }
}
