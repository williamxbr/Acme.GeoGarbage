using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ConsultaDinamicaCampoServico : ServicoBase<ConsultaDinamicaCampo>, IConsultaDinamicaCampoServico
    {
        private readonly IConsultaDinamicaCampoRepositorio _consultaDinamicaCampoRepositorio;

        public ConsultaDinamicaCampoServico(IConsultaDinamicaCampoRepositorio consultaDinamicaCampoRepositorio)
            : base(consultaDinamicaCampoRepositorio)
        {
            _consultaDinamicaCampoRepositorio = consultaDinamicaCampoRepositorio;
        }

    }
}