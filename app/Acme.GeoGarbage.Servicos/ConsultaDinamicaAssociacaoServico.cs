using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ConsultaDinamicaAssociacaoServico : ServicoBase<ConsultaDinamicaAssociacao>, IConsultaDinamicaAssociacaoServico
    {
        private readonly IConsultaDinamicaAssociacaoRepositorio _consultaDinamicaAssociacaoRepositorio;

        public ConsultaDinamicaAssociacaoServico(IConsultaDinamicaAssociacaoRepositorio consultaDinamicaAssociacaoRepositorio)
            : base(consultaDinamicaAssociacaoRepositorio)
        {
            _consultaDinamicaAssociacaoRepositorio = consultaDinamicaAssociacaoRepositorio;
        }

    }
}