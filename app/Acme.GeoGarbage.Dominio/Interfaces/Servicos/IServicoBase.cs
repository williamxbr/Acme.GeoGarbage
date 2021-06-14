using System.Collections.Generic;

namespace Acme.GeoGarbage.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        void Adiciona(TEntity entidade);
        TEntity BuscaId(int id);
        IEnumerable<TEntity> BuscaTodos();
        void Atualiza(TEntity entidade);
        void Remove(TEntity entidade);
        void Dispose();
    }
}