using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class SetorAplicacaoServico : AplicacaoServicoBase<Setor>, ISetorAplicacaoServico
    {
        private readonly ISetorServico _setorServico;

        public SetorAplicacaoServico(ISetorServico setorServico) : base(setorServico)
        {
            _setorServico = setorServico;
        }
    }
}
