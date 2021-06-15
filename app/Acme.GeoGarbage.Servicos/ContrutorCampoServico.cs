using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ConstrutorCampoServico : ServicoBase<ConstrutorCampo>, IConstrutorCampoServico
    {
        private readonly IConstrutorCampoRepositorio _construtorCampoRepositorio;

        public ConstrutorCampoServico(IConstrutorCampoRepositorio construtorCampoRepositorio)
            : base(construtorCampoRepositorio)
        {
            _construtorCampoRepositorio = construtorCampoRepositorio;
        }

    }
}