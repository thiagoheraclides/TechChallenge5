using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.FiapTC5.Domain.Entidades
{
    [Table("TB_PORTFOLIO")]
    public class Portifolio
    {
        //Identificador único do portfolio
        [Key]
        [Column("CD_PORTFOLIO")]
        public int? Id { get; set; }

        //Referência ao usuário proprietario do portfólio
        [ForeignKey("FK_PORTFOLIO_USUARIO")]
        [Column("CD_USUARIO")]
        public int? UsuarioId { get; set; }

        [NotMapped]
        public Usuario? Usuario { get; set; }

        //Nome descritivo do portfólio
        [Column("NM_PORTFOLIO")]
        public string? Nome { get; set; }

        //Descrição detalhada do portfólio
        [Column("DS_PORTFOLIO")]
        public string? Descricao { get; set; }

        public Portifolio() { }

        public Portifolio(string? nome, string? descricao, Usuario? usuario)
        {            
            UsuarioId = usuario!.Id;
            Usuario = usuario!;
            Nome = nome;
            Descricao = descricao;
        }
    }
}
