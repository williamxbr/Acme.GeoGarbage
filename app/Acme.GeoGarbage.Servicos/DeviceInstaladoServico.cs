using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class DeviceInstaladoServico : ServicoBase<DeviceInstalado>, IDeviceInstaladoServico
{
private readonly  IDeviceInstaladoRepositorio _deviceinstaladoRepositorio;

public DeviceInstaladoServico(IDeviceInstaladoRepositorio deviceinstaladoRepositorio) : base(deviceinstaladoRepositorio)
{
 _deviceinstaladoRepositorio = deviceinstaladoRepositorio;
}
}
}
