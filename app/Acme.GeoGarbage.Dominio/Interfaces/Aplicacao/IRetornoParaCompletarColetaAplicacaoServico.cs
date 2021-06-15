using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IRetornoParaCompletarColetaAplicacaoServico : IAplicacaoServicoBase<RetornoParaCompletarColeta>
    {
        void AtualizaOdometro(RetornoParaCompletarColeta retornoParaCompletarColeta);
        void AtualizaHorimetro(RetornoParaCompletarColeta retornoParaCompletarColeta);
    }
}
