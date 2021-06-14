using System;
using System.Collections.Generic;
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

        public void Atualiza(TEntity entidade)
        {
            _servicoBase.Atualiza(entidade);
        }

        public TEntity BuscaId(int id)
        {
            return _servicoBase.BuscaId(id);
        }

        public IEnumerable<TEntity> BuscaTodos()
        {
            return _servicoBase.BuscaTodos();
        }

        public void Dispose()
        {
            _servicoBase.Dispose();
        }

        public void Remove(TEntity entidade)
        {
            _servicoBase.Remove(entidade);
        }

    }
}