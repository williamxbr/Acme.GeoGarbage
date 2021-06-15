using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class JornadaServico : ServicoBase<Jornada>, IJornadaServico
    {
        private readonly IJornadaRepositorio _jornadaRepositorio;

        public JornadaServico(IJornadaRepositorio jornadaRepositorio) : base(jornadaRepositorio)
        {
            _jornadaRepositorio = jornadaRepositorio;
        }
    }
}
