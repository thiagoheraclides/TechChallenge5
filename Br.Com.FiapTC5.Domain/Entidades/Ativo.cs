using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.FiapTC5.Domain.Entidades
{
    [Table("TB_ATIVO")]
    public class Ativo
    {
        //Identificador único do ativo
        [Key]
        [Column("CD_ATIVO")]
        public int? Id { get; set; }

        //Tipo do ativo (e.g., Ações, Títulos, Criptomoedas)
        [Column("NM_TIPO_ATIVO")]
        public string? TipoAtivo { get; set; }

        //Nome do ativo
        [Column("NM_ATIVO")]
        public string? Nome { get; set; }

        //Código de negociação do ativo (e.g., AAPL para Apple, BTC para Bitcoin)
        [Column("CD_NEGOCIACAO_ATIVO")]
        public string? Codigo { get; set; }

        public Ativo() { }

        public Ativo(int? id, string? tipoAtivo, string? nome, string? codigo)
        {
            Id = id;
            TipoAtivo = tipoAtivo;
            Nome = nome;
            Codigo = codigo;
        }
    }
}
