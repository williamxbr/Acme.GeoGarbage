using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.EntidadesAPITraffilog;
using Acme.GeoGarbage.Dominio.Enums;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;

namespace Acme.GeoGarbage.UI.MVC.Controllers
{
    public class TraffilogController : ApiController
    {
        private readonly IClienteAplicacaoServico _clienteAplicacaoServico;
        private readonly IClienteAcessoTraffilogAplicacaoServico _clienteAcessoTraffilogAplicacaoServico;
        private readonly IVeiculoAplicacaoServico _veiculoAplicacaoServico;
        private readonly ILocalizacaoTraffilogAplicacaoServico _localizacaoTraffilogAplicacaoServico;
        private readonly IViagemTraffilogAplicacaoServico _viagemTraffilogAplicacaoServico;
        private readonly IVeiculoAPITraffilogAplicacaoServico _veiculoApiTraffilogAplicacaoServico;
        private readonly ILastMileageEngineAplicacaoServico _lastMileageEngineAplicacaoServico;

        public TraffilogController(IClienteAplicacaoServico clienteAplicacaoServico,
                                   IClienteAcessoTraffilogAplicacaoServico clienteAcessoTraffilogAplicacaoServico,
                                   IVeiculoAplicacaoServico veiculoAplicacaoServico,
                                   ILocalizacaoTraffilogAplicacaoServico localizacaoTraffilogAplicacaoServico,
                                   IViagemTraffilogAplicacaoServico viagemTraffilogAplicacaoServico,
                                   IVeiculoAPITraffilogAplicacaoServico veiculoApiTraffilogAplicacaoServico,
                                   ILastMileageEngineAplicacaoServico lastMileageEngineAplicacaoServico)
        {
            _clienteAplicacaoServico = clienteAplicacaoServico;
            _clienteAcessoTraffilogAplicacaoServico = clienteAcessoTraffilogAplicacaoServico;
            _veiculoAplicacaoServico = veiculoAplicacaoServico;
            _localizacaoTraffilogAplicacaoServico = localizacaoTraffilogAplicacaoServico;
            _viagemTraffilogAplicacaoServico = viagemTraffilogAplicacaoServico;
            _veiculoApiTraffilogAplicacaoServico = veiculoApiTraffilogAplicacaoServico;
            _lastMileageEngineAplicacaoServico = lastMileageEngineAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAplicacaoServico.Dispose();
                _clienteAcessoTraffilogAplicacaoServico.Dispose();
                _veiculoAplicacaoServico.Dispose();
                _localizacaoTraffilogAplicacaoServico.Dispose();
                _viagemTraffilogAplicacaoServico.Dispose();
                _veiculoApiTraffilogAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        public static string UserLogin(string login_name, string password)
        {
            return $"{{\"action\": {{\"name\": \"user_login\",\"parameters\": {{\"login_name\": \"{login_name}\",\"password\": \"{password}\",}}}}}}";
        }

        public static string ApiGetData(string last_time, string license_nmbr, string session_token)
        {
            return $"{{\"action\": {{\"name\": \"api_get_data\",\"parameters\": [{{\"last_time\":\"{last_time}\",\"license_nmbr\":\"{license_nmbr}\"}}],\"session_token\":\"{session_token}\"}}}}";
        }

        public static string GetVehicleTrips(string vehicle_id, string license_number, string from_date, string to_date,
            string session_token)
        {
            return $"{{\"action\": {{\"name\": \"get_vehicle_trips\",\"parameters\": [{{\"vehicle_id\":\"{vehicle_id}\",\"license_nmbr\":\"{license_number}\",\"from_date\":\"{from_date}\",\"to_date\":\"{to_date}\"}}],\"session_token\":\"{session_token}\"}}}}";
        }

        public static string GetTripEvents(string drive_id, string version, string session_token)
        {
            return
                $"{{\"action\": {{\"name\": \"get_trip_events\",\"parameters\": [{{\"drive_id\":\"{drive_id}\",\"license_nmbr\":\"{version}\"}}],\"session_token\":\"{session_token}\"}}}}";
        }

        public static string GetTripLocations(string drive_id, string session_token)
        {
            return $"{{\"action\": {{\"name\": \"get_trip_locations\",\"parameters\": [{{\"drive_id\":\"{drive_id}\"}}],\"session_token\":\"{session_token}\"}}}}";
        }

        public static string GetMileageAndEngineHours(string license_number, string start_date, string session_token)
        {
            return $"{{\"action\": {{\"name\": \"last_mileage_engine\",\"parameters\": [{{\"license_number\":\"{license_number}\",\"start_date\":\"{start_date}\"}}],\"session_token\":\"{session_token}\"}}}}";
        }

        private void Inserirlast_mileage_engine(DateTime data, string license_number, string token)
        {
            List<last_mileage_engine> getOdometrosHorimentos = Utilidades.Utils.RetornaListaAPI<last_mileage_engine>(
                GetMileageAndEngineHours(license_number, data.ToString("yyyy'-'MM'-'dd"), token));

            List<LastMileageEngine> listaLastMileageEngines = new List<LastMileageEngine>();

            foreach (last_mileage_engine last_Mileage_Engine in getOdometrosHorimentos)
            {
                LastMileageEngine lastMileageEngine = new LastMileageEngine();
                lastMileageEngine.DataImportacao = DateTime.Now;
                lastMileageEngine.Type = last_Mileage_Engine.type == "MILEAGE"
                    ? TipoMileageEngine.Mileage
                    : TipoMileageEngine.EngineHours;
                lastMileageEngine.LicenseNumber = last_Mileage_Engine.license_number;
                lastMileageEngine.VehicleId = last_Mileage_Engine.vehice_id != null ? Int32.Parse(last_Mileage_Engine.vehice_id) : 0;
                lastMileageEngine.TimeStamp = DateTime.ParseExact(last_Mileage_Engine.time_stamp, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                lastMileageEngine.Value = Double.Parse(last_Mileage_Engine.value.Replace(".", ","));
                lastMileageEngine.StatusIntegracao = false;
                listaLastMileageEngines.Add(lastMileageEngine);
            }

            _lastMileageEngineAplicacaoServico.AdicionaEmLote(listaLastMileageEngines);
        }


        [HttpPost]
        [Route("api/Traffilog/post_CarregaDadosTraffilog")]
        public bool post_CarregaDadosTraffilog()
        {
            try
            {
                IEnumerable<ClienteAcessoTraffilog> listClienteAcessoTraffilogs = _clienteAcessoTraffilogAplicacaoServico.BuscaTodos();
                foreach (ClienteAcessoTraffilog clienteAcessoTraffilog in listClienteAcessoTraffilogs)
                {
                    Cliente cliente = _clienteAplicacaoServico.BuscaId(clienteAcessoTraffilog.IdCliente);

                    user_login userLogins = Utilidades.Utils.RetornaListaAPI<user_login>(UserLogin(clienteAcessoTraffilog.LoginTraffilog,
                        clienteAcessoTraffilog.PasswordTraffilog)).FirstOrDefault();

                    if (cliente != null && userLogins != null)
                    {

                        List<Veiculo> listVeiculos = _veiculoAplicacaoServico.Consultar()
                            .Where(p => p.IdCliente == cliente.IdCliente).ToList();

                        foreach (Veiculo veiculo in listVeiculos)
                        {
                            DateTime ultimaData = DateTime.Today.AddDays(-1);

                            VeiculoAPITraffilog veiculoApiTraffilog =
                                _veiculoApiTraffilogAplicacaoServico.BuscaId(veiculo.IdVeiculo);

                            if (veiculoApiTraffilog != null)
                            {
                                ultimaData = veiculoApiTraffilog.UltimaIntegracao;

                                int quantDias = (DateTime.Today - ultimaData).Days;

                                for (int dia = 1; dia < quantDias; dia++)
                                {
                                    if (_veiculoAplicacaoServico.ExisteMovimentacao(veiculo.IdVeiculo, ultimaData.AddDays(dia)))
                                        Inserirlast_mileage_engine(ultimaData.AddDays(dia), veiculo.IdentificacaoNoCliente, userLogins.session_token);
                                    veiculoApiTraffilog.UltimaIntegracao = ultimaData.AddDays(dia);
                                    _veiculoApiTraffilogAplicacaoServico.Atualiza(veiculoApiTraffilog);
                                }
                            }
                            else
                            {
                                if (_veiculoAplicacaoServico.ExisteMovimentacao(veiculo.IdVeiculo, ultimaData))
                                    Inserirlast_mileage_engine(ultimaData, veiculo.IdentificacaoNoCliente, userLogins.session_token);
                                VeiculoAPITraffilog veiculoApiTraffilogAdd = new VeiculoAPITraffilog();
                                veiculoApiTraffilogAdd.IdVeiculo = veiculo.IdVeiculo;
                                veiculoApiTraffilogAdd.UltimaIntegracao = ultimaData;
                                _veiculoApiTraffilogAplicacaoServico.Adiciona(veiculoApiTraffilogAdd);
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
