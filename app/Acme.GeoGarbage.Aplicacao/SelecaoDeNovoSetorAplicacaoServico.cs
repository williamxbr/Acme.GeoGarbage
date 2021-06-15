using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class SelecaoDeNovoSetorAplicacaoServico : AplicacaoServicoBase<SelecaoDeNovoSetor>, ISelecaoDeNovoSetorAplicacaoServico
    {
        private readonly ISelecaoDeNovoSetorServico _selecaodenovosetorServico;
        private readonly IJornadaServico _jornadaServico;
        private readonly IVeiculoServico _veiculoServico;
        private readonly ILastMileageEngineServico _lastMileageEngineServico;


        public SelecaoDeNovoSetorAplicacaoServico(ISelecaoDeNovoSetorServico selecaodenovosetorServico,
            IJornadaServico jornadaServico,
            IVeiculoServico veiculoServico,
            ILastMileageEngineServico lastMileageEngineServico) : base(selecaodenovosetorServico)
        {
            _selecaodenovosetorServico = selecaodenovosetorServico;
            _jornadaServico = jornadaServico;
            _veiculoServico = veiculoServico;
            _lastMileageEngineServico = lastMileageEngineServico;
        }

        public void AtualizaOdometro(SelecaoDeNovoSetor selecaoDeNovoSetor)
        {
            Jornada jornada = _jornadaServico.BuscaId(selecaoDeNovoSetor.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            selecaoDeNovoSetor.Odometro = _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, selecaoDeNovoSetor.DataHoraSelecao);
            _selecaodenovosetorServico.Atualiza(selecaoDeNovoSetor);
        }

        public void AtualizaHorimetro(SelecaoDeNovoSetor selecaoDeNovoSetor)
        {
            Jornada jornada = _jornadaServico.BuscaId(selecaoDeNovoSetor.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            selecaoDeNovoSetor.Horimetro = _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, selecaoDeNovoSetor.DataHoraSelecao);
            _selecaodenovosetorServico.Atualiza(selecaoDeNovoSetor);
        }
    }
}
