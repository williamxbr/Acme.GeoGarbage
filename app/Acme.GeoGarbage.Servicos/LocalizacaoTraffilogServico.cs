using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class LocalizacaoTraffilogServico : ServicoBase<LocalizacaoTraffilog>, ILocalizacaoTraffilogServico
    {
        private readonly ILocalizacaoTraffilogRepositorio _localizacaoTraffilogRepositorio;

        public LocalizacaoTraffilogServico(ILocalizacaoTraffilogRepositorio localizacaoTraffilogRepositorio) : base(localizacaoTraffilogRepositorio)
        {
            _localizacaoTraffilogRepositorio = localizacaoTraffilogRepositorio;
        }
    }
}