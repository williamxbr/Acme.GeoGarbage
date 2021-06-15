using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class LocalizacaoTraffilogAplicacaoServico : AplicacaoServicoBase<LocalizacaoTraffilog>, ILocalizacaoTraffilogAplicacaoServico
    {
        private readonly ILocalizacaoTraffilogServico _localizacaoTraffilogServico;

        public LocalizacaoTraffilogAplicacaoServico(ILocalizacaoTraffilogServico localizacaoTraffilogServico) : base(localizacaoTraffilogServico)
        {
            _localizacaoTraffilogServico = localizacaoTraffilogServico;
        }
    }
}