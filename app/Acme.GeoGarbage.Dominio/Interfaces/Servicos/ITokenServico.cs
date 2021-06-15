using Acme.GeoGarbage.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.GeoGarbage.Dominio.Interfaces.Servicos
{
    public interface ITokenServico : IServicoBase<Token>
    {
        Token GenerateToken(Guid userId);
        bool ValidaToken(Guid tokenId);
        bool Apaga(Guid tokenId);
        bool DeleteByUserId(int userId);
        Token BuscaPorToken(Guid autorizeToken);

    }
}
