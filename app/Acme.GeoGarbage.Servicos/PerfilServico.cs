using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class PerfilServico : ServicoBase<Perfil>, IPerfilServico
{
private readonly  IPerfilRepositorio _perfilRepositorio;

public PerfilServico(IPerfilRepositorio perfilRepositorio) : base(perfilRepositorio)
{
 _perfilRepositorio = perfilRepositorio;
}
}
}
