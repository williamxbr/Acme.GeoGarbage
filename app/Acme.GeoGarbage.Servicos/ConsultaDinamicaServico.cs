using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ConsultaDinamicaServico : ServicoBase<ConsultaDinamica>, IConsultaDinamicaServico
    {
        private readonly IConsultaDinamicaRepositorio _consultaDinamicaRepositorio;

        public ConsultaDinamicaServico(IConsultaDinamicaRepositorio consultaDinamicaRepositorio)
            : base(consultaDinamicaRepositorio)
        {
            _consultaDinamicaRepositorio = consultaDinamicaRepositorio;
        }
    }
}