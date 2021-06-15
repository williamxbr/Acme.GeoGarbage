using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class VeiculoAPITraffilogAplicacaoServico : AplicacaoServicoBase<VeiculoAPITraffilog>, IVeiculoAPITraffilogAplicacaoServico
    {

        private readonly IVeiculoAPITraffilogServico _veiculoApiTraffilogServico;

        public VeiculoAPITraffilogAplicacaoServico(IVeiculoAPITraffilogServico veiculoApiTraffilogServico)
            : base(veiculoApiTraffilogServico)
        {
            _veiculoApiTraffilogServico = veiculoApiTraffilogServico;
        }

    }
}