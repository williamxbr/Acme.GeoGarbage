using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ViagemTraffilogServico : ServicoBase<ViagemTraffilog>, IViagemTraffilogServico
    {
        private readonly IViagemTraffilogRepositorio _viagemTraffilogRepositorio;

        public ViagemTraffilogServico(IViagemTraffilogRepositorio viagemTraffilogRepositorio) : base(viagemTraffilogRepositorio)
        {
            _viagemTraffilogRepositorio = viagemTraffilogRepositorio;
        }
    }
}