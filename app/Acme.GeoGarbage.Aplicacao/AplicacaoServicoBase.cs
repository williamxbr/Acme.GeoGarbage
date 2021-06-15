using System;
using System.Collections.Generic;
using System.Linq;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;

namespace Acme.GeoGarbage.Aplicacao
{
    public class AplicacaoServicoBase<TEntity> : IDisposable, IAplicacaoServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _servicoBase;

        public AplicacaoServicoBase(IServicoBase<TEntity> servicoBase)
        {
            _servicoBase = servicoBase;
        }

        public void Adiciona(TEntity entidade)
        {
            _servicoBase.Adiciona(entidade);
        }

        public IQueryable<TEntity> Consultar()
        {
            return _servicoBase.Consultar();
        }

        public void Atualiza(TEntity entidade)
        {
            _servicoBase.Atualiza(entidade);
        }

        public TEntity BuscaId(int id)
        {
            return _servicoBase.BuscaId(id);
        }

        public TEntity BuscaId(Guid id)
        {
            return _servicoBase.BuscaId(id);
        }

        public IEnumerable<TEntity> BuscaTodos()
        {
            return _servicoBase.BuscaTodos();
        }

        public IEnumerable<TEntity> Pesquisar(Func<TEntity, bool> lambda)
        {
            return _servicoBase.Pesquisar(lambda);
        }

        public void Dispose()
        {
            _servicoBase.Dispose();
        }
        
        public void Remove(TEntity entidade)
        {
            _servicoBase.Remove(entidade);
        }

        public TEntity BuscaId(long id)
        {
            return _servicoBase.BuscaId(id);
        }

        public void AdicionaEmLote(List<TEntity> listaEntidade)
        {
            _servicoBase.AdicionaEmLote(listaEntidade);
        }
    }
}