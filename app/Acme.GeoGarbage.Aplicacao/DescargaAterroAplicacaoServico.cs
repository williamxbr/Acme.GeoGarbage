using System.Linq;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class DescargaAterroAplicacaoServico : AplicacaoServicoBase<DescargaAterro>, IDescargaAterroAplicacaoServico
    {
        private readonly IDescargaAterroServico _descargaaterroServico;
        private readonly IDescargaDeColetaServico _descargaDeColetaServico;
        private readonly ISetorDaJornadaServico _setordajornadaServico;
        private readonly IJornadaServico _jornadaServico;
        private readonly IVeiculoServico _veiculoServico;
        private readonly ILastMileageEngineServico _lastMileageEngineServico;


        public DescargaAterroAplicacaoServico(IDescargaAterroServico descargaaterroServico,
            IDescargaDeColetaServico descargaDeColetaServico,
            ISetorDaJornadaServico setordajornadaServico,
            IJornadaServico jornadaServico,
            IVeiculoServico veiculoServico,
            ILastMileageEngineServico lastMileageEngineServico) : base(descargaaterroServico)
        {
            _descargaaterroServico = descargaaterroServico;
            _descargaDeColetaServico = descargaDeColetaServico;
            _setordajornadaServico = setordajornadaServico;
            _jornadaServico = jornadaServico;
            _veiculoServico = veiculoServico;
            _lastMileageEngineServico = lastMileageEngineServico;

        }

        public void AtualizaHorimetroInicioDescarga(DescargaAterro descargaAterro)
        {
            DescargaDeColeta descargaDeColeta = _descargaDeColetaServico.Consultar()
                .FirstOrDefault(p => p.IdDescargaAterro == descargaAterro.IdDescargaAterro);
            if (descargaDeColeta != null)
            {
                SetorDaJornada setorDaJornada = _setordajornadaServico.BuscaId(descargaDeColeta.IdSetorJornada);
                Jornada jornada = _jornadaServico.BuscaId(setorDaJornada.IdJornada);
                Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
                descargaAterro.InicioDescargaAterroHorimetro = _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, descargaAterro.InicioDescargaAterro);
                _descargaaterroServico.Atualiza(descargaAterro);
            }
        }

        public void AtualizaHorimetroInicioViagem(DescargaAterro descargaAterro)
        {
            DescargaDeColeta descargaDeColeta = _descargaDeColetaServico.Consultar()
                .FirstOrDefault(p => p.IdDescargaAterro == descargaAterro.IdDescargaAterro);
            if (descargaDeColeta != null)
            {
                SetorDaJornada setorDaJornada =
                    _setordajornadaServico.BuscaId(descargaDeColeta.IdSetorJornada);
                Jornada jornada = _jornadaServico.BuscaId(setorDaJornada.IdJornada);
                Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
                descargaAterro.HorimetroInicioDaViagemParaDescarga =
                    _lastMileageEngineServico.Horimetro(veiculo.IdentificacaoNoCliente, descargaAterro.InicioDaViagemParaDescarga);
                _descargaaterroServico.Atualiza(descargaAterro);
            }
        }

        public void AtualizaOdometroInicioDescarga(DescargaAterro descargaAterro)
        {
            DescargaDeColeta descargaDeColeta = _descargaDeColetaServico.Consultar()
                .FirstOrDefault(p => p.IdDescargaAterro == descargaAterro.IdDescargaAterro);
            if (descargaDeColeta != null)
            {
                SetorDaJornada setorDaJornada =
                    _setordajornadaServico.BuscaId(descargaDeColeta.IdSetorJornada);
                Jornada jornada = _jornadaServico.BuscaId(setorDaJornada.IdJornada);
                Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
                descargaAterro.InicioDescargaAterroOdometro =
                    _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, descargaAterro.InicioDescargaAterro);
                _descargaaterroServico.Atualiza(descargaAterro);
            }
        }

        public void AtualizaOdometroInicioViagem(DescargaAterro descargaAterro)
        {
            DescargaDeColeta descargaDeColeta = _descargaDeColetaServico.Consultar()
                .FirstOrDefault(p => p.IdDescargaAterro == descargaAterro.IdDescargaAterro);
            if (descargaDeColeta != null)
            {
                SetorDaJornada setorDaJornada =
                    _setordajornadaServico.BuscaId(descargaDeColeta.IdSetorJornada);
                Jornada jornada = _jornadaServico.BuscaId(setorDaJornada.IdJornada);
                Veiculo veiculo = _veiculoServico.BuscaId(jornada.IdVeiculo);
                descargaAterro.OdometroInicioDaViagemParaDescarga =
                    _lastMileageEngineServico.Odometro(veiculo.IdentificacaoNoCliente, descargaAterro.InicioDaViagemParaDescarga);
                _descargaaterroServico.Atualiza(descargaAterro);
            }
        }
    }
}
