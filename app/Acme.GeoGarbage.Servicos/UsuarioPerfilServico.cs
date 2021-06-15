using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class UsuarioPerfilServico : ServicoBase<UsuarioPerfil>, IUsuarioPerfilServico
{
private readonly  IUsuarioPerfilRepositorio _usuariosperfilRepositorio;

public UsuarioPerfilServico(IUsuarioPerfilRepositorio usuariosperfilRepositorio) : base(usuariosperfilRepositorio)
{
 _usuariosperfilRepositorio = usuariosperfilRepositorio;
}
}
}
