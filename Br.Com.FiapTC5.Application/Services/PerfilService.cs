using Br.Com.FiapTC5.Domain.Entidades;
using Br.Com.FiapTC5.Domain.Interfaces;
using Br.Com.FiapTC5.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Br.Com.FiapTC5.Application.Services
{
    public class PerfilService(DatabaseContext data) : IPerfilService
    {
        private readonly DatabaseContext _data = data;

        public async Task<IEnumerable<Perfil>> Obter()
        {
            return await _data.Perfis.ToListAsync();
        }

        public async Task<Perfil> ObterPorId(int codigo)
        {
            return await _data.Perfis.Where(perfil => perfil.Codigo == codigo).SingleOrDefaultAsync();
        }
    }
}
