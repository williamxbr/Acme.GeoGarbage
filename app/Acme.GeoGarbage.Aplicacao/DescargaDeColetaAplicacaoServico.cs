using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class DescargaDeColetaAplicacaoServico : AplicacaoServicoBase<DescargaDeColeta>, IDescargaDeColetaAplicacaoServico
    {
        private readonly IDescargaDeColetaServico _descargadecoletaServico;

        public DescargaDeColetaAplicacaoServico(IDescargaDeColetaServico descargadecoletaServico) : base(descargadecoletaServico)
        {
            _descargadecoletaServico = descargadecoletaServico;
        }
    }
}
