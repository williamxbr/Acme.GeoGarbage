﻿using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;

namespace Acme.GeoGarbage.Aplicacao
{
    public class ConsultaDinamicaCampoAplicacaoServico : AplicacaoServicoBase<ConsultaDinamicaCampo>, IConsultaDinamicaCampoAplicacaoServico
    {
        private readonly IConsultaDinamicaCampoServico _consultaDinamicaCampoServico;

        public ConsultaDinamicaCampoAplicacaoServico(IConsultaDinamicaCampoServico consultaDinamicaCampoServico)
            : base(consultaDinamicaCampoServico)
        {
            _consultaDinamicaCampoServico = consultaDinamicaCampoServico;
        }

    }
}