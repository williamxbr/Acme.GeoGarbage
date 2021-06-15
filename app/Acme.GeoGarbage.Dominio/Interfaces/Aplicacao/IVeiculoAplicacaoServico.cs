using System;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface IVeiculoAplicacaoServico : IAplicacaoServicoBase<Veiculo>
    {
        bool ExisteMovimentacao(Guid idVeiculo, DateTime data);
    }
}
