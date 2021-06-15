using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class RetornoParaGaragemAplicacaoServico : AplicacaoServicoBase<RetornoParaGaragem>, IRetornoParaGaragemAplicacaoServico
    {
        private readonly IRetornoParaGaragemServico _retornoparagaragemServico;
        private readonly IJornadaServico _jornadaServico;
        private readonly IVeiculoServico _veiculoServico;
        private readonly ILastMileageEngineServico _lastMileageEngineServico;

        public RetornoParaGaragemAplicacaoServico(IRetornoParaGaragemServico retornoparagaragemServico,
            IJornadaServico jornadaServico,
            IVeiculoServico veiculoServico,
            ILastMileageEngineServico lastMileageEngineServico) : base(retornoparagaragemServico)
        {
            _retornoparagaragemServico = retornoparagaragemServico;
            _jornadaServico = jornadaServico;
            _veiculoServico = veiculoServico;
            _lastMileageEngineServico = lastMileageEngineServico;
        }

        public void AtualizaHorimetroChegada(RetornoParaGaragem retornoParaGaragem)
        {
            Jornada jornada = _jornadaServico.BuscaId(retornoParaGaragem.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            retornoParaGaragem.HorimetroChegada = _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, retornoParaGaragem.DataHoraChegada);
            _retornoparagaragemServico.Atualiza(retornoParaGaragem);
        }

        public void AtualizaHorimetroPartida(RetornoParaGaragem retornoParaGaragem)
        {
            Jornada jornada = _jornadaServico.BuscaId(retornoParaGaragem.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            retornoParaGaragem.HorimetroPartida = _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, retornoParaGaragem.DataHoraInicioRetorno);
            _retornoparagaragemServico.Atualiza(retornoParaGaragem);
        }

        public void AtualizaOdometroChegada(RetornoParaGaragem retornoParaGaragem)
        {
            Jornada jornada = _jornadaServico.BuscaId(retornoParaGaragem.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            retornoParaGaragem.OdometroChegada = _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, retornoParaGaragem.DataHoraChegada);
            _retornoparagaragemServico.Atualiza(retornoParaGaragem);
        }

        public void AtualizaOdometroPartida(RetornoParaGaragem retornoParaGaragem)
        {
            Jornada jornada = _jornadaServico.BuscaId(retornoParaGaragem.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            retornoParaGaragem.OdometroPartida = _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, retornoParaGaragem.DataHoraInicioRetorno);
            _retornoparagaragemServico.Atualiza(retornoParaGaragem);
        }
    }
}
