using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Br.Com.FiapTC5.Domain.Entidades
{
    [Table("TB_PERFIL")]
    public class Perfil
    {
        [Key]
        [Column("CD_PERFIL")]
        public int Codigo { get; set; }

        [Column("DS_PERFIL")]
        public string? Descricao { get; set; }
    }
}
