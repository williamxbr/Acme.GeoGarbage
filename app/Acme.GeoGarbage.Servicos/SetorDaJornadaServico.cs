using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class SetorDaJornadaServico : ServicoBase<SetorDaJornada>, ISetorDaJornadaServico
    {
        private readonly ISetorDaJornadaRepositorio _setordajornadaRepositorio;

        public SetorDaJornadaServico(ISetorDaJornadaRepositorio setordajornadaRepositorio) : base(setordajornadaRepositorio)
        {
            _setordajornadaRepositorio = setordajornadaRepositorio;
        }
    }
}
