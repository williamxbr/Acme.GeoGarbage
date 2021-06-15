using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class RecursoDaJornadaServico : ServicoBase<RecursoDaJornada>, IRecursoDaJornadaServico
{
private readonly  IRecursoDaJornadaRepositorio _recursosdajornadaRepositorio;

public RecursoDaJornadaServico(IRecursoDaJornadaRepositorio recursosdajornadaRepositorio) : base(recursosdajornadaRepositorio)
{
 _recursosdajornadaRepositorio = recursosdajornadaRepositorio;
}
}
}
