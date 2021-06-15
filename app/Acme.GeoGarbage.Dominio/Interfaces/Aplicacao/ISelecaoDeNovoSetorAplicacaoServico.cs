using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface ISelecaoDeNovoSetorAplicacaoServico : IAplicacaoServicoBase<SelecaoDeNovoSetor>
    {
        void AtualizaOdometro(SelecaoDeNovoSetor selecaoDeNovoSetor);
        void AtualizaHorimetro(SelecaoDeNovoSetor selecaoDeNovoSetor);
    }
}
