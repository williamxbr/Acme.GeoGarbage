using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
    public class MotivoInterrupcaoServico : ServicoBase<MotivoInterrupcao>, IMotivoInterrupcaoServico
    {
        private readonly IMotivoInterrupcaoRepositorio _motivosInterrupcaoRepositorio;

        public MotivoInterrupcaoServico(IMotivoInterrupcaoRepositorio motivosInterrupcaoRepositorio) : base(motivosInterrupcaoRepositorio)
        {
            _motivosInterrupcaoRepositorio = motivosInterrupcaoRepositorio;
        }
    }
}

