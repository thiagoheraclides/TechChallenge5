using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.FiapTC5.Domain.Entidades
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        //Identificador único do usuário
        [Key]
        [Column("CD_USUARIO")]
        public int? Id { get; set; }

        //Nome completo do usuário
        [Column("NM_USUARIO")]
        public string? Nome { get; set; }

        //Email do usuário
        [Column("DS_EMAIL")]
        public string? Email { get; set; }

        //Hash da senha para autenticação
        [Column("DS_SENHA")]
        public string? Senha { get; set; }

        public Usuario() { }

        public Usuario(int? id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }
}
