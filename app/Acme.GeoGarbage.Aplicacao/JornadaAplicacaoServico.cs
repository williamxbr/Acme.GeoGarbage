using System.Data;
using System.Linq;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class JornadaAplicacaoServico : AplicacaoServicoBase<Jornada>, IJornadaAplicacaoServico
    {
        private readonly IJornadaServico _jornadaServico;
        private readonly ILastMileageEngineServico _lastMileageEngineServico;
        private readonly IVeiculoServico _veiculoServico;

        public JornadaAplicacaoServico(IJornadaServico jornadaServico, ILastMileageEngineServico lastMileageEngineServico, IVeiculoServico veiculoServico) : base(jornadaServico)
        {
            _jornadaServico = jornadaServico;
            _lastMileageEngineServico = lastMileageEngineServico;
            _veiculoServico = veiculoServico;
        }

        public void AtualizaOdometroInicial(Jornada jornada)
        {
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            jornada.OdometroInicial =
                _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, jornada.InicioJornada);
            _jornadaServico.Atualiza(jornada);
        }

        public void AtualizaHorimetroInicial(Jornada jornada)
        {
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            jornada.HorimetroInicial =
                _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, jornada.InicioJornada);
            _jornadaServico.Atualiza(jornada);
        }

        public void AtualizaOdometroFinal(Jornada jornada)
        {
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            jornada.OdometroFinal =
                _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, jornada.FimDaJornada);
            _jornadaServico.Atualiza(jornada);
        }

        public void AtualizaHorimetroFinal(Jornada jornada)
        {
            Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
            jornada.HorimetroFinal =
                _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, jornada.FimDaJornada);
            _jornadaServico.Atualiza(jornada);
        }
    }
}
