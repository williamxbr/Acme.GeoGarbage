using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IAplicacaoServicoBase<TEntity> where TEntity : class
    {
        void Adiciona(TEntity entidade);
        void AdicionaEmLote(List<TEntity> listaEntidade);
        TEntity BuscaId(int id);
        TEntity BuscaId(Guid id);
        TEntity BuscaId(long id);
        IEnumerable<TEntity> BuscaTodos();
        IEnumerable<TEntity> Pesquisar(Func<TEntity, bool> lambda);
        IQueryable<TEntity> Consultar();
        void Atualiza(TEntity entidade);
        void Remove(TEntity entidade);
        void Dispose();
    }
}