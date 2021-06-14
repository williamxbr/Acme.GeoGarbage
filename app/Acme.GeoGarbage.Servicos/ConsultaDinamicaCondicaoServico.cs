using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ConsultaDinamicaCondicaoServico : ServicoBase<ConsultaDinamicaCondicao>, IConsultaDinamicaCondicaoServico
    {
        private readonly IConsultaDinamicaCondicaoRepositorio _consultaDinamicaCondicaoRepositorio;

        public ConsultaDinamicaCondicaoServico(IConsultaDinamicaCondicaoRepositorio consultaDinamicaCondicaoRepositorio)
            : base(consultaDinamicaCondicaoRepositorio)
        {
            _consultaDinamicaCondicaoRepositorio = consultaDinamicaCondicaoRepositorio;
        }
    }
}