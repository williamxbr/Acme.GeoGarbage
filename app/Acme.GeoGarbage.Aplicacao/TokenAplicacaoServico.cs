using System;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class TokenAplicacaoServico : AplicacaoServicoBase<Token>, ITokenAplicacaoServico
    {
        private readonly ITokenServico _tokenServico;

        public TokenAplicacaoServico(ITokenServico tokenServico) : base(tokenServico)
        {
            _tokenServico = tokenServico;
        }

        public bool Apaga(Guid tokenId)
        {
            throw new NotImplementedException();
        }

        public Token BuscaPorToken(Guid autorizeToken)
        {
            return _tokenServico.BuscaPorToken(autorizeToken);
        }

        public bool DeleteByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Token GenerateToken(Guid userId)
        {
            return _tokenServico.GenerateToken(userId);
        }

        public bool Kill(string tokenId)
        {
            throw new NotImplementedException();
        }

        public bool ValidaToken(Guid tokenId)
        {
            return _tokenServico.ValidaToken(tokenId);
        }
    }
}
