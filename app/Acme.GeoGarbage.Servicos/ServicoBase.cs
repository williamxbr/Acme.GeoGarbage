using System;
using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorio;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }

        public void Adiciona(TEntity entidade)
        {
            _repositorio.Adiciona(entidade);
        }

        public void Atualiza(TEntity entidade)
        {
            _repositorio.Atualiza(entidade);
        }

        public TEntity BuscaId(int id)
        {
            return _repositorio.BuscaId(id);
        }

        public IEnumerable<TEntity> BuscaTodos()
        {
            return _repositorio.BuscaTodos();
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public void Remove(TEntity entidade)
        {
            _repositorio.Remove(entidade);
        }
    }
}