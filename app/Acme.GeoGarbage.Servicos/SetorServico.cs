using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class SetorServico : ServicoBase<Setor>, ISetorServico
    {
        private readonly ISetorRepositorio _setorRepositorio;

        public SetorServico(ISetorRepositorio setorRepositorio) : base(setorRepositorio)
        {
            _setorRepositorio = setorRepositorio;
        }
    }
}
