using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class UsuarioDeClienteServico : ServicoBase<UsuarioDeCliente>, IUsuarioDeClienteServico
{
private readonly  IUsuarioDeClienteRepositorio _usuariosdeclienteRepositorio;

public UsuarioDeClienteServico(IUsuarioDeClienteRepositorio usuariosdeclienteRepositorio) : base(usuariosdeclienteRepositorio)
{
 _usuariosdeclienteRepositorio = usuariosdeclienteRepositorio;
}
}
}
