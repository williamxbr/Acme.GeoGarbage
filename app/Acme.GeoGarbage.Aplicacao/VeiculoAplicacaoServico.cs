using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acme.GeoGarbage.Aplicacao
{
    public class VeiculoAplicacaoServico : AplicacaoServicoBase<Veiculo>, IVeiculoAplicacaoServico
    {
        private readonly IVeiculoServico _veiculoServico;
        private readonly IJornadaServico _jornadaServico;
        private readonly IInterrupcaoServico _interrupcaoServico;

        public VeiculoAplicacaoServico(IVeiculoServico veiculoServico, IJornadaServico jornadaServico, IInterrupcaoServico interrupcaoServico) : base(veiculoServico)
        {
            _veiculoServico = veiculoServico;
            _jornadaServico = jornadaServico;
            _interrupcaoServico = interrupcaoServico;
        }

        public bool ExisteMovimentacao(Guid idVeiculo, DateTime data)
        {
            DateTime dataPosterior = data.AddDays(1);
            Jornada jornada = _jornadaServico.Consultar()
                .Where(p => p.IdVeiculo == idVeiculo).Where(p => p.InicioJornada >= data)
                .FirstOrDefault(p => p.InicioJornada < dataPosterior);
            if (jornada != null)
            {
                return true;
            }
            jornada = _jornadaServico.Consultar()
                .Where(p => p.IdVeiculo == idVeiculo).Where(p => p.FimDaJornada >= data)
                .FirstOrDefault(p => p.FimDaJornada < dataPosterior);
            if (jornada != null)
            {
                return true;
            }
            Interrupcao interrupcao = _interrupcaoServico.Consultar().Where(p => p.IdVeiculo == idVeiculo)
                .Where(p => p.DataHoraInterrupcao >= data)
                .FirstOrDefault(p => p.DataHoraInterrupcao < dataPosterior);
            if (interrupcao != null)
            {
                return true;
            }
            return false;
        }
    }
}
