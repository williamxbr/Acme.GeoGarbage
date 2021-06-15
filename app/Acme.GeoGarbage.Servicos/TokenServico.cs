using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;
using System;

namespace Acme.GeoGarbage.Servicos
{
    public class TokenServico : ServicoBase<Token>, ITokenServico
    {
        private readonly ITokenRepositorio _tokenRepositorio;

        public TokenServico(ITokenRepositorio tokenRepositorio) : base(tokenRepositorio)
        {
            _tokenRepositorio = tokenRepositorio;
        }

        public bool Apaga(Guid tokenId)
        {
            throw new NotImplementedException();
        }

        public Token BuscaPorToken(Guid autorizeToken)
        {
            return _tokenRepositorio.BuscaPorToken(autorizeToken);
        }

        public bool DeleteByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Token GenerateToken(Guid userId)
        {
            Guid token = Guid.NewGuid();
            DateTime issuedOn = DateTime.Now;
            //DateTime expiredOn = DateTime.Now.AddSeconds(
            //                                  Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            DateTime expiredOn = DateTime.Now.AddSeconds(900);
            var tokendomain = new Token
            {
                IdUsuario = userId,
                AutorizeToken = token,
                Inicio = issuedOn,
                Expira = expiredOn
            };

            _tokenRepositorio.Adiciona(tokendomain);

            var tokenModel = new Token
            {
                IdUsuario = userId,
                Inicio = issuedOn,
                Expira = expiredOn,
                AutorizeToken = token
            };

            return tokenModel;
        }

        public bool Kill(string tokenId)
        {
            throw new NotImplementedException();
        }

        public bool ValidaToken(Guid tokenId)
        {
            Token token = _tokenRepositorio.BuscaPorToken(tokenId);
            if (token != null && !(DateTime.Now > token.Expira))
            {
                //token.Expira = token.Expira.AddSeconds(
                //                              Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                token.Expira = token.Expira.AddSeconds(900);

                _tokenRepositorio.Atualiza(token);
                return true;
            }
            return false;
        }

    }
}
