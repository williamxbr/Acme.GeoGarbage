using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IDescargaAterroAplicacaoServico : IAplicacaoServicoBase<DescargaAterro>
    {
        void AtualizaOdometroInicioDescarga(DescargaAterro descargaAterro);
        void AtualizaOdometroInicioViagem(DescargaAterro descargaAterro);
        void AtualizaHorimetroInicioDescarga(DescargaAterro descargaAterro);
        void AtualizaHorimetroInicioViagem(DescargaAterro descargaAterro);
    }
}
