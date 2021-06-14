using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class ConstrutorChaveEstrangeiraServico : ServicoBase<ConstrutorChaveEstrangeira>, IConstrutorChaveEstrangeiraServico
    {

        private readonly IConstrutorChaveEstrangeiraRepositorio _construtorChaveEstrangeiraRepositorio;

        public ConstrutorChaveEstrangeiraServico(IConstrutorChaveEstrangeiraRepositorio construtorChaveEstrangeiraRepositorio) 
            : base(construtorChaveEstrangeiraRepositorio)
        {
            _construtorChaveEstrangeiraRepositorio = construtorChaveEstrangeiraRepositorio;
        }
    }
}