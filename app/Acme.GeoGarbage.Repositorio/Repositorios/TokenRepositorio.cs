using System;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using System.Linq;

namespace Acme.GeoGarbage.Repositorio.Repositorios
{
    public class TokenRepositorio : RepositorioBase<Token>, ITokenRepositorio
    {
        public bool Apaga(string tokenId)
        {
            throw new NotImplementedException();
        }

        public Token BuscaPorToken(Guid autorizeToken)
        {
            return Db.Tokens.FirstOrDefault(p => p.AutorizeToken == autorizeToken);
        }

        public bool DeleteByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Token GenerateToken(Guid userId)
        {
            throw new NotImplementedException();
        }

        public bool Kill(string tokenId)
        {
            throw new NotImplementedException();
        }

        public bool ValidaToken(Guid tokenId)
        {
            throw new NotImplementedException();
        }
    }
}
