using System;
using System.Collections.Generic;
using System.Linq;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;

namespace Acme.GeoGarbage.Repositorio.Repositorios
{
    public class LastMileageEngineRepositorio : RepositorioBase<LastMileageEngine>, ILastMileageEngineRepositorio
    {
        public double Odometro(string licenseNumber, DateTime hora)
        {
            double valor = 0.00;
            DateTime horaUtc = hora.ToUniversalTime();
            DateTime horaUtcAntes = horaUtc.AddSeconds(-30);
            DateTime horaUtcDepois = horaUtc.AddSeconds(30);
            DateTime ultTimeStamp = new DateTime(1900,1,1);
            List<LastMileageEngine> lastMileageEngines = Db.LastMileageEngines
                .Where(p => p.Type == TipoMileageEngine.Mileage)
                .Where(p => p.LicenseNumber == licenseNumber)
                .Where(p => p.TimeStamp >= horaUtcAntes)
                .Where(p => p.TimeStamp <= horaUtcDepois).ToList();
            foreach (LastMileageEngine lastMileageEngine in lastMileageEngines)
            {
                if ( Math.Abs((horaUtc - lastMileageEngine.TimeStamp).TotalSeconds) < Math.Abs((horaUtc - ultTimeStamp).TotalSeconds))
                {
                    valor = lastMileageEngine.Value;
                    ultTimeStamp = lastMileageEngine.TimeStamp;
                }
            }
            return valor;
        }

        public double Horimetro(string licenseNumber, DateTime hora)
        {
            double valor = 0.00;
            DateTime horaUtc = hora.ToUniversalTime();
            DateTime horaUtcAntes = horaUtc.AddSeconds(-30);
            DateTime horaUtcDepois = horaUtc.AddSeconds(30);
            DateTime ultTimeStamp = new DateTime(1900, 1, 1);
            List<LastMileageEngine> lastMileageEngines = Db.LastMileageEngines
                .Where(p => p.Type == TipoMileageEngine.EngineHours)
                .Where(p => p.LicenseNumber == licenseNumber)
                .Where(p => p.TimeStamp >= horaUtcAntes)
                .Where(p => p.TimeStamp <= horaUtcDepois).ToList();
            foreach (LastMileageEngine lastMileageEngine in lastMileageEngines)
            {
                if (Math.Abs((horaUtc - lastMileageEngine.TimeStamp).TotalSeconds) < Math.Abs((horaUtc - ultTimeStamp).TotalSeconds))
                {
                    valor = lastMileageEngine.Value;
                    ultTimeStamp = lastMileageEngine.TimeStamp;
                }
            }
            return valor;
        }
    }
}