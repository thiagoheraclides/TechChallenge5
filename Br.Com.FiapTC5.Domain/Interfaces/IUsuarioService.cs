﻿using Br.Com.FiapTC5.Domain.Entidades;

namespace Br.Com.FiapTC5.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> Obter(int id);

        Task<IEnumerable<Usuario>> Obter();
    }
}
