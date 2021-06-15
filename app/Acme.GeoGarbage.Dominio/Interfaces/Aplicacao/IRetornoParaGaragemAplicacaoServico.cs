using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IRetornoParaGaragemAplicacaoServico : IAplicacaoServicoBase<RetornoParaGaragem>
    {
        void AtualizaOdometroPartida(RetornoParaGaragem retornoParaGaragem);
        void AtualizaOdometroChegada(RetornoParaGaragem retornoParaGaragem);
        void AtualizaHorimetroPartida(RetornoParaGaragem retornoParaGaragem);
        void AtualizaHorimetroChegada(RetornoParaGaragem retornoParaGaragem);
    }
}
