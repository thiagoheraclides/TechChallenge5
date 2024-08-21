﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //Situação no sistema A -> Ativo, I -> Inativo
        [Column("FL_SITUACAO")]
        public string? Situacao { get; set; }
        
        [Column("DT_CADASTRO")]
        public DateTime CadastroEm { get; set; }

        [Column("DT_APROVACAO")]
        public DateTime? AprovadoEm { get; set; }

        [Column("DT_ULTIMA_ALTERACAO")]
        public DateTime? UltimaAlteracaoEm { get; set; }

        public Usuario() { }

        public Usuario(string? email, string? senha)
        {
            Email = email;
            Senha = senha;
        }

        public Usuario(string? nome, string? email, string? senha, string situacao, DateTime cadastroEm)
        {            
            Nome = nome;
            Email = email;
            Senha = senha;   
            Situacao = situacao;
            CadastroEm = cadastroEm;
        }

        public void Aprovar()
        {
            Situacao = "A";
            AprovadoEm = DateTime.Now;
            UltimaAlteracaoEm = DateTime.Now;
        }
    }
}
