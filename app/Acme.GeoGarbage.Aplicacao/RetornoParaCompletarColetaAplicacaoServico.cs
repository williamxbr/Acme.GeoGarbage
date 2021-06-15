using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class RetornoParaCompletarColetaAplicacaoServico : AplicacaoServicoBase<RetornoParaCompletarColeta>, IRetornoParaCompletarColetaAplicacaoServico
    {
        private readonly IRetornoParaCompletarColetaServico _retornoparacompletarcoletaServico;
        private readonly ISetorDaJornadaServico _setordajornadaServico;
        private readonly IJornadaServico _jornadaServico;
        private readonly IVeiculoServico _veiculoServico;
        private readonly ILastMileageEngineServico _lastMileageEngineServico;


        public RetornoParaCompletarColetaAplicacaoServico(IRetornoParaCompletarColetaServico retornoparacompletarcoletaServico, 
            ISetorDaJornadaServico setordajornadaServico,
            IJornadaServico jornadaServico,
            IVeiculoServico veiculoServico,
            ILastMileageEngineServico lastMileageEngineServico) : base(retornoparacompletarcoletaServico)
        {
            _retornoparacompletarcoletaServico = retornoparacompletarcoletaServico;
            _setordajornadaServico = setordajornadaServico;
            _jornadaServico = jornadaServico;
            _veiculoServico = veiculoServico;
            _lastMileageEngineServico = lastMileageEngineServico;
        }

        public void AtualizaOdometro(RetornoParaCompletarColeta retornoParaCompletarColeta)
        {
            SetorDaJornada setorDaJornada = _setordajornadaServico.BuscaId(retornoParaCompletarColeta.IdSetorJornada);
            Jornada jornada = _jornadaServico.BuscaId(setorDaJornada.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            retornoParaCompletarColeta.Odometro = _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, retornoParaCompletarColeta.DataHoraRetorno);
            _retornoparacompletarcoletaServico.Atualiza(retornoParaCompletarColeta);
        }

        public void AtualizaHorimetro(RetornoParaCompletarColeta retornoParaCompletarColeta)
        {
            SetorDaJornada setorDaJornada = _setordajornadaServico.BuscaId(retornoParaCompletarColeta.IdSetorJornada);
            Jornada jornada = _jornadaServico.BuscaId(setorDaJornada.IdJornada);
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            retornoParaCompletarColeta.Horimetro = _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, retornoParaCompletarColeta.DataHoraRetorno);
            _retornoparacompletarcoletaServico.Atualiza(retornoParaCompletarColeta);
        }
    }
}
