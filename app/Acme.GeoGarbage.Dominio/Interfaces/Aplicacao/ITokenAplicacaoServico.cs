using Acme.GeoGarbage.Dominio.Entidades;
using System;

namespace Acme.GeoGarbage.Dominio.Interfaces.Aplicacao
{
    public interface ITokenAplicacaoServico : IAplicacaoServicoBase<Token>
    {
        Token GenerateToken(Guid userId);
        bool ValidaToken(Guid tokenId);
        bool Apaga(Guid tokenId);
        bool DeleteByUserId(int userId);
        Token BuscaPorToken(Guid autorizeToken);

    }
}
