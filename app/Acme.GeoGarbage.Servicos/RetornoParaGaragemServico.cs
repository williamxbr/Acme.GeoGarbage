using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class RetornoParaGaragemServico : ServicoBase<RetornoParaGaragem>, IRetornoParaGaragemServico
{
private readonly  IRetornoParaGaragemRepositorio _retornoparagaragemRepositorio;

public RetornoParaGaragemServico(IRetornoParaGaragemRepositorio retornoparagaragemRepositorio) : base(retornoparagaragemRepositorio)
{
 _retornoparagaragemRepositorio = retornoparagaragemRepositorio;
}
}
}
