﻿using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Br.Com.FiapTC5.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Br.Com.FiapTC5.Application.Services
{
    public class AtivoService(DatabaseContext data) : IAtivoService
    {
        private readonly DatabaseContext _data = data;

        public async Task<Ativo> Obter(int id)
            => await _data.Ativos.Where(ativo => ativo.Id == id).SingleOrDefaultAsync();

        public async Task<IEnumerable<Ativo>> Obter() 
            => await _data.Ativos.ToListAsync();

        public async Task<IEnumerable<Ativo>> ObterPorUsuario(int codigoUsuario)
        {
            IList<Ativo> ativos = [];
            IList<Transacao> transacoes = await _data.Transacoes.Where(transacao => transacao.CodigoUsuario == codigoUsuario).ToListAsync();

            if (transacoes is not null)
            {
                foreach(var transacao in transacoes) 
                {
                    Ativo ativo = await _data.Ativos.Where(a => a.Id == transacao.CodigoAtivo).FirstAsync();
                    ativos.Add(ativo);
                }
            }

            return ativos;
        }
    }
}
