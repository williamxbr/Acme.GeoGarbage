using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class RotaRealizadaAplicacaoServico : AplicacaoServicoBase<RotaRealizada>, IRotaRealizadaAplicacaoServico
    {
        private readonly IRotaRealizadaServico _rotarealizadaServico;

        public RotaRealizadaAplicacaoServico(IRotaRealizadaServico rotarealizadaServico) : base(rotarealizadaServico)
        {
            _rotarealizadaServico = rotarealizadaServico;
        }
    }
}
