using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Servicos
{
public class DeviceServico : ServicoBase<Device>, IDeviceServico
{
private readonly  IDeviceRepositorio _deviceRepositorio;

public DeviceServico(IDeviceRepositorio deviceRepositorio) : base(deviceRepositorio)
{
 _deviceRepositorio = deviceRepositorio;
}
}
}
