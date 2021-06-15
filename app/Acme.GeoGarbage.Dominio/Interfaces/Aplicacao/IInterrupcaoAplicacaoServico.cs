using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IInterrupcaoAplicacaoServico : IAplicacaoServicoBase<Interrupcao>
    {
        void AtualizaOdometro(Interrupcao interrupcao);
        void AtualizaHorimetro(Interrupcao interrupcao);
    }
}
