using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class PerfilAplicacaoServico : AplicacaoServicoBase<Perfil>, IPerfilAplicacaoServico
    {
        private readonly IPerfilServico _perfilServico;

        public PerfilAplicacaoServico(IPerfilServico perfilServico) : base(perfilServico)
        {
            _perfilServico = perfilServico;
        }
    }
}
