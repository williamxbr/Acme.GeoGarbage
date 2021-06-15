using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface ISetorDaJornadaAplicacaoServico : IAplicacaoServicoBase<SetorDaJornada>
    {
        int CalcularPorcentagemDeConclusao(SetorDaJornada setor);
        SinalizacaoPing PegarSinalizacaoPing(SetorDaJornada setor, PadraoDaConta padraoDaConta);
        SinalizacaoDeHorario PegarSinalizacaoHorario(SetorDaJornada setor);
        void AtualizaOdometroInicial(SetorDaJornada setorDaJornada);
        void AtualizaOdometroFinal(SetorDaJornada setorDaJornada);
        void AtualizaHorimetroInicial(SetorDaJornada setorDaJornada);
        void AtualizaHorimetroFinal(SetorDaJornada setorDaJornada);
    }
}
