using System;
using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;
using System.Collections;

namespace Acme.GeoGarbage.Servicos
{
    public class ServicoConsulta : IDisposable, IServicoConsulta
    {
        private readonly IRepositorioConsulta _repositorioConsulta;

        public ServicoConsulta(IRepositorioConsulta repositorioConsulta)
        {
            _repositorioConsulta = repositorioConsulta;
        }

        public void Dispose()
        {
            _repositorioConsulta.Dispose();
        }

        public dynamic Lista(Type resultType, string SQL)
        {
            return _repositorioConsulta.Lista(resultType, SQL);
        }
    }
}