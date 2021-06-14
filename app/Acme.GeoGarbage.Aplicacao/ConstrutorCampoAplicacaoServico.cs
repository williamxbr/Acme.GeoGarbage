using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConstrutorCampoAplicacaoServico : AplicacaoServicoBase<ConstrutorCampo>, IConstrutorCampoAplicacaoServico
    {
        private readonly IConstrutorCampoServico _construtorCampoServico;

        public ConstrutorCampoAplicacaoServico(IConstrutorCampoServico construtorCampoServico)
            : base(construtorCampoServico)
        {
            _construtorCampoServico = construtorCampoServico;
        }

    }
}