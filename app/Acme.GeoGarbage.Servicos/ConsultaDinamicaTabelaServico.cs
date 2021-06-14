using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ConsultaDinamicaTabelaServico : ServicoBase<ConsultaDinamicaTabela>, IConsultaDinamicaTabelaServico
    {
        private readonly IConsultaDinamicaTabelaRepositorio _consultaDinaminaTabelaRepositorio;

        public ConsultaDinamicaTabelaServico(IConsultaDinamicaTabelaRepositorio consultaDinaminaTabelaRepositorio)
            : base(consultaDinaminaTabelaRepositorio)
        {
            _consultaDinaminaTabelaRepositorio = consultaDinaminaTabelaRepositorio;
        }
    }
}