using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ConstrutorTabelaServico : ServicoBase<ConstrutorTabela>, IConstrutorTabelaServico
    {

        private readonly IConstrutorTabelaRepositorio _construtorTabelaRepositorio;

        public ConstrutorTabelaServico(IConstrutorTabelaRepositorio construtorTabelaRepositorio) 
            : base(construtorTabelaRepositorio)
        {
            _construtorTabelaRepositorio = construtorTabelaRepositorio;
        }
    }
}