using System;
using System.Collections;
using System.Linq;
using System.Web.Http;
using Acme.GeoGarbage.Dominio.Classes;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Enums;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class DeviceInstaladoController : ApiController
    {
        private readonly IDeviceInstaladoAplicacaoServico _deviceInstaladoAplicacaoServico;
        private readonly IVeiculoAplicacaoServico _veiculoAplicacaoServico;
        private readonly IUsuarioAplicacaoServico _usuarioAplicacaoServico;
        private readonly IDeviceAplicacaoServico _deviceAplicacaoServico;

        public DeviceInstaladoController(IDeviceInstaladoAplicacaoServico deviceInstaladoAplicacaoServico,
                                         IVeiculoAplicacaoServico veiculoAplicacaoServico,
                                         IUsuarioAplicacaoServico usuarioAplicacaoServico,
                                         IDeviceAplicacaoServico deviceAplicacaoServico)
        {
            _deviceInstaladoAplicacaoServico = deviceInstaladoAplicacaoServico;
            _veiculoAplicacaoServico = veiculoAplicacaoServico;
            _usuarioAplicacaoServico = usuarioAplicacaoServico;
            _deviceAplicacaoServico = deviceAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _deviceInstaladoAplicacaoServico.Dispose();
                _veiculoAplicacaoServico.Dispose();
                _usuarioAplicacaoServico.Dispose();
                _deviceAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpGet]
        public IEnumerable Get()
        {
            var deviceinstalado = _deviceInstaladoAplicacaoServico.BuscaTodos();
            return deviceinstalado;
        }


        [HttpPost]
        public RetornoConfiguracaoDevice post_SalvarConfiguracaoDevice(Guid iuUsuario, Guid iuCliente, string codigoVeiculo, string chaveDevice)
        {
            ///api/deviceinstalado/post_SalvarConfiguracaoDevice?iuUsuario=fb7c0e79-d0e4-41f2-a2f4-8e862dc4b1d6&iuCliente=fb7c0e79-d0e4-41f2-a2f4-8e862dc4b1d6&codigoVeiculo=123&chaveDevice=321
            ////api/deviceinstalado/iuUsufb7c0e79-d0e4-41f2-a2f4-8e862dc4b1d6,fb7c0e79-d0e4-41f2-a2f4-8e862dc4b1d6,123,321 
            //(token: string,
            //    iuUsuario: string,
            //    iuCliente: string,
            //    codigoVeiculo: string,
            //    chaveDevice: string,
            //    ):bool
            //Details:
            //Sequential

            //Behavior: 	1.Valida se a chave device é valida na entidade "Device";
            //2.Valida se codigoVeiculo é igual a IdentificaoNoCliente na entidade "Veículo" para o cliente;
            //4.Valida se iuUsuario é valido;
            //3.Recupera os dados necessários;
            //4.Salva a configuração na entidade "DeviceInstalado".
            //    Notes: 	Salva a configuração realizada pelo técnico no device. 
            try
            {
                Veiculo veiculo = _veiculoAplicacaoServico
                    .BuscaTodos()
                    .Where(c => c.IdCliente == iuCliente)
                    .FirstOrDefault(p => p.IdentificacaoNoCliente == codigoVeiculo);

                if (veiculo == null)
                {
                    return new RetornoConfiguracaoDevice()
                    {
                        IdVeiculo = Guid.Empty,
                        Status = StatusConfiguracaoDevice.IdentificacaoNoClienteErrado
                    };
                }

                if (_usuarioAplicacaoServico.BuscaTodos().Count(p => p.IdUsuario == iuUsuario) == 0)
                {
                    return new RetornoConfiguracaoDevice()
                    {
                        IdVeiculo = Guid.Empty,
                        Status = StatusConfiguracaoDevice.FalhaDeProcessamento
                    };
                }

                Device device = _deviceAplicacaoServico.BuscaTodos().FirstOrDefault(p => p.ChaveDevice == chaveDevice);

                if (device == null)
                {
                    return new RetornoConfiguracaoDevice()
                    {
                        IdVeiculo = Guid.Empty,
                        Status = StatusConfiguracaoDevice.ChaveDeviceErrada
                    };
                }

                DeviceInstalado deviceInstalado = new DeviceInstalado() { IdDevice = device.IdDevice, IdVeiculo = veiculo.IdVeiculo, IdUsuario = iuUsuario, Ativo = true};

                _deviceInstaladoAplicacaoServico.Adiciona(deviceInstalado);

                return new RetornoConfiguracaoDevice()
                {
                    IdVeiculo = veiculo.IdVeiculo,
                    Status = StatusConfiguracaoDevice.Sucesso
                };

            }
            catch (Exception)
            {
                return new RetornoConfiguracaoDevice()
                {
                    IdVeiculo = Guid.Empty,
                    Status = StatusConfiguracaoDevice.FalhaDeProcessamento
                };
            }

        }
    }
}
