using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConstrutorTabelaAplicacaoServico : AplicacaoServicoBase<ConstrutorTabela>, IConstrutorTabelaAplicacaoServico
    {
        private readonly IConstrutorTabelaServico _construtorTabelaServico;

        public ConstrutorTabelaAplicacaoServico(IConstrutorTabelaServico construtorTabelaServico)
            : base(construtorTabelaServico)
        {
            _construtorTabelaServico = construtorTabelaServico;
        }

    }
}