using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConsultaDinamicaTabelaAplicacaoServico : AplicacaoServicoBase<ConsultaDinamicaTabela>, IConsultaDinamicaTabelaAplicacaoServico
    {
        private readonly IConsultaDinamicaTabelaServico _consultaDinamicaTabelaServico;

        public ConsultaDinamicaTabelaAplicacaoServico(IConsultaDinamicaTabelaServico consultaDinamicaTabelaServico)
            : base(consultaDinamicaTabelaServico)
        {
            _consultaDinamicaTabelaServico = consultaDinamicaTabelaServico;
        }
    }
}