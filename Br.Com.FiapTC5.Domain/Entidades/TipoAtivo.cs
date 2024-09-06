using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.FiapTC5.Domain.Entidades
{
    [Table("TB_TIPO_ATIVO")]
    public class TipoAtivo
    {
        [Key]
        [Column("CD_TIPO_ATIVO")]
        public int Id { get; set; }

        [Column("DS_TIPO_ATIVO")]
        public string? Descricao { get; set; }

        public TipoAtivo() { }

        public TipoAtivo(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }
    }
}
