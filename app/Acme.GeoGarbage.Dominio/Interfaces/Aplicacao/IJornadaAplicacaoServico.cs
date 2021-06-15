using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IJornadaAplicacaoServico : IAplicacaoServicoBase<Jornada>
    {
        void AtualizaOdometroInicial(Jornada jornada);
        void AtualizaOdometroFinal(Jornada jornada);
        void AtualizaHorimetroInicial(Jornada jornada);
        void AtualizaHorimetroFinal(Jornada jornada);
    }
}
