using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ConfiguracaoAppServico : ServicoBase<ConfiguracaoApp>, IConfiguracaoAppServico
    {
        private readonly IConfiguracaoAppRepositorio _configuracaoAppRepositorio;

        public ConfiguracaoAppServico(IConfiguracaoAppRepositorio configuracaoAppRepositorio) : base(configuracaoAppRepositorio)
        {
            _configuracaoAppRepositorio = configuracaoAppRepositorio;
        }
    }
}
