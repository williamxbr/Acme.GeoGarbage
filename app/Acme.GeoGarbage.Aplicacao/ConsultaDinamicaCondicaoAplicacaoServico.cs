using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConsultaDinamicaCondicaoAplicacaoServico : AplicacaoServicoBase<ConsultaDinamicaCondicao>, IConsultaDinamicaCondicaoAplicacaoServico
    {
        private readonly IConsultaDinamicaCondicaoServico _consultaDinamicaCondicaoServico;

        public ConsultaDinamicaCondicaoAplicacaoServico(IConsultaDinamicaCondicaoServico consultaDinamicaCondicaoServico)
            : base(consultaDinamicaCondicaoServico)
        {
            _consultaDinamicaCondicaoServico = consultaDinamicaCondicaoServico;
        }
    }
}