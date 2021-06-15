using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class GaragemAplicacaoServico : AplicacaoServicoBase<Garagem>, IGaragemAplicacaoServico
    {
        private readonly IGaragemServico _garagemServico;

        public GaragemAplicacaoServico(IGaragemServico garagemServico) : base(garagemServico)
        {
            _garagemServico = garagemServico;
        }
    }
}
