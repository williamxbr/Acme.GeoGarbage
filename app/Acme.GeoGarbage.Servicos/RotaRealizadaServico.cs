using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class RotaRealizadaServico : ServicoBase<RotaRealizada>, IRotaRealizadaServico
    {
        private readonly IRotaRealizadaRepositorio _rotarealizadaRepositorio;

        public RotaRealizadaServico(IRotaRealizadaRepositorio rotarealizadaRepositorio) : base(rotarealizadaRepositorio)
        {
            _rotarealizadaRepositorio = rotarealizadaRepositorio;
        }
    }
}
