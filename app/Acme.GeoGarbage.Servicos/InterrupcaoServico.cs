using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class InterrupcaoServico : ServicoBase<Interrupcao>, IInterrupcaoServico
{
private readonly  IInterrupcaoRepositorio _interrupcaoRepositorio;

public InterrupcaoServico(IInterrupcaoRepositorio interrupcaoRepositorio) : base(interrupcaoRepositorio)
{
 _interrupcaoRepositorio = interrupcaoRepositorio;
}
}
}
