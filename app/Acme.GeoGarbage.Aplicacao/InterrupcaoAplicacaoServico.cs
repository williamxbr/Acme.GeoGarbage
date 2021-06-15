using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class InterrupcaoAplicacaoServico : AplicacaoServicoBase<Interrupcao>, IInterrupcaoAplicacaoServico
    {
        private readonly IInterrupcaoServico _interrupcaoServico;
        private readonly IVeiculoServico _veiculoServico;
        private readonly ILastMileageEngineServico _lastMileageEngineServico;


        public InterrupcaoAplicacaoServico(IInterrupcaoServico interrupcaoServico,
            IVeiculoServico veiculoServico,
            ILastMileageEngineServico lastMileageEngineServico) : base(interrupcaoServico)
        {
            _interrupcaoServico = interrupcaoServico;
            _veiculoServico = veiculoServico;
            _lastMileageEngineServico = lastMileageEngineServico;
        }

        public void AtualizaHorimetro(Interrupcao interrupcao)
        {
            Veiculo veiculo = _veiculoServico.BuscaId(interrupcao.IdVeiculo);
            interrupcao.Horimetro = _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, interrupcao.DataHoraInterrupcao);
            _interrupcaoServico.Atualiza(interrupcao);
        }

        public void AtualizaOdometro(Interrupcao interrupcao)
        {
            Veiculo veiculo = _veiculoServico.BuscaId(interrupcao.IdVeiculo);
            interrupcao.Odometro = _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, interrupcao.DataHoraInterrupcao);
            _interrupcaoServico.Atualiza(interrupcao);
        }
    }
}
