using System;
using System.Collections.Generic;
using System.Linq;
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

        public TEntity BuscaId(Guid id)
        {
            return _repositorio.BuscaId(id);
        }

        public IEnumerable<TEntity> BuscaTodos()
        {
            return _repositorio.BuscaTodos();
        }

        public IEnumerable<TEntity> Pesquisar(Func<TEntity, bool> lambda)
        {
            return _repositorio.Pesquisar(lambda);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public void Remove(TEntity entidade)
        {
            _repositorio.Remove(entidade);
        }

        public TEntity BuscaId(long id)
        {
            return _repositorio.BuscaId(id);
        }

        public IQueryable<TEntity> Consultar()
        {
            return _repositorio.Consultar();
        }

        public void AdicionaEmLote(List<TEntity> listaEntidade)
        {
            _repositorio.AdicionaEmLote(listaEntidade);
        }
    }
}