using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConstrutorChaveEstrangeiraAplicacaoServico : AplicacaoServicoBase<ConstrutorChaveEstrangeira>, IConstrutorChaveEstrangeiraAplicacaoServico
    {
        private readonly IConstrutorChaveEstrangeiraServico _construtorChaveEstrangeiraServico;

        public ConstrutorChaveEstrangeiraAplicacaoServico(IConstrutorChaveEstrangeiraServico construtorChaveEstrangeiraServico)
            : base(construtorChaveEstrangeiraServico)
        {
            _construtorChaveEstrangeiraServico = construtorChaveEstrangeiraServico;
        }

    }
}