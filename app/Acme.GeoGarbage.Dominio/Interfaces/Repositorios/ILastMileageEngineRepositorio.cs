using System;
using Acme.GeoGarbage.Dominio.Entidades;

namespace Acme.GeoGarbage.Dominio.Interfaces.Repositorios
{
    public interface ILastMileageEngineRepositorio : IRepositorioBase<LastMileageEngine>
    {
        double Odometro(string licenseNumber, DateTime hora);
        double Horimetro(string licenseNumber, DateTime hora);
    }
}