using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConsultaDinamicaAplicacaoServico : AplicacaoServicoBase<ConsultaDinamica>, IConsultaDinamicaAplicacaoServico
    {
        private readonly IConsultaDinamicaServico _consultaDinamicaServico;

        public ConsultaDinamicaAplicacaoServico(IConsultaDinamicaServico consultaDinamicaServico)
            : base(consultaDinamicaServico)
        {
            _consultaDinamicaServico = consultaDinamicaServico;
        }
    }
}