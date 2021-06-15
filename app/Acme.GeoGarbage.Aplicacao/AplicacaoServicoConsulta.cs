using System;
using System.Collections.Generic;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using System.Collections;

namespace Acme.GeoGarbage.Aplicacao
{
    public class AplicacaoServicoConsulta: IDisposable, IAplicacaoServicoConsulta
    {
        private readonly IServicoConsulta _servicoConsulta;

        public AplicacaoServicoConsulta(IServicoConsulta servicoConsulta)
        {
            _servicoConsulta = servicoConsulta;
        }

        public void Dispose()
        {
            _servicoConsulta.Dispose();
        }

        public dynamic Lista(Type resultType, string SQL)
        {
            return _servicoConsulta.Lista(resultType, SQL);
        }
    }
}