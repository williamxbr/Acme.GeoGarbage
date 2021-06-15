using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConfiguracaoAppAplicacaoServico : AplicacaoServicoBase<ConfiguracaoApp>, IConfiguracaoAppAplicacaoServico
    {
        private readonly IConfiguracaoAppServico _configuracaoAppServico;

        public ConfiguracaoAppAplicacaoServico(IConfiguracaoAppServico configuracaoAppServico) : base(configuracaoAppServico)
        {
            _configuracaoAppServico = configuracaoAppServico;
        }
    }
}
