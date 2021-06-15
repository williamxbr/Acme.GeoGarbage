using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ViagemTraffilogAplicacaoServico : AplicacaoServicoBase<ViagemTraffilog>, IViagemTraffilogAplicacaoServico
    {
        private readonly IViagemTraffilogServico _viagemTraffilogServico;

        public ViagemTraffilogAplicacaoServico(IViagemTraffilogServico viagemTraffilogServico) : base(viagemTraffilogServico)
        {
            _viagemTraffilogServico = viagemTraffilogServico;
        }
    }
}