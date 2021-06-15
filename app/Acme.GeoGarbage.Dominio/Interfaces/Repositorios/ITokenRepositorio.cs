using Acme.GeoGarbage.Dominio.Entidades;
using System;

namespace Acme.GeoGarbage.Dominio.Interfaces.Repositorios
{
    public interface ITokenRepositorio : IRepositorioBase<Token>
    {
        Token GenerateToken(Guid userId);
        bool ValidaToken(Guid tokenId);
        bool Apaga(string tokenId);
        bool DeleteByUserId(int userId);
        Token BuscaPorToken(Guid autorizeToken);
    }
}
