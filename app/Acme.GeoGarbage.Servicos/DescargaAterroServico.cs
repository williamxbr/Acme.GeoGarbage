using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class DescargaAterroServico : ServicoBase<DescargaAterro>, IDescargaAterroServico
    {
        private readonly IDescargaAterroRepositorio _descargaaterroRepositorio;

        public DescargaAterroServico(IDescargaAterroRepositorio descargaaterroRepositorio) : base(descargaaterroRepositorio)
        {
            _descargaaterroRepositorio = descargaaterroRepositorio;
        }
    }
}
