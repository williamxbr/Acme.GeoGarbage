using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class RecursoDeColetaServico : ServicoBase<RecursoDeColeta>, IRecursoDeColetaServico
    {
        private readonly IRecursoDeColetaRepositorio _recursosDeColetaRepositorio;

        public RecursoDeColetaServico(IRecursoDeColetaRepositorio recursosDeColetaRepositorio) : base(recursosDeColetaRepositorio)
        {
            _recursosDeColetaRepositorio = recursosDeColetaRepositorio;
        }
    }
}
