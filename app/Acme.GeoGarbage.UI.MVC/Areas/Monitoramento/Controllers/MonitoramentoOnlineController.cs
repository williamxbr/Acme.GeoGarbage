using Ninject;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.UI.MVC.Areas.Monitoramento.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace Acme.GeoGarbage.UI.MVC.Areas.Monitoramento.Controllers
{
    public class MonitoramentoOnlineController : Controller
    {
        protected readonly ISetorDaJornadaAplicacaoServico _setorDaJornadaAplicacaoServico;

        public MonitoramentoOnlineController(ISetorDaJornadaAplicacaoServico setorDaJornadaAplicacaoServico)
        {
            _setorDaJornadaAplicacaoServico = setorDaJornadaAplicacaoServico;
        }

        public ActionResult ListarSetoresEmMonitoramento()
        {
            var setoresDaJornada = _setorDaJornadaAplicacaoServico.BuscaTodos().Where(x => x.Status != StatusDeOperacao.SetorConcluido);
            
            var setoresViewModel = this.MapearMonitoramento(setoresDaJornada);
            return Json(setoresViewModel);
        }

        public ActionResult ConsultarSetorEmMonitoramento(string setor)
        {
            var usuario = PegarUsuarioLogado();

            if (!string.IsNullOrEmpty(setor) && usuario != null)
            {
                var setorDaJornada = _setorDaJornadaAplicacaoServico.BuscaId(Guid.Parse(setor));
                var setorViewModel = this.MapearMonitoramento(setorDaJornada, usuario);
                return Json(setorViewModel);
            }
            else
            {
                return Json(null);
            }
        }

        public ActionResult Detalhes(string setor)
        {
            return PartialView("~/Areas/Monitoramento/Views/Home/DetalhesPartial.cshtml", setor);
        }
        
        protected List<MonitoramentoDeColetaViewModel> MapearMonitoramento(IEnumerable<SetorDaJornada> setores)
        {
            var setoresViewModel = new List<MonitoramentoDeColetaViewModel>();
            var usuario = this.PegarUsuarioLogado();

            if (usuario != null)
            {
                foreach (var setor in setores)
                {
                    setoresViewModel.Add(this.MapearMonitoramento(setor, usuario));
                }
            }

            return setoresViewModel;
        }

        protected MonitoramentoDeColetaViewModel MapearMonitoramento(SetorDaJornada setor, Usuario usuario)
        {
            var monitoramentoOnline = new MonitoramentoDeColetaViewModel();
            monitoramentoOnline.IdSetor = setor.IdSetorDaJornada.ToString();
            monitoramentoOnline.Setor = setor.Setor.NomeSetor;
            monitoramentoOnline.Status = Enumerations.GetEnumDescription(setor.Status);
            monitoramentoOnline.PorcentagemDeConclusao = _setorDaJornadaAplicacaoServico.CalcularPorcentagemDeConclusao(setor);
            monitoramentoOnline.Horario = _setorDaJornadaAplicacaoServico.PegarSinalizacaoHorario(setor);
            monitoramentoOnline.Ping = _setorDaJornadaAplicacaoServico.PegarSinalizacaoPing(setor, usuario.PadraoDaContas);
            monitoramentoOnline.ServicoEmExecucao = new List<ExecucaoPontoDeColetaViewModel>();

            foreach (var execucao in setor.ExecucaoPontoDeColetas)
            {
                var execucaoViewModel = new ExecucaoPontoDeColetaViewModel();
                execucaoViewModel.IdExecucaoPontoDeColeta = execucao.IdExecucaoPontoDeColeta;
                execucaoViewModel.IdPontoDeColeta = execucao.IdPontoDeColeta;
                execucaoViewModel.IdSetorDeJornada = execucao.IdSetorDeJornada;
                execucaoViewModel.Passagem = execucao.Passagem;
                execucaoViewModel.StatusDePassagem = execucao.StatusDePassagem;
                execucaoViewModel.PontoDeColeta = new PontoDeColetaViewModel();
                execucaoViewModel.PontoDeColeta.IdPontoDeColeta = execucao.PontoDeColeta.IdPontoDeColeta;
                execucaoViewModel.PontoDeColeta.IdSetor = execucao.PontoDeColeta.IdSetor;
                execucaoViewModel.PontoDeColeta.Latitude = execucao.PontoDeColeta.Latitude;
                execucaoViewModel.PontoDeColeta.Longitude = execucao.PontoDeColeta.Longitude;
                execucaoViewModel.PontoDeColeta.Nome = execucao.PontoDeColeta.Nome;
                execucaoViewModel.PontoDeColeta.Horario = execucao.PontoDeColeta.Horario;
                execucaoViewModel.PontoDeColeta.SequenciaDeColeta = execucao.PontoDeColeta.SequenciaDeColeta;
                execucaoViewModel.PontoDeColeta.Tolerancia1 = execucao.PontoDeColeta.Tolerancia1;
                execucaoViewModel.PontoDeColeta.Tolerancia2 = execucao.PontoDeColeta.Tolerancia2;
                monitoramentoOnline.ServicoEmExecucao.Add(execucaoViewModel);
            }

            return monitoramentoOnline;
        }

        protected Usuario PegarUsuarioLogado()
        {
            var identity = System.Threading.Thread.CurrentPrincipal.Identity;
            if (identity.IsAuthenticated)
            {
                var kernel = (IKernel)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IKernel));
                var usuarioAplicacaoServico = kernel.Get<IUsuarioAplicacaoServico>();
                var userId = new Guid(identity.Name);
                var usuario = usuarioAplicacaoServico.BuscaId(userId);
                return usuario;
            }
            else
            {
                return null;
            }
        }

        protected List<MonitoramentoDeColetaViewModel> GerarMockSetores()
        {
            var setores = new List<MonitoramentoDeColetaViewModel>();

            var setor1 = new MonitoramentoDeColetaViewModel();
            setor1.IdSetor = Guid.NewGuid().ToString();
            setor1.Setor = "B50";
            setor1.Status = "EM COLETA";
            setor1.Horario = SinalizacaoDeHorario.Laranja;
            setor1.PorcentagemDeConclusao = 75;
            setor1.Ping = SinalizacaoPing.Amarelo;

            GerarMassaSetor1(setor1);

            var setor2 = new MonitoramentoDeColetaViewModel();
            setor2.IdSetor = Guid.NewGuid().ToString();
            setor2.Setor = "B100";
            setor2.Status = "DIRIGINDO PARA O SETOR";
            setor2.Horario = SinalizacaoDeHorario.Preto;
            setor2.PorcentagemDeConclusao = 75;
            setor2.Ping = SinalizacaoPing.Verde;

            GerarMassaSetor2(setor2);

            var setor3 = new MonitoramentoDeColetaViewModel();
            setor3.IdSetor = Guid.NewGuid().ToString();
            setor3.Setor = "B120";
            setor3.Status = "DIRIGINDO PARA O ATERRO";
            setor3.Horario = SinalizacaoDeHorario.SemMonitoramento;
            setor3.PorcentagemDeConclusao = 40;
            setor3.Ping = SinalizacaoPing.Verde;
            GerarMassaSetor3(setor3);

            setores.Add(setor1);
            setores.Add(setor2);
            setores.Add(setor3);

            return setores;
        }

        private static void GerarMassaSetor1(MonitoramentoDeColetaViewModel setor1)
        {
            setor1.ServicoEmExecucao = new List<ExecucaoPontoDeColetaViewModel>();

            var item11 = new ExecucaoPontoDeColetaViewModel();
            item11.PontoDeColeta.Nome = "TESTE";
            item11.PontoDeColeta.Horario = "13:00";
            item11.StatusDePassagem = StatusDePassagem.Passado;

            var item12 = new ExecucaoPontoDeColetaViewModel();
            item12.PontoDeColeta.Nome = "TESTE";
            item12.PontoDeColeta.Horario = "13:00";
            item12.StatusDePassagem = StatusDePassagem.Passado;

            var item13 = new ExecucaoPontoDeColetaViewModel();
            item13.PontoDeColeta.Nome = "TESTE";
            item13.PontoDeColeta.Horario = "13:00";
            item13.StatusDePassagem = StatusDePassagem.Passado;

            var item14 = new ExecucaoPontoDeColetaViewModel();
            item14.PontoDeColeta.Nome = "TESTE";
            item14.PontoDeColeta.Horario = "13:00";
            item14.StatusDePassagem = StatusDePassagem.Passado;

            var item15 = new ExecucaoPontoDeColetaViewModel();
            item15.PontoDeColeta.Nome = "TESTE";
            item15.PontoDeColeta.Horario = "13:00";
            item15.StatusDePassagem = StatusDePassagem.Passado;

            var item16 = new ExecucaoPontoDeColetaViewModel();
            item16.PontoDeColeta.Nome = "TESTE";
            item16.PontoDeColeta.Horario = "13:00";
            item16.StatusDePassagem = StatusDePassagem.Passado;

            var item17 = new ExecucaoPontoDeColetaViewModel();
            item17.PontoDeColeta.Nome = "TESTE";
            item17.PontoDeColeta.Horario = "13:00";
            item17.StatusDePassagem = StatusDePassagem.Passado;

            var item18 = new ExecucaoPontoDeColetaViewModel();
            item18.PontoDeColeta.Nome = "TESTE";
            item18.PontoDeColeta.Horario = "13:00";
            item18.StatusDePassagem = StatusDePassagem.Passado;

            var item19 = new ExecucaoPontoDeColetaViewModel();
            item19.PontoDeColeta.Nome = "TESTE";
            item19.PontoDeColeta.Horario = "13:00";
            item19.StatusDePassagem = StatusDePassagem.Passado;

            var item110 = new ExecucaoPontoDeColetaViewModel();
            item110.PontoDeColeta.Nome = "TESTE";
            item110.PontoDeColeta.Horario = "13:00";
            item110.StatusDePassagem = StatusDePassagem.Passado;

            var item111 = new ExecucaoPontoDeColetaViewModel();
            item111.PontoDeColeta.Nome = "TESTE";
            item111.PontoDeColeta.Horario = "13:00";
            item111.StatusDePassagem = StatusDePassagem.Passado;

            var item112 = new ExecucaoPontoDeColetaViewModel();
            item112.PontoDeColeta.Nome = "TESTE";
            item112.PontoDeColeta.Horario = "13:00";
            item112.StatusDePassagem = StatusDePassagem.Passado;

            var item113 = new ExecucaoPontoDeColetaViewModel();
            item113.PontoDeColeta.Nome = "TESTE";
            item113.PontoDeColeta.Horario = "13:00";
            item113.StatusDePassagem = StatusDePassagem.Passado;

            var item114 = new ExecucaoPontoDeColetaViewModel();
            item114.PontoDeColeta.Nome = "TESTE";
            item114.PontoDeColeta.Horario = "13:00";
            item114.StatusDePassagem = StatusDePassagem.Passado;

            var item115 = new ExecucaoPontoDeColetaViewModel();
            item115.PontoDeColeta.Nome = "TESTE";
            item115.PontoDeColeta.Horario = "13:00";
            item115.StatusDePassagem = StatusDePassagem.Passado;

            var item116 = new ExecucaoPontoDeColetaViewModel();
            item116.PontoDeColeta.Nome = "TESTE";
            item116.PontoDeColeta.Horario = "13:00";
            item116.StatusDePassagem = StatusDePassagem.Passado;

            var item117 = new ExecucaoPontoDeColetaViewModel();
            item117.PontoDeColeta.Nome = "TESTE";
            item117.PontoDeColeta.Horario = "13:00";
            item117.StatusDePassagem = StatusDePassagem.Passado;

            var item118 = new ExecucaoPontoDeColetaViewModel();
            item118.PontoDeColeta.Nome = "TESTE";
            item118.PontoDeColeta.Horario = "13:00";
            item118.StatusDePassagem = StatusDePassagem.Passado;

            var item119 = new ExecucaoPontoDeColetaViewModel();
            item119.PontoDeColeta.Nome = "TESTE";
            item119.PontoDeColeta.Horario = "13:00";
            item119.StatusDePassagem = StatusDePassagem.Passado;

            var item120 = new ExecucaoPontoDeColetaViewModel();
            item120.PontoDeColeta.Nome = "TESTE";
            item120.PontoDeColeta.Horario = "13:00";
            item120.StatusDePassagem = StatusDePassagem.Passado;

            var item121 = new ExecucaoPontoDeColetaViewModel();
            item121.PontoDeColeta.Nome = "TESTE";
            item121.PontoDeColeta.Horario = "13:00";
            item121.StatusDePassagem = StatusDePassagem.Passado;

            var item122 = new ExecucaoPontoDeColetaViewModel();
            item122.PontoDeColeta.Nome = "TESTE";
            item122.PontoDeColeta.Horario = "13:00";
            item122.StatusDePassagem = StatusDePassagem.Passado;

            var item123 = new ExecucaoPontoDeColetaViewModel();
            item123.PontoDeColeta.Nome = "TESTE";
            item123.PontoDeColeta.Horario = "13:00";
            item123.StatusDePassagem = StatusDePassagem.Passado;

            var item124 = new ExecucaoPontoDeColetaViewModel();
            item124.PontoDeColeta.Nome = "TESTE";
            item124.PontoDeColeta.Horario = "13:00";
            item124.StatusDePassagem = StatusDePassagem.Passado;

            var item125 = new ExecucaoPontoDeColetaViewModel();
            item125.PontoDeColeta.Nome = "TESTE";
            item125.PontoDeColeta.Horario = "13:00";
            item125.StatusDePassagem = StatusDePassagem.Passado;

            var item126 = new ExecucaoPontoDeColetaViewModel();
            item126.PontoDeColeta.Nome = "TESTE";
            item126.PontoDeColeta.Horario = "13:00";
            item126.StatusDePassagem = StatusDePassagem.Passado;

            var item127 = new ExecucaoPontoDeColetaViewModel();
            item127.PontoDeColeta.Nome = "TESTE";
            item127.PontoDeColeta.Horario = "13:00";
            item127.StatusDePassagem = StatusDePassagem.Passado;

            var item128 = new ExecucaoPontoDeColetaViewModel();
            item128.PontoDeColeta.Nome = "TESTE";
            item128.PontoDeColeta.Horario = "13:00";
            item128.StatusDePassagem = StatusDePassagem.Passado;

            var item129 = new ExecucaoPontoDeColetaViewModel();
            item129.PontoDeColeta.Nome = "TESTE";
            item129.PontoDeColeta.Horario = "13:00";
            item129.StatusDePassagem = StatusDePassagem.Passado;

            var item130 = new ExecucaoPontoDeColetaViewModel();
            item130.PontoDeColeta.Nome = "TESTE";
            item130.PontoDeColeta.Horario = "13:00";
            item130.StatusDePassagem = StatusDePassagem.Passado;

            var item131 = new ExecucaoPontoDeColetaViewModel();
            item131.PontoDeColeta.Nome = "TESTE";
            item131.PontoDeColeta.Horario = "13:00";
            item131.StatusDePassagem = StatusDePassagem.Passado;

            var item132 = new ExecucaoPontoDeColetaViewModel();
            item132.PontoDeColeta.Nome = "TESTE";
            item132.PontoDeColeta.Horario = "13:00";
            item132.StatusDePassagem = StatusDePassagem.Passado;

            var item133 = new ExecucaoPontoDeColetaViewModel();

            item133.PontoDeColeta.Nome = "TESTE";
            item133.PontoDeColeta.Horario = "13:00";
            item133.StatusDePassagem = StatusDePassagem.Passado;

            var item134 = new ExecucaoPontoDeColetaViewModel();

            item134.PontoDeColeta.Nome = "TESTE";
            item134.PontoDeColeta.Horario = "13:00";
            item134.StatusDePassagem = StatusDePassagem.Passado;

            var item135 = new ExecucaoPontoDeColetaViewModel();

            item135.PontoDeColeta.Nome = "TESTE";
            item135.PontoDeColeta.Horario = "13:00";
            item135.StatusDePassagem = StatusDePassagem.Passado;

            var item136 = new ExecucaoPontoDeColetaViewModel();

            item136.PontoDeColeta.Nome = "TESTE";
            item136.PontoDeColeta.Horario = "13:00";
            item136.StatusDePassagem = StatusDePassagem.Passado;

            var item137 = new ExecucaoPontoDeColetaViewModel();

            item137.PontoDeColeta.Nome = "TESTE";
            item137.PontoDeColeta.Horario = "13:00";
            item137.StatusDePassagem = StatusDePassagem.Passado;

            var item138 = new ExecucaoPontoDeColetaViewModel();

            item138.PontoDeColeta.Nome = "TESTE";
            item138.PontoDeColeta.Horario = "13:00";
            item138.StatusDePassagem = StatusDePassagem.Passado;

            var item139 = new ExecucaoPontoDeColetaViewModel();

            item139.PontoDeColeta.Nome = "TESTE";
            item139.PontoDeColeta.Horario = "13:00";
            item139.StatusDePassagem = StatusDePassagem.Passado;

            var item140 = new ExecucaoPontoDeColetaViewModel();

            item140.PontoDeColeta.Nome = "TESTE";
            item140.PontoDeColeta.Horario = "13:00";
            item140.StatusDePassagem = StatusDePassagem.Passado;

            var item141 = new ExecucaoPontoDeColetaViewModel();

            item141.PontoDeColeta.Nome = "TESTE";
            item141.PontoDeColeta.Horario = "13:00";
            item141.StatusDePassagem = StatusDePassagem.Passado;

            var item142 = new ExecucaoPontoDeColetaViewModel();

            item142.PontoDeColeta.Nome = "TESTE";
            item142.PontoDeColeta.Horario = "13:00";
            item142.StatusDePassagem = StatusDePassagem.Passado;

            var item143 = new ExecucaoPontoDeColetaViewModel();

            item143.PontoDeColeta.Nome = "TESTE";
            item143.PontoDeColeta.Horario = "13:00";
            item143.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item144 = new ExecucaoPontoDeColetaViewModel();

            item144.PontoDeColeta.Nome = "TESTE";
            item144.PontoDeColeta.Horario = "13:00";
            item144.StatusDePassagem = StatusDePassagem.Pulado;

            var item145 = new ExecucaoPontoDeColetaViewModel();

            item145.PontoDeColeta.Nome = "TESTE";
            item145.PontoDeColeta.Horario = "13:00";
            item145.StatusDePassagem = StatusDePassagem.Pulado;

            var item146 = new ExecucaoPontoDeColetaViewModel();

            item146.PontoDeColeta.Nome = "TESTE";
            item146.PontoDeColeta.Horario = "13:00";
            item146.StatusDePassagem = StatusDePassagem.Passado;
            var item147 = new ExecucaoPontoDeColetaViewModel();

            item147.PontoDeColeta.Nome = "TESTE";
            item147.PontoDeColeta.Horario = "13:00";
            item147.StatusDePassagem = StatusDePassagem.Passado;
            var item148 = new ExecucaoPontoDeColetaViewModel();

            item148.PontoDeColeta.Nome = "TESTE";
            item148.PontoDeColeta.Horario = "13:00";
            item148.StatusDePassagem = StatusDePassagem.Passado;
            var item149 = new ExecucaoPontoDeColetaViewModel();

            item149.PontoDeColeta.Nome = "TESTE";
            item149.PontoDeColeta.Horario = "13:00";
            item149.StatusDePassagem = StatusDePassagem.Passado;
            var item150 = new ExecucaoPontoDeColetaViewModel();

            item150.PontoDeColeta.Nome = "TESTE";
            item150.PontoDeColeta.Horario = "13:00";
            item150.StatusDePassagem = StatusDePassagem.Passado;
            var item151 = new ExecucaoPontoDeColetaViewModel();

            item151.PontoDeColeta.Nome = "TESTE";
            item151.PontoDeColeta.Horario = "13:00";
            item151.StatusDePassagem = StatusDePassagem.Passado;
            var item152 = new ExecucaoPontoDeColetaViewModel();

            item152.PontoDeColeta.Nome = "TESTE";
            item152.PontoDeColeta.Horario = "13:00";
            item152.StatusDePassagem = StatusDePassagem.Passado;
            var item153 = new ExecucaoPontoDeColetaViewModel();

            item153.PontoDeColeta.Nome = "TESTE";
            item153.PontoDeColeta.Horario = "13:00";
            item153.StatusDePassagem = StatusDePassagem.Passado;
            var item154 = new ExecucaoPontoDeColetaViewModel();

            item154.PontoDeColeta.Nome = "TESTE";
            item154.PontoDeColeta.Horario = "13:00";
            item154.StatusDePassagem = StatusDePassagem.Passado;
            var item155 = new ExecucaoPontoDeColetaViewModel();

            item155.PontoDeColeta.Nome = "TESTE";
            item155.PontoDeColeta.Horario = "13:00";
            item155.StatusDePassagem = StatusDePassagem.Passado;
            var item156 = new ExecucaoPontoDeColetaViewModel();

            item156.PontoDeColeta.Nome = "TESTE";
            item156.PontoDeColeta.Horario = "13:00";
            item156.StatusDePassagem = StatusDePassagem.Passado;
            var item157 = new ExecucaoPontoDeColetaViewModel();

            item157.PontoDeColeta.Nome = "TESTE";
            item157.PontoDeColeta.Horario = "13:00";
            item157.StatusDePassagem = StatusDePassagem.Passado;
            var item158 = new ExecucaoPontoDeColetaViewModel();

            item158.PontoDeColeta.Nome = "TESTE";
            item158.PontoDeColeta.Horario = "13:00";
            item158.StatusDePassagem = StatusDePassagem.Passado;
            var item159 = new ExecucaoPontoDeColetaViewModel();

            item159.PontoDeColeta.Nome = "TESTE";
            item159.PontoDeColeta.Horario = "13:00";
            item159.StatusDePassagem = StatusDePassagem.Passado;
            var item160 = new ExecucaoPontoDeColetaViewModel();

            item160.PontoDeColeta.Nome = "TESTE";
            item160.PontoDeColeta.Horario = "13:00";
            item160.StatusDePassagem = StatusDePassagem.Passado;
            var item161 = new ExecucaoPontoDeColetaViewModel();

            item161.PontoDeColeta.Nome = "TESTE";
            item161.PontoDeColeta.Horario = "13:00";
            item161.StatusDePassagem = StatusDePassagem.Passado;
            var item162 = new ExecucaoPontoDeColetaViewModel();

            item162.PontoDeColeta.Nome = "TESTE";
            item162.PontoDeColeta.Horario = "13:00";
            item162.StatusDePassagem = StatusDePassagem.Passado;
            var item163 = new ExecucaoPontoDeColetaViewModel();

            item163.PontoDeColeta.Nome = "TESTE";
            item163.PontoDeColeta.Horario = "13:00";
            item163.StatusDePassagem = StatusDePassagem.Passado;
            var item164 = new ExecucaoPontoDeColetaViewModel();

            item164.PontoDeColeta.Nome = "TESTE";
            item164.PontoDeColeta.Horario = "13:00";
            item164.StatusDePassagem = StatusDePassagem.Passado;
            var item165 = new ExecucaoPontoDeColetaViewModel();

            item165.PontoDeColeta.Nome = "TESTE";
            item165.PontoDeColeta.Horario = "13:00";
            item165.StatusDePassagem = StatusDePassagem.Passado;
            var item166 = new ExecucaoPontoDeColetaViewModel();

            item166.PontoDeColeta.Nome = "TESTE";
            item166.PontoDeColeta.Horario = "13:00";
            item166.StatusDePassagem = StatusDePassagem.Passado;
            item166.StatusDePassagem = StatusDePassagem.Passado;
            var item167 = new ExecucaoPontoDeColetaViewModel();

            item167.PontoDeColeta.Nome = "TESTE";
            item167.PontoDeColeta.Horario = "13:00";
            item167.StatusDePassagem = StatusDePassagem.Passado;
            var item168 = new ExecucaoPontoDeColetaViewModel();

            item168.PontoDeColeta.Nome = "TESTE";
            item168.PontoDeColeta.Horario = "13:00";
            item168.StatusDePassagem = StatusDePassagem.Passado;
            var item169 = new ExecucaoPontoDeColetaViewModel();

            item169.PontoDeColeta.Nome = "TESTE";
            item169.PontoDeColeta.Horario = "13:00";
            item169.StatusDePassagem = StatusDePassagem.Passado;
            var item170 = new ExecucaoPontoDeColetaViewModel();

            item170.PontoDeColeta.Nome = "TESTE";
            item170.PontoDeColeta.Horario = "13:00";
            item170.StatusDePassagem = StatusDePassagem.Passado;
            var item171 = new ExecucaoPontoDeColetaViewModel();

            item171.PontoDeColeta.Nome = "TESTE";
            item171.PontoDeColeta.Horario = "13:00";
            item171.StatusDePassagem = StatusDePassagem.Passado;
            var item172 = new ExecucaoPontoDeColetaViewModel();

            item172.PontoDeColeta.Nome = "TESTE";
            item172.PontoDeColeta.Horario = "13:00";
            item172.StatusDePassagem = StatusDePassagem.Passado;

            var item173 = new ExecucaoPontoDeColetaViewModel();

            item173.PontoDeColeta.Nome = "TESTE";
            item173.PontoDeColeta.Horario = "13:00";
            item173.StatusDePassagem = StatusDePassagem.Passado;

            var item174 = new ExecucaoPontoDeColetaViewModel();

            item174.PontoDeColeta.Nome = "TESTE";
            item174.PontoDeColeta.Horario = "13:00";
            item174.StatusDePassagem = StatusDePassagem.Passado;

            var item175 = new ExecucaoPontoDeColetaViewModel();

            item175.PontoDeColeta.Nome = "TESTE";
            item175.PontoDeColeta.Horario = "13:00";
            item175.StatusDePassagem = StatusDePassagem.Passado;

            var item176 = new ExecucaoPontoDeColetaViewModel();

            item176.PontoDeColeta.Nome = "TESTE";
            item176.PontoDeColeta.Horario = "13:00";
            item176.StatusDePassagem = StatusDePassagem.Passado;

            var item177 = new ExecucaoPontoDeColetaViewModel();

            item177.PontoDeColeta.Nome = "TESTE";
            item177.PontoDeColeta.Horario = "13:00";
            item177.StatusDePassagem = StatusDePassagem.Passado;
            var item178 = new ExecucaoPontoDeColetaViewModel();

            item178.PontoDeColeta.Nome = "TESTE";
            item178.PontoDeColeta.Horario = "13:00";
            item178.StatusDePassagem = StatusDePassagem.Passado;
            var item179 = new ExecucaoPontoDeColetaViewModel();

            item179.PontoDeColeta.Nome = "TESTE";
            item179.PontoDeColeta.Horario = "13:00";
            item179.StatusDePassagem = StatusDePassagem.Passado;
            var item180 = new ExecucaoPontoDeColetaViewModel();

            item180.PontoDeColeta.Nome = "TESTE";
            item180.PontoDeColeta.Horario = "13:00";
            item180.StatusDePassagem = StatusDePassagem.Passado;
            var item181 = new ExecucaoPontoDeColetaViewModel();

            item181.PontoDeColeta.Nome = "TESTE";
            item181.PontoDeColeta.Horario = "13:00";
            item181.StatusDePassagem = StatusDePassagem.Passado;
            var item182 = new ExecucaoPontoDeColetaViewModel();

            item182.PontoDeColeta.Nome = "TESTE";
            item182.PontoDeColeta.Horario = "13:00";
            item182.StatusDePassagem = StatusDePassagem.Passado;
            var item183 = new ExecucaoPontoDeColetaViewModel();

            item183.PontoDeColeta.Nome = "TESTE";
            item183.PontoDeColeta.Horario = "13:00";
            item183.StatusDePassagem = StatusDePassagem.Passado;
            var item184 = new ExecucaoPontoDeColetaViewModel();

            item184.PontoDeColeta.Nome = "TESTE";
            item184.PontoDeColeta.Horario = "13:00";
            item184.StatusDePassagem = StatusDePassagem.Passado;
            var item185 = new ExecucaoPontoDeColetaViewModel();

            item185.PontoDeColeta.Nome = "TESTE";
            item185.PontoDeColeta.Horario = "13:00";
            item185.StatusDePassagem = StatusDePassagem.Passado;
            var item186 = new ExecucaoPontoDeColetaViewModel();

            item186.PontoDeColeta.Nome = "TESTE";
            item186.PontoDeColeta.Horario = "13:00";
            item186.StatusDePassagem = StatusDePassagem.NaoCumprido;
            var item187 = new ExecucaoPontoDeColetaViewModel();

            item187.PontoDeColeta.Nome = "TESTE";
            item187.PontoDeColeta.Horario = "13:00";
            item187.StatusDePassagem = StatusDePassagem.NaoCumprido;
            var item188 = new ExecucaoPontoDeColetaViewModel();

            item188.PontoDeColeta.Nome = "TESTE";
            item188.PontoDeColeta.Horario = "13:00";
            item188.StatusDePassagem = StatusDePassagem.Passado;
            var item189 = new ExecucaoPontoDeColetaViewModel();

            item189.PontoDeColeta.Nome = "TESTE";
            item189.PontoDeColeta.Horario = "13:00";
            item189.StatusDePassagem = StatusDePassagem.Passado;
            var item190 = new ExecucaoPontoDeColetaViewModel();

            item190.PontoDeColeta.Nome = "TESTE";
            item190.PontoDeColeta.Horario = "13:00";
            item190.StatusDePassagem = StatusDePassagem.Passado;
            var item191 = new ExecucaoPontoDeColetaViewModel();

            item191.PontoDeColeta.Nome = "TESTE";
            item191.PontoDeColeta.Horario = "13:00";
            item191.StatusDePassagem = StatusDePassagem.Passado;
            var item192 = new ExecucaoPontoDeColetaViewModel();

            item192.PontoDeColeta.Nome = "TESTE";
            item192.PontoDeColeta.Horario = "13:00";
            item192.StatusDePassagem = StatusDePassagem.Passado;
            var item193 = new ExecucaoPontoDeColetaViewModel();

            item193.PontoDeColeta.Nome = "TESTE";
            item193.PontoDeColeta.Horario = "13:00";
            item193.StatusDePassagem = StatusDePassagem.Passado;
            var item194 = new ExecucaoPontoDeColetaViewModel();

            item194.PontoDeColeta.Nome = "TESTE";
            item194.PontoDeColeta.Horario = "13:00";
            item194.StatusDePassagem = StatusDePassagem.Passado;
            var item195 = new ExecucaoPontoDeColetaViewModel();

            item195.PontoDeColeta.Nome = "TESTE";
            item195.PontoDeColeta.Horario = "13:00";
            item195.StatusDePassagem = StatusDePassagem.APassar;
            var item196 = new ExecucaoPontoDeColetaViewModel();

            item196.PontoDeColeta.Nome = "TESTE";
            item196.PontoDeColeta.Horario = "13:00";
            item196.StatusDePassagem = StatusDePassagem.APassar;
            var item197 = new ExecucaoPontoDeColetaViewModel();

            item197.PontoDeColeta.Nome = "TESTE";
            item197.PontoDeColeta.Horario = "13:00";
            item197.StatusDePassagem = StatusDePassagem.APassar;
            var item198 = new ExecucaoPontoDeColetaViewModel();

            item198.PontoDeColeta.Nome = "TESTE";
            item198.PontoDeColeta.Horario = "13:00";
            item198.StatusDePassagem = StatusDePassagem.APassar;
            var item199 = new ExecucaoPontoDeColetaViewModel();

            item199.PontoDeColeta.Nome = "TESTE";
            item199.PontoDeColeta.Horario = "13:00";
            item199.StatusDePassagem = StatusDePassagem.APassar;
            var item1100 = new ExecucaoPontoDeColetaViewModel();

            item1100.PontoDeColeta.Nome = "TESTE";
            item1100.PontoDeColeta.Horario = "13:00";
            item1100.StatusDePassagem = StatusDePassagem.APassar;
            var item1101 = new ExecucaoPontoDeColetaViewModel();

            item1101.PontoDeColeta.Nome = "TESTE";
            item1101.PontoDeColeta.Horario = "13:00";
            item1101.StatusDePassagem = StatusDePassagem.APassar;
            var item1102 = new ExecucaoPontoDeColetaViewModel();

            item1102.PontoDeColeta.Nome = "TESTE";
            item1102.PontoDeColeta.Horario = "13:00";
            item1102.StatusDePassagem = StatusDePassagem.APassar;
            var item1103 = new ExecucaoPontoDeColetaViewModel();

            item1103.PontoDeColeta.Nome = "TESTE";
            item1103.PontoDeColeta.Horario = "13:00";
            item1103.StatusDePassagem = StatusDePassagem.APassar;
            var item1104 = new ExecucaoPontoDeColetaViewModel();

            item1104.PontoDeColeta.Nome = "TESTE";
            item1104.PontoDeColeta.Horario = "13:00";
            item1104.StatusDePassagem = StatusDePassagem.APassar;
            var item1105 = new ExecucaoPontoDeColetaViewModel();

            item1105.PontoDeColeta.Nome = "TESTE";
            item1105.PontoDeColeta.Horario = "13:00";
            item1105.StatusDePassagem = StatusDePassagem.APassar;

            setor1.ServicoEmExecucao.Add(item11);
            setor1.ServicoEmExecucao.Add(item12);
            setor1.ServicoEmExecucao.Add(item13);
            setor1.ServicoEmExecucao.Add(item14);
            setor1.ServicoEmExecucao.Add(item15);
            setor1.ServicoEmExecucao.Add(item16);
            setor1.ServicoEmExecucao.Add(item17);
            setor1.ServicoEmExecucao.Add(item18);
            setor1.ServicoEmExecucao.Add(item19);
            setor1.ServicoEmExecucao.Add(item110);
            setor1.ServicoEmExecucao.Add(item111);
            setor1.ServicoEmExecucao.Add(item112);
            setor1.ServicoEmExecucao.Add(item113);
            setor1.ServicoEmExecucao.Add(item114);
            setor1.ServicoEmExecucao.Add(item115);
            setor1.ServicoEmExecucao.Add(item116);
            setor1.ServicoEmExecucao.Add(item117);
            setor1.ServicoEmExecucao.Add(item118);
            setor1.ServicoEmExecucao.Add(item119);
            setor1.ServicoEmExecucao.Add(item120);
            setor1.ServicoEmExecucao.Add(item121);
            setor1.ServicoEmExecucao.Add(item122);
            setor1.ServicoEmExecucao.Add(item123);
            setor1.ServicoEmExecucao.Add(item124);
            setor1.ServicoEmExecucao.Add(item125);
            setor1.ServicoEmExecucao.Add(item126);
            setor1.ServicoEmExecucao.Add(item127);
            setor1.ServicoEmExecucao.Add(item128);
            setor1.ServicoEmExecucao.Add(item129);
            setor1.ServicoEmExecucao.Add(item130);
            setor1.ServicoEmExecucao.Add(item131);
            setor1.ServicoEmExecucao.Add(item132);
            setor1.ServicoEmExecucao.Add(item133);
            setor1.ServicoEmExecucao.Add(item134);
            setor1.ServicoEmExecucao.Add(item135);
            setor1.ServicoEmExecucao.Add(item136);
            setor1.ServicoEmExecucao.Add(item137);
            setor1.ServicoEmExecucao.Add(item138);
            setor1.ServicoEmExecucao.Add(item139);
            setor1.ServicoEmExecucao.Add(item140);
            setor1.ServicoEmExecucao.Add(item141);
            setor1.ServicoEmExecucao.Add(item142);
            setor1.ServicoEmExecucao.Add(item143);
            setor1.ServicoEmExecucao.Add(item144);
            setor1.ServicoEmExecucao.Add(item145);
            setor1.ServicoEmExecucao.Add(item146);
            setor1.ServicoEmExecucao.Add(item147);
            setor1.ServicoEmExecucao.Add(item148);
            setor1.ServicoEmExecucao.Add(item149);
            setor1.ServicoEmExecucao.Add(item150);
            setor1.ServicoEmExecucao.Add(item151);
            setor1.ServicoEmExecucao.Add(item152);
            setor1.ServicoEmExecucao.Add(item153);
            setor1.ServicoEmExecucao.Add(item154);
            setor1.ServicoEmExecucao.Add(item155);
            setor1.ServicoEmExecucao.Add(item156);
            setor1.ServicoEmExecucao.Add(item157);
            setor1.ServicoEmExecucao.Add(item158);
            setor1.ServicoEmExecucao.Add(item159);
            setor1.ServicoEmExecucao.Add(item160);
            setor1.ServicoEmExecucao.Add(item161);
            setor1.ServicoEmExecucao.Add(item162);
            setor1.ServicoEmExecucao.Add(item163);
            setor1.ServicoEmExecucao.Add(item164);
            setor1.ServicoEmExecucao.Add(item165);
            setor1.ServicoEmExecucao.Add(item166);
            setor1.ServicoEmExecucao.Add(item167);
            setor1.ServicoEmExecucao.Add(item168);
            setor1.ServicoEmExecucao.Add(item169);
            setor1.ServicoEmExecucao.Add(item170);
            setor1.ServicoEmExecucao.Add(item171);
            setor1.ServicoEmExecucao.Add(item172);
            setor1.ServicoEmExecucao.Add(item173);
            setor1.ServicoEmExecucao.Add(item174);
            setor1.ServicoEmExecucao.Add(item175);
            setor1.ServicoEmExecucao.Add(item176);
            setor1.ServicoEmExecucao.Add(item177);
            setor1.ServicoEmExecucao.Add(item178);
            setor1.ServicoEmExecucao.Add(item179);
            setor1.ServicoEmExecucao.Add(item180);
            setor1.ServicoEmExecucao.Add(item181);
            setor1.ServicoEmExecucao.Add(item182);
            setor1.ServicoEmExecucao.Add(item183);
            setor1.ServicoEmExecucao.Add(item184);
            setor1.ServicoEmExecucao.Add(item185);
            setor1.ServicoEmExecucao.Add(item186);
            setor1.ServicoEmExecucao.Add(item187);
            setor1.ServicoEmExecucao.Add(item188);
            setor1.ServicoEmExecucao.Add(item189);
            setor1.ServicoEmExecucao.Add(item190);
            setor1.ServicoEmExecucao.Add(item191);
            setor1.ServicoEmExecucao.Add(item192);
            setor1.ServicoEmExecucao.Add(item193);
            setor1.ServicoEmExecucao.Add(item194);
            setor1.ServicoEmExecucao.Add(item195);
            setor1.ServicoEmExecucao.Add(item196);
            setor1.ServicoEmExecucao.Add(item197);
            setor1.ServicoEmExecucao.Add(item198);
            setor1.ServicoEmExecucao.Add(item199);
            setor1.ServicoEmExecucao.Add(item1100);
            setor1.ServicoEmExecucao.Add(item1101);
            setor1.ServicoEmExecucao.Add(item1102);
            setor1.ServicoEmExecucao.Add(item1103);
            setor1.ServicoEmExecucao.Add(item1104);
            setor1.ServicoEmExecucao.Add(item1105);
        }

        private static void GerarMassaSetor2(MonitoramentoDeColetaViewModel setor2)
        {
            setor2.ServicoEmExecucao = new List<ExecucaoPontoDeColetaViewModel>();

            var item21 = new ExecucaoPontoDeColetaViewModel();

            item21.PontoDeColeta.Nome = "TESTE";
            item21.PontoDeColeta.Horario = "13:00";
            item21.StatusDePassagem = StatusDePassagem.Passado;

            var item22 = new ExecucaoPontoDeColetaViewModel();

            item22.PontoDeColeta.Nome = "TESTE";
            item22.PontoDeColeta.Horario = "13:00";
            item22.StatusDePassagem = StatusDePassagem.Passado;

            var item23 = new ExecucaoPontoDeColetaViewModel();

            item23.PontoDeColeta.Nome = "TESTE";
            item23.PontoDeColeta.Horario = "13:00";
            item23.StatusDePassagem = StatusDePassagem.Passado;

            var item24 = new ExecucaoPontoDeColetaViewModel();

            item24.PontoDeColeta.Nome = "TESTE";
            item24.PontoDeColeta.Horario = "13:00";
            item24.StatusDePassagem = StatusDePassagem.Passado;

            var item25 = new ExecucaoPontoDeColetaViewModel();

            item25.PontoDeColeta.Nome = "TESTE";
            item25.PontoDeColeta.Horario = "13:00";
            item25.StatusDePassagem = StatusDePassagem.Passado;

            var item26 = new ExecucaoPontoDeColetaViewModel();

            item26.PontoDeColeta.Nome = "TESTE";
            item26.PontoDeColeta.Horario = "13:00";
            item26.StatusDePassagem = StatusDePassagem.Passado;

            var item27 = new ExecucaoPontoDeColetaViewModel();

            item27.PontoDeColeta.Nome = "TESTE";
            item27.PontoDeColeta.Horario = "13:00";
            item27.StatusDePassagem = StatusDePassagem.Passado;

            var item28 = new ExecucaoPontoDeColetaViewModel();

            item28.PontoDeColeta.Nome = "TESTE";
            item28.PontoDeColeta.Horario = "13:00";
            item28.StatusDePassagem = StatusDePassagem.Passado;

            var item29 = new ExecucaoPontoDeColetaViewModel();

            item29.PontoDeColeta.Nome = "TESTE";
            item29.PontoDeColeta.Horario = "13:00";
            item29.StatusDePassagem = StatusDePassagem.Passado;

            var item210 = new ExecucaoPontoDeColetaViewModel();

            item210.PontoDeColeta.Nome = "TESTE";
            item210.PontoDeColeta.Horario = "13:00";
            item210.StatusDePassagem = StatusDePassagem.Passado;

            var item211 = new ExecucaoPontoDeColetaViewModel();

            item211.PontoDeColeta.Nome = "TESTE";
            item211.PontoDeColeta.Horario = "13:00";
            item211.StatusDePassagem = StatusDePassagem.Passado;

            var item212 = new ExecucaoPontoDeColetaViewModel();

            item212.PontoDeColeta.Nome = "TESTE";
            item212.PontoDeColeta.Horario = "13:00";
            item212.StatusDePassagem = StatusDePassagem.Passado;

            var item213 = new ExecucaoPontoDeColetaViewModel();

            item213.PontoDeColeta.Nome = "TESTE";
            item213.PontoDeColeta.Horario = "13:00";
            item213.StatusDePassagem = StatusDePassagem.Passado;

            var item214 = new ExecucaoPontoDeColetaViewModel();

            item214.PontoDeColeta.Nome = "TESTE";
            item214.PontoDeColeta.Horario = "13:00";
            item214.StatusDePassagem = StatusDePassagem.Passado;

            var item215 = new ExecucaoPontoDeColetaViewModel();

            item215.PontoDeColeta.Nome = "TESTE";
            item215.PontoDeColeta.Horario = "13:00";
            item215.StatusDePassagem = StatusDePassagem.Passado;

            var item216 = new ExecucaoPontoDeColetaViewModel();

            item216.PontoDeColeta.Nome = "TESTE";
            item216.PontoDeColeta.Horario = "13:00";
            item216.StatusDePassagem = StatusDePassagem.Passado;

            var item217 = new ExecucaoPontoDeColetaViewModel();

            item217.PontoDeColeta.Nome = "TESTE";
            item217.PontoDeColeta.Horario = "13:00";
            item217.StatusDePassagem = StatusDePassagem.Passado;

            var item218 = new ExecucaoPontoDeColetaViewModel();

            item218.PontoDeColeta.Nome = "TESTE";
            item218.PontoDeColeta.Horario = "13:00";
            item218.StatusDePassagem = StatusDePassagem.Passado;

            var item219 = new ExecucaoPontoDeColetaViewModel();

            item219.PontoDeColeta.Nome = "TESTE";
            item219.PontoDeColeta.Horario = "13:00";
            item219.StatusDePassagem = StatusDePassagem.Passado;

            var item220 = new ExecucaoPontoDeColetaViewModel();

            item220.PontoDeColeta.Nome = "TESTE";
            item220.PontoDeColeta.Horario = "13:00";
            item220.StatusDePassagem = StatusDePassagem.Passado;

            var item221 = new ExecucaoPontoDeColetaViewModel();

            item221.PontoDeColeta.Nome = "TESTE";
            item221.PontoDeColeta.Horario = "13:00";
            item221.StatusDePassagem = StatusDePassagem.Passado;

            var item222 = new ExecucaoPontoDeColetaViewModel();

            item222.PontoDeColeta.Nome = "TESTE";
            item222.PontoDeColeta.Horario = "13:00";
            item222.StatusDePassagem = StatusDePassagem.Passado;

            var item223 = new ExecucaoPontoDeColetaViewModel();

            item223.PontoDeColeta.Nome = "TESTE";
            item223.PontoDeColeta.Horario = "13:00";
            item223.StatusDePassagem = StatusDePassagem.Passado;

            var item224 = new ExecucaoPontoDeColetaViewModel();

            item224.PontoDeColeta.Nome = "TESTE";
            item224.PontoDeColeta.Horario = "13:00";
            item224.StatusDePassagem = StatusDePassagem.Passado;

            var item225 = new ExecucaoPontoDeColetaViewModel();

            item225.PontoDeColeta.Nome = "TESTE";
            item225.PontoDeColeta.Horario = "13:00";
            item225.StatusDePassagem = StatusDePassagem.Passado;

            var item226 = new ExecucaoPontoDeColetaViewModel();

            item226.PontoDeColeta.Nome = "TESTE";
            item226.PontoDeColeta.Horario = "13:00";
            item226.StatusDePassagem = StatusDePassagem.Passado;

            var item227 = new ExecucaoPontoDeColetaViewModel();

            item227.PontoDeColeta.Nome = "TESTE";
            item227.PontoDeColeta.Horario = "13:00";
            item227.StatusDePassagem = StatusDePassagem.Passado;

            var item228 = new ExecucaoPontoDeColetaViewModel();

            item228.PontoDeColeta.Nome = "TESTE";
            item228.PontoDeColeta.Horario = "13:00";
            item228.StatusDePassagem = StatusDePassagem.Passado;

            var item229 = new ExecucaoPontoDeColetaViewModel();

            item229.PontoDeColeta.Nome = "TESTE";
            item229.PontoDeColeta.Horario = "13:00";
            item229.StatusDePassagem = StatusDePassagem.Passado;

            var item230 = new ExecucaoPontoDeColetaViewModel();

            item230.PontoDeColeta.Nome = "TESTE";
            item230.PontoDeColeta.Horario = "13:00";
            item230.StatusDePassagem = StatusDePassagem.Passado;

            var item231 = new ExecucaoPontoDeColetaViewModel();

            item231.PontoDeColeta.Nome = "TESTE";
            item231.PontoDeColeta.Horario = "13:00";
            item231.StatusDePassagem = StatusDePassagem.Passado;

            var item232 = new ExecucaoPontoDeColetaViewModel();

            item232.PontoDeColeta.Nome = "TESTE";
            item232.PontoDeColeta.Horario = "13:00";
            item232.StatusDePassagem = StatusDePassagem.Passado;

            var item233 = new ExecucaoPontoDeColetaViewModel();

            item233.PontoDeColeta.Nome = "TESTE";
            item233.PontoDeColeta.Horario = "13:00";
            item233.StatusDePassagem = StatusDePassagem.Passado;

            var item234 = new ExecucaoPontoDeColetaViewModel();

            item234.PontoDeColeta.Nome = "TESTE";
            item234.PontoDeColeta.Horario = "13:00";
            item234.StatusDePassagem = StatusDePassagem.Passado;

            var item235 = new ExecucaoPontoDeColetaViewModel();

            item235.PontoDeColeta.Nome = "TESTE";
            item235.PontoDeColeta.Horario = "13:00";
            item235.StatusDePassagem = StatusDePassagem.Passado;

            var item236 = new ExecucaoPontoDeColetaViewModel();

            item236.PontoDeColeta.Nome = "TESTE";
            item236.PontoDeColeta.Horario = "13:00";
            item236.StatusDePassagem = StatusDePassagem.Passado;

            var item237 = new ExecucaoPontoDeColetaViewModel();

            item237.PontoDeColeta.Nome = "TESTE";
            item237.PontoDeColeta.Horario = "13:00";
            item237.StatusDePassagem = StatusDePassagem.Passado;

            var item238 = new ExecucaoPontoDeColetaViewModel();

            item238.PontoDeColeta.Nome = "TESTE";
            item238.PontoDeColeta.Horario = "13:00";
            item238.StatusDePassagem = StatusDePassagem.Passado;

            var item239 = new ExecucaoPontoDeColetaViewModel();

            item239.PontoDeColeta.Nome = "TESTE";
            item239.PontoDeColeta.Horario = "13:00";
            item239.StatusDePassagem = StatusDePassagem.Passado;

            var item240 = new ExecucaoPontoDeColetaViewModel();

            item240.PontoDeColeta.Nome = "TESTE";
            item240.PontoDeColeta.Horario = "13:00";
            item240.StatusDePassagem = StatusDePassagem.Passado;

            var item241 = new ExecucaoPontoDeColetaViewModel();

            item241.PontoDeColeta.Nome = "TESTE";
            item241.PontoDeColeta.Horario = "13:00";
            item241.StatusDePassagem = StatusDePassagem.Passado;

            var item242 = new ExecucaoPontoDeColetaViewModel();

            item242.PontoDeColeta.Nome = "TESTE";
            item242.PontoDeColeta.Horario = "13:00";
            item242.StatusDePassagem = StatusDePassagem.Passado;

            var item243 = new ExecucaoPontoDeColetaViewModel();

            item243.PontoDeColeta.Nome = "TESTE";
            item243.PontoDeColeta.Horario = "13:00";
            item243.StatusDePassagem = StatusDePassagem.Passado;

            var item244 = new ExecucaoPontoDeColetaViewModel();

            item244.PontoDeColeta.Nome = "TESTE";
            item244.PontoDeColeta.Horario = "13:00";
            item244.StatusDePassagem = StatusDePassagem.Passado;

            var item245 = new ExecucaoPontoDeColetaViewModel();

            item245.PontoDeColeta.Nome = "TESTE";
            item245.PontoDeColeta.Horario = "13:00";
            item245.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item246 = new ExecucaoPontoDeColetaViewModel();

            item246.PontoDeColeta.Nome = "TESTE";
            item246.PontoDeColeta.Horario = "13:00";
            item246.StatusDePassagem = StatusDePassagem.NaoCumprido;
            var item247 = new ExecucaoPontoDeColetaViewModel();

            item247.PontoDeColeta.Nome = "TESTE";
            item247.PontoDeColeta.Horario = "13:00";
            item247.StatusDePassagem = StatusDePassagem.Passado;
            var item248 = new ExecucaoPontoDeColetaViewModel();

            item248.PontoDeColeta.Nome = "TESTE";
            item248.PontoDeColeta.Horario = "13:00";
            item248.StatusDePassagem = StatusDePassagem.Passado;
            var item249 = new ExecucaoPontoDeColetaViewModel();

            item249.PontoDeColeta.Nome = "TESTE";
            item249.PontoDeColeta.Horario = "13:00";
            item249.StatusDePassagem = StatusDePassagem.Passado;
            var item250 = new ExecucaoPontoDeColetaViewModel();

            item250.PontoDeColeta.Nome = "TESTE";
            item250.PontoDeColeta.Horario = "13:00";
            item250.StatusDePassagem = StatusDePassagem.Passado;
            var item251 = new ExecucaoPontoDeColetaViewModel();

            item251.PontoDeColeta.Nome = "TESTE";
            item251.PontoDeColeta.Horario = "13:00";
            item251.StatusDePassagem = StatusDePassagem.Passado;
            var item252 = new ExecucaoPontoDeColetaViewModel();

            item252.PontoDeColeta.Nome = "TESTE";
            item252.PontoDeColeta.Horario = "13:00";
            item252.StatusDePassagem = StatusDePassagem.Passado;
            var item253 = new ExecucaoPontoDeColetaViewModel();

            item253.PontoDeColeta.Nome = "TESTE";
            item253.PontoDeColeta.Horario = "13:00";
            item253.StatusDePassagem = StatusDePassagem.Passado;
            var item254 = new ExecucaoPontoDeColetaViewModel();

            item254.PontoDeColeta.Nome = "TESTE";
            item254.PontoDeColeta.Horario = "13:00";
            item254.StatusDePassagem = StatusDePassagem.Passado;
            var item255 = new ExecucaoPontoDeColetaViewModel();

            item255.PontoDeColeta.Nome = "TESTE";
            item255.PontoDeColeta.Horario = "13:00";
            item255.StatusDePassagem = StatusDePassagem.Passado;
            var item256 = new ExecucaoPontoDeColetaViewModel();

            item256.PontoDeColeta.Nome = "TESTE";
            item256.PontoDeColeta.Horario = "13:00";
            item256.StatusDePassagem = StatusDePassagem.Passado;
            var item257 = new ExecucaoPontoDeColetaViewModel();

            item257.PontoDeColeta.Nome = "TESTE";
            item257.PontoDeColeta.Horario = "13:00";
            item257.StatusDePassagem = StatusDePassagem.Passado;
            var item258 = new ExecucaoPontoDeColetaViewModel();

            item258.PontoDeColeta.Nome = "TESTE";
            item258.PontoDeColeta.Horario = "13:00";
            item258.StatusDePassagem = StatusDePassagem.Passado;
            var item259 = new ExecucaoPontoDeColetaViewModel();

            item259.PontoDeColeta.Nome = "TESTE";
            item259.PontoDeColeta.Horario = "13:00";
            item259.StatusDePassagem = StatusDePassagem.Passado;
            var item260 = new ExecucaoPontoDeColetaViewModel();

            item260.PontoDeColeta.Nome = "TESTE";
            item260.PontoDeColeta.Horario = "13:00";
            item260.StatusDePassagem = StatusDePassagem.Passado;
            var item261 = new ExecucaoPontoDeColetaViewModel();

            item261.PontoDeColeta.Nome = "TESTE";
            item261.PontoDeColeta.Horario = "13:00";
            item261.StatusDePassagem = StatusDePassagem.Passado;
            var item262 = new ExecucaoPontoDeColetaViewModel();

            item262.PontoDeColeta.Nome = "TESTE";
            item262.PontoDeColeta.Horario = "13:00";
            item262.StatusDePassagem = StatusDePassagem.Passado;
            var item263 = new ExecucaoPontoDeColetaViewModel();

            item263.PontoDeColeta.Nome = "TESTE";
            item263.PontoDeColeta.Horario = "13:00";
            item263.StatusDePassagem = StatusDePassagem.Passado;
            var item264 = new ExecucaoPontoDeColetaViewModel();

            item264.PontoDeColeta.Nome = "TESTE";
            item264.PontoDeColeta.Horario = "13:00";
            item264.StatusDePassagem = StatusDePassagem.Passado;
            var item265 = new ExecucaoPontoDeColetaViewModel();

            item265.PontoDeColeta.Nome = "TESTE";
            item265.PontoDeColeta.Horario = "13:00";
            item265.StatusDePassagem = StatusDePassagem.Passado;
            var item266 = new ExecucaoPontoDeColetaViewModel();

            item266.PontoDeColeta.Nome = "TESTE";
            item266.PontoDeColeta.Horario = "13:00";
            item266.StatusDePassagem = StatusDePassagem.Passado;
            var item267 = new ExecucaoPontoDeColetaViewModel();

            item267.PontoDeColeta.Nome = "TESTE";
            item267.PontoDeColeta.Horario = "13:00";
            item267.StatusDePassagem = StatusDePassagem.Passado;
            var item268 = new ExecucaoPontoDeColetaViewModel();

            item268.PontoDeColeta.Nome = "TESTE";
            item268.PontoDeColeta.Horario = "13:00";
            item268.StatusDePassagem = StatusDePassagem.Passado;
            var item269 = new ExecucaoPontoDeColetaViewModel();

            item269.PontoDeColeta.Nome = "TESTE";
            item269.PontoDeColeta.Horario = "13:00";
            item269.StatusDePassagem = StatusDePassagem.Passado;
            var item270 = new ExecucaoPontoDeColetaViewModel();

            item270.PontoDeColeta.Nome = "TESTE";
            item270.PontoDeColeta.Horario = "13:00";
            item270.StatusDePassagem = StatusDePassagem.Passado;
            var item271 = new ExecucaoPontoDeColetaViewModel();

            item271.PontoDeColeta.Nome = "TESTE";
            item271.PontoDeColeta.Horario = "13:00";
            item271.StatusDePassagem = StatusDePassagem.Passado;
            var item272 = new ExecucaoPontoDeColetaViewModel();

            item272.PontoDeColeta.Nome = "TESTE";
            item272.PontoDeColeta.Horario = "13:00";
            item272.StatusDePassagem = StatusDePassagem.Passado;

            var item273 = new ExecucaoPontoDeColetaViewModel();

            item273.PontoDeColeta.Nome = "TESTE";
            item273.PontoDeColeta.Horario = "13:00";
            item273.StatusDePassagem = StatusDePassagem.Passado;

            var item274 = new ExecucaoPontoDeColetaViewModel();

            item274.PontoDeColeta.Nome = "TESTE";
            item274.PontoDeColeta.Horario = "13:00";
            item274.StatusDePassagem = StatusDePassagem.Passado;

            var item275 = new ExecucaoPontoDeColetaViewModel();

            item275.PontoDeColeta.Nome = "TESTE";
            item275.PontoDeColeta.Horario = "13:00";
            item275.StatusDePassagem = StatusDePassagem.Passado;

            var item276 = new ExecucaoPontoDeColetaViewModel();

            item276.PontoDeColeta.Nome = "TESTE";
            item276.PontoDeColeta.Horario = "13:00";
            item276.StatusDePassagem = StatusDePassagem.Passado;

            var item277 = new ExecucaoPontoDeColetaViewModel();

            item277.PontoDeColeta.Nome = "TESTE";
            item277.PontoDeColeta.Horario = "13:00";
            item277.StatusDePassagem = StatusDePassagem.Passado;
            var item278 = new ExecucaoPontoDeColetaViewModel();

            item278.PontoDeColeta.Nome = "TESTE";
            item278.PontoDeColeta.Horario = "13:00";
            item278.StatusDePassagem = StatusDePassagem.Passado;
            var item279 = new ExecucaoPontoDeColetaViewModel();

            item279.PontoDeColeta.Nome = "TESTE";
            item279.PontoDeColeta.Horario = "13:00";
            item279.StatusDePassagem = StatusDePassagem.Passado;
            var item280 = new ExecucaoPontoDeColetaViewModel();

            item280.PontoDeColeta.Nome = "TESTE";
            item280.PontoDeColeta.Horario = "13:00";
            item280.StatusDePassagem = StatusDePassagem.Passado;
            var item281 = new ExecucaoPontoDeColetaViewModel();

            item281.PontoDeColeta.Nome = "TESTE";
            item281.PontoDeColeta.Horario = "13:00";
            item281.StatusDePassagem = StatusDePassagem.Passado;
            var item282 = new ExecucaoPontoDeColetaViewModel();

            item282.PontoDeColeta.Nome = "TESTE";
            item282.PontoDeColeta.Horario = "13:00";
            item282.StatusDePassagem = StatusDePassagem.Passado;
            var item283 = new ExecucaoPontoDeColetaViewModel();

            item283.PontoDeColeta.Nome = "TESTE";
            item283.PontoDeColeta.Horario = "13:00";
            item283.StatusDePassagem = StatusDePassagem.Passado;
            var item284 = new ExecucaoPontoDeColetaViewModel();

            item284.PontoDeColeta.Nome = "TESTE";
            item284.PontoDeColeta.Horario = "13:00";
            item284.StatusDePassagem = StatusDePassagem.Passado;
            var item285 = new ExecucaoPontoDeColetaViewModel();

            item285.PontoDeColeta.Nome = "TESTE";
            item285.PontoDeColeta.Horario = "13:00";
            item285.StatusDePassagem = StatusDePassagem.Passado;
            var item286 = new ExecucaoPontoDeColetaViewModel();

            item286.PontoDeColeta.Nome = "TESTE";
            item286.PontoDeColeta.Horario = "13:00";
            item286.StatusDePassagem = StatusDePassagem.NaoCumprido;
            var item287 = new ExecucaoPontoDeColetaViewModel();

            item287.PontoDeColeta.Nome = "TESTE";
            item287.PontoDeColeta.Horario = "13:00";
            item287.StatusDePassagem = StatusDePassagem.Passado;
            var item288 = new ExecucaoPontoDeColetaViewModel();

            item288.PontoDeColeta.Nome = "TESTE";
            item288.PontoDeColeta.Horario = "13:00";
            item288.StatusDePassagem = StatusDePassagem.Passado;
            var item289 = new ExecucaoPontoDeColetaViewModel();

            item289.PontoDeColeta.Nome = "TESTE";
            item289.PontoDeColeta.Horario = "13:00";
            item289.StatusDePassagem = StatusDePassagem.Passado;
            var item290 = new ExecucaoPontoDeColetaViewModel();

            item290.PontoDeColeta.Nome = "TESTE";
            item290.PontoDeColeta.Horario = "13:00";
            item290.StatusDePassagem = StatusDePassagem.Passado;
            var item291 = new ExecucaoPontoDeColetaViewModel();

            item291.PontoDeColeta.Nome = "TESTE";
            item291.PontoDeColeta.Horario = "13:00";
            item291.StatusDePassagem = StatusDePassagem.Passado;
            var item292 = new ExecucaoPontoDeColetaViewModel();

            item292.PontoDeColeta.Nome = "TESTE";
            item292.PontoDeColeta.Horario = "13:00";
            item292.StatusDePassagem = StatusDePassagem.Passado;
            var item293 = new ExecucaoPontoDeColetaViewModel();

            item293.PontoDeColeta.Nome = "TESTE";
            item293.PontoDeColeta.Horario = "13:00";
            item293.StatusDePassagem = StatusDePassagem.Passado;
            var item294 = new ExecucaoPontoDeColetaViewModel();

            item294.PontoDeColeta.Nome = "TESTE";
            item294.PontoDeColeta.Horario = "13:00";
            item294.StatusDePassagem = StatusDePassagem.Passado;
            var item295 = new ExecucaoPontoDeColetaViewModel();

            item295.PontoDeColeta.Nome = "TESTE";
            item295.PontoDeColeta.Horario = "13:00";
            item295.StatusDePassagem = StatusDePassagem.APassar;
            var item296 = new ExecucaoPontoDeColetaViewModel();

            item296.PontoDeColeta.Nome = "TESTE";
            item296.PontoDeColeta.Horario = "13:00";
            item296.StatusDePassagem = StatusDePassagem.APassar;
            var item297 = new ExecucaoPontoDeColetaViewModel();

            item297.PontoDeColeta.Nome = "TESTE";
            item297.PontoDeColeta.Horario = "13:00";
            item297.StatusDePassagem = StatusDePassagem.APassar;
            var item298 = new ExecucaoPontoDeColetaViewModel();

            item298.PontoDeColeta.Nome = "TESTE";
            item298.PontoDeColeta.Horario = "13:00";
            item298.StatusDePassagem = StatusDePassagem.APassar;
            var item299 = new ExecucaoPontoDeColetaViewModel();

            item299.PontoDeColeta.Nome = "TESTE";
            item299.PontoDeColeta.Horario = "13:00";
            item299.StatusDePassagem = StatusDePassagem.APassar;
            var item2100 = new ExecucaoPontoDeColetaViewModel();

            item2100.PontoDeColeta.Nome = "TESTE";
            item2100.PontoDeColeta.Horario = "13:00";
            item2100.StatusDePassagem = StatusDePassagem.APassar;
            var item2101 = new ExecucaoPontoDeColetaViewModel();

            item2101.PontoDeColeta.Nome = "TESTE";
            item2101.PontoDeColeta.Horario = "13:00";
            item2101.StatusDePassagem = StatusDePassagem.APassar;
            var item2102 = new ExecucaoPontoDeColetaViewModel();

            item2102.PontoDeColeta.Nome = "TESTE";
            item2102.PontoDeColeta.Horario = "13:00";
            item2102.StatusDePassagem = StatusDePassagem.APassar;
            var item2103 = new ExecucaoPontoDeColetaViewModel();

            item2103.PontoDeColeta.Nome = "TESTE";
            item2103.PontoDeColeta.Horario = "13:00";
            item2103.StatusDePassagem = StatusDePassagem.APassar;
            var item2104 = new ExecucaoPontoDeColetaViewModel();

            item2104.PontoDeColeta.Nome = "TESTE";
            item2104.PontoDeColeta.Horario = "13:00";
            item2104.StatusDePassagem = StatusDePassagem.APassar;
            var item2105 = new ExecucaoPontoDeColetaViewModel();

            item2105.PontoDeColeta.Nome = "TESTE";
            item2105.PontoDeColeta.Horario = "13:00";
            item2105.StatusDePassagem = StatusDePassagem.APassar;


            setor2.ServicoEmExecucao.Add(item21);
            setor2.ServicoEmExecucao.Add(item22);
            setor2.ServicoEmExecucao.Add(item23);
            setor2.ServicoEmExecucao.Add(item24);
            setor2.ServicoEmExecucao.Add(item25);
            setor2.ServicoEmExecucao.Add(item26);
            setor2.ServicoEmExecucao.Add(item27);
            setor2.ServicoEmExecucao.Add(item28);
            setor2.ServicoEmExecucao.Add(item29);
            setor2.ServicoEmExecucao.Add(item210);
            setor2.ServicoEmExecucao.Add(item211);
            setor2.ServicoEmExecucao.Add(item212);
            setor2.ServicoEmExecucao.Add(item213);
            setor2.ServicoEmExecucao.Add(item214);
            setor2.ServicoEmExecucao.Add(item215);
            setor2.ServicoEmExecucao.Add(item216);
            setor2.ServicoEmExecucao.Add(item217);
            setor2.ServicoEmExecucao.Add(item218);
            setor2.ServicoEmExecucao.Add(item219);
            setor2.ServicoEmExecucao.Add(item220);
            setor2.ServicoEmExecucao.Add(item221);
            setor2.ServicoEmExecucao.Add(item222);
            setor2.ServicoEmExecucao.Add(item223);
            setor2.ServicoEmExecucao.Add(item224);
            setor2.ServicoEmExecucao.Add(item225);
            setor2.ServicoEmExecucao.Add(item226);
            setor2.ServicoEmExecucao.Add(item227);
            setor2.ServicoEmExecucao.Add(item228);
            setor2.ServicoEmExecucao.Add(item229);
            setor2.ServicoEmExecucao.Add(item230);
            setor2.ServicoEmExecucao.Add(item231);
            setor2.ServicoEmExecucao.Add(item232);
            setor2.ServicoEmExecucao.Add(item233);
            setor2.ServicoEmExecucao.Add(item234);
            setor2.ServicoEmExecucao.Add(item235);
            setor2.ServicoEmExecucao.Add(item236);
            setor2.ServicoEmExecucao.Add(item237);
            setor2.ServicoEmExecucao.Add(item238);
            setor2.ServicoEmExecucao.Add(item239);
            setor2.ServicoEmExecucao.Add(item240);
            setor2.ServicoEmExecucao.Add(item241);
            setor2.ServicoEmExecucao.Add(item242);
            setor2.ServicoEmExecucao.Add(item243);
            setor2.ServicoEmExecucao.Add(item244);
            setor2.ServicoEmExecucao.Add(item245);
            setor2.ServicoEmExecucao.Add(item246);
            setor2.ServicoEmExecucao.Add(item247);
            setor2.ServicoEmExecucao.Add(item248);
            setor2.ServicoEmExecucao.Add(item249);
            setor2.ServicoEmExecucao.Add(item250);
            setor2.ServicoEmExecucao.Add(item251);
            setor2.ServicoEmExecucao.Add(item252);
            setor2.ServicoEmExecucao.Add(item253);
            setor2.ServicoEmExecucao.Add(item254);
            setor2.ServicoEmExecucao.Add(item255);
            setor2.ServicoEmExecucao.Add(item256);
            setor2.ServicoEmExecucao.Add(item257);
            setor2.ServicoEmExecucao.Add(item258);
            setor2.ServicoEmExecucao.Add(item259);
            setor2.ServicoEmExecucao.Add(item260);
            setor2.ServicoEmExecucao.Add(item261);
            setor2.ServicoEmExecucao.Add(item262);
            setor2.ServicoEmExecucao.Add(item263);
            setor2.ServicoEmExecucao.Add(item264);
            setor2.ServicoEmExecucao.Add(item265);
            setor2.ServicoEmExecucao.Add(item266);
            setor2.ServicoEmExecucao.Add(item267);
            setor2.ServicoEmExecucao.Add(item268);
            setor2.ServicoEmExecucao.Add(item269);
            setor2.ServicoEmExecucao.Add(item270);
            setor2.ServicoEmExecucao.Add(item271);
            setor2.ServicoEmExecucao.Add(item272);
            setor2.ServicoEmExecucao.Add(item273);
            setor2.ServicoEmExecucao.Add(item274);
            setor2.ServicoEmExecucao.Add(item275);
            setor2.ServicoEmExecucao.Add(item276);
            setor2.ServicoEmExecucao.Add(item277);
            setor2.ServicoEmExecucao.Add(item278);
            setor2.ServicoEmExecucao.Add(item279);
            setor2.ServicoEmExecucao.Add(item280);
            setor2.ServicoEmExecucao.Add(item281);
            setor2.ServicoEmExecucao.Add(item282);
            setor2.ServicoEmExecucao.Add(item283);
            setor2.ServicoEmExecucao.Add(item284);
            setor2.ServicoEmExecucao.Add(item285);
            setor2.ServicoEmExecucao.Add(item286);
            setor2.ServicoEmExecucao.Add(item287);
            setor2.ServicoEmExecucao.Add(item288);
            setor2.ServicoEmExecucao.Add(item289);
            setor2.ServicoEmExecucao.Add(item290);
            setor2.ServicoEmExecucao.Add(item291);
            setor2.ServicoEmExecucao.Add(item292);
            setor2.ServicoEmExecucao.Add(item293);
            setor2.ServicoEmExecucao.Add(item294);
            setor2.ServicoEmExecucao.Add(item295);
            setor2.ServicoEmExecucao.Add(item296);
            setor2.ServicoEmExecucao.Add(item297);
            setor2.ServicoEmExecucao.Add(item298);
            setor2.ServicoEmExecucao.Add(item299);
            setor2.ServicoEmExecucao.Add(item2100);
            setor2.ServicoEmExecucao.Add(item2101);
            setor2.ServicoEmExecucao.Add(item2102);
            setor2.ServicoEmExecucao.Add(item2103);
            setor2.ServicoEmExecucao.Add(item2104);
            setor2.ServicoEmExecucao.Add(item2105);
        }

        private static void GerarMassaSetor3(MonitoramentoDeColetaViewModel setor3)
        {
            setor3.ServicoEmExecucao = new List<ExecucaoPontoDeColetaViewModel>();

            var item31 = new ExecucaoPontoDeColetaViewModel();

            item31.PontoDeColeta.Nome = "TESTE";
            item31.PontoDeColeta.Horario = "13:00";
            item31.StatusDePassagem = StatusDePassagem.Passado;

            var item32 = new ExecucaoPontoDeColetaViewModel();

            item32.PontoDeColeta.Nome = "TESTE";
            item32.PontoDeColeta.Horario = "13:00";
            item32.StatusDePassagem = StatusDePassagem.Passado;

            var item33 = new ExecucaoPontoDeColetaViewModel();

            item33.PontoDeColeta.Nome = "TESTE";
            item33.PontoDeColeta.Horario = "13:00";
            item33.StatusDePassagem = StatusDePassagem.Passado;

            var item34 = new ExecucaoPontoDeColetaViewModel();

            item34.PontoDeColeta.Nome = "TESTE";
            item34.PontoDeColeta.Horario = "13:00";
            item34.StatusDePassagem = StatusDePassagem.Passado;

            var item35 = new ExecucaoPontoDeColetaViewModel();

            item35.PontoDeColeta.Nome = "TESTE";
            item35.PontoDeColeta.Horario = "13:00";
            item35.StatusDePassagem = StatusDePassagem.Passado;

            var item36 = new ExecucaoPontoDeColetaViewModel();

            item36.PontoDeColeta.Nome = "TESTE";
            item36.PontoDeColeta.Horario = "13:00";
            item36.StatusDePassagem = StatusDePassagem.Passado;

            var item37 = new ExecucaoPontoDeColetaViewModel();

            item37.PontoDeColeta.Nome = "TESTE";
            item37.PontoDeColeta.Horario = "13:00";
            item37.StatusDePassagem = StatusDePassagem.Passado;

            var item38 = new ExecucaoPontoDeColetaViewModel();

            item38.PontoDeColeta.Nome = "TESTE";
            item38.PontoDeColeta.Horario = "13:00";
            item38.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item39 = new ExecucaoPontoDeColetaViewModel();

            item39.PontoDeColeta.Nome = "TESTE";
            item39.PontoDeColeta.Horario = "13:00";
            item39.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item310 = new ExecucaoPontoDeColetaViewModel();

            item310.PontoDeColeta.Nome = "TESTE";
            item310.PontoDeColeta.Horario = "13:00";
            item310.StatusDePassagem = StatusDePassagem.Passado;

            var item311 = new ExecucaoPontoDeColetaViewModel();

            item311.PontoDeColeta.Nome = "TESTE";
            item311.PontoDeColeta.Horario = "13:00";
            item311.StatusDePassagem = StatusDePassagem.Passado;

            var item312 = new ExecucaoPontoDeColetaViewModel();

            item312.PontoDeColeta.Nome = "TESTE";
            item312.PontoDeColeta.Horario = "13:00";
            item312.StatusDePassagem = StatusDePassagem.Passado;

            var item313 = new ExecucaoPontoDeColetaViewModel();

            item313.PontoDeColeta.Nome = "TESTE";
            item313.PontoDeColeta.Horario = "13:00";
            item313.StatusDePassagem = StatusDePassagem.Passado;

            var item314 = new ExecucaoPontoDeColetaViewModel();

            item314.PontoDeColeta.Nome = "TESTE";
            item314.PontoDeColeta.Horario = "13:00";
            item314.StatusDePassagem = StatusDePassagem.Passado;

            var item315 = new ExecucaoPontoDeColetaViewModel();

            item315.PontoDeColeta.Nome = "TESTE";
            item315.PontoDeColeta.Horario = "13:00";
            item315.StatusDePassagem = StatusDePassagem.Passado;

            var item316 = new ExecucaoPontoDeColetaViewModel();

            item316.PontoDeColeta.Nome = "TESTE";
            item316.PontoDeColeta.Horario = "13:00";
            item316.StatusDePassagem = StatusDePassagem.Passado;

            var item317 = new ExecucaoPontoDeColetaViewModel();

            item317.PontoDeColeta.Nome = "TESTE";
            item317.PontoDeColeta.Horario = "13:00";
            item317.StatusDePassagem = StatusDePassagem.Passado;

            var item318 = new ExecucaoPontoDeColetaViewModel();

            item318.PontoDeColeta.Nome = "TESTE";
            item318.PontoDeColeta.Horario = "13:00";
            item318.StatusDePassagem = StatusDePassagem.Passado;

            var item319 = new ExecucaoPontoDeColetaViewModel();

            item319.PontoDeColeta.Nome = "TESTE";
            item319.PontoDeColeta.Horario = "13:00";
            item319.StatusDePassagem = StatusDePassagem.Passado;

            var item320 = new ExecucaoPontoDeColetaViewModel();

            item320.PontoDeColeta.Nome = "TESTE";
            item320.PontoDeColeta.Horario = "13:00";
            item320.StatusDePassagem = StatusDePassagem.Passado;

            var item321 = new ExecucaoPontoDeColetaViewModel();

            item321.PontoDeColeta.Nome = "TESTE";
            item321.PontoDeColeta.Horario = "13:00";
            item321.StatusDePassagem = StatusDePassagem.Passado;

            var item322 = new ExecucaoPontoDeColetaViewModel();

            item322.PontoDeColeta.Nome = "TESTE";
            item322.PontoDeColeta.Horario = "13:00";
            item322.StatusDePassagem = StatusDePassagem.Passado;

            var item323 = new ExecucaoPontoDeColetaViewModel();

            item323.PontoDeColeta.Nome = "TESTE";
            item323.PontoDeColeta.Horario = "13:00";
            item323.StatusDePassagem = StatusDePassagem.Passado;

            var item324 = new ExecucaoPontoDeColetaViewModel();

            item324.PontoDeColeta.Nome = "TESTE";
            item324.PontoDeColeta.Horario = "13:00";
            item324.StatusDePassagem = StatusDePassagem.Passado;

            var item325 = new ExecucaoPontoDeColetaViewModel();

            item325.PontoDeColeta.Nome = "TESTE";
            item325.PontoDeColeta.Horario = "13:00";
            item325.StatusDePassagem = StatusDePassagem.Passado;

            var item326 = new ExecucaoPontoDeColetaViewModel();

            item326.PontoDeColeta.Nome = "TESTE";
            item326.PontoDeColeta.Horario = "13:00";
            item326.StatusDePassagem = StatusDePassagem.Passado;

            var item327 = new ExecucaoPontoDeColetaViewModel();

            item327.PontoDeColeta.Nome = "TESTE";
            item327.PontoDeColeta.Horario = "13:00";
            item327.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item328 = new ExecucaoPontoDeColetaViewModel();

            item328.PontoDeColeta.Nome = "TESTE";
            item328.PontoDeColeta.Horario = "13:00";
            item328.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item329 = new ExecucaoPontoDeColetaViewModel();

            item329.PontoDeColeta.Nome = "TESTE";
            item329.PontoDeColeta.Horario = "13:00";
            item329.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item330 = new ExecucaoPontoDeColetaViewModel();

            item330.PontoDeColeta.Nome = "TESTE";
            item330.PontoDeColeta.Horario = "13:00";
            item330.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item331 = new ExecucaoPontoDeColetaViewModel();

            item331.PontoDeColeta.Nome = "TESTE";
            item331.PontoDeColeta.Horario = "13:00";
            item331.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item332 = new ExecucaoPontoDeColetaViewModel();

            item332.PontoDeColeta.Nome = "TESTE";
            item332.PontoDeColeta.Horario = "13:00";
            item332.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item333 = new ExecucaoPontoDeColetaViewModel();

            item333.PontoDeColeta.Nome = "TESTE";
            item333.PontoDeColeta.Horario = "13:00";
            item333.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item334 = new ExecucaoPontoDeColetaViewModel();

            item334.PontoDeColeta.Nome = "TESTE";
            item334.PontoDeColeta.Horario = "13:00";
            item334.StatusDePassagem = StatusDePassagem.NaoCumprido;

            var item335 = new ExecucaoPontoDeColetaViewModel();

            item335.PontoDeColeta.Nome = "TESTE";
            item335.PontoDeColeta.Horario = "13:00";
            item335.StatusDePassagem = StatusDePassagem.Passado;

            var item336 = new ExecucaoPontoDeColetaViewModel();

            item336.PontoDeColeta.Nome = "TESTE";
            item336.PontoDeColeta.Horario = "13:00";
            item336.StatusDePassagem = StatusDePassagem.Passado;

            var item337 = new ExecucaoPontoDeColetaViewModel();

            item337.PontoDeColeta.Nome = "TESTE";
            item337.PontoDeColeta.Horario = "13:00";
            item337.StatusDePassagem = StatusDePassagem.Passado;

            var item338 = new ExecucaoPontoDeColetaViewModel();

            item338.PontoDeColeta.Nome = "TESTE";
            item338.PontoDeColeta.Horario = "13:00";
            item338.StatusDePassagem = StatusDePassagem.Passado;

            var item339 = new ExecucaoPontoDeColetaViewModel();

            item339.PontoDeColeta.Nome = "TESTE";
            item339.PontoDeColeta.Horario = "13:00";
            item339.StatusDePassagem = StatusDePassagem.Passado;

            var item340 = new ExecucaoPontoDeColetaViewModel();

            item340.PontoDeColeta.Nome = "TESTE";
            item340.PontoDeColeta.Horario = "13:00";
            item340.StatusDePassagem = StatusDePassagem.APassar;

            var item341 = new ExecucaoPontoDeColetaViewModel();

            item341.PontoDeColeta.Nome = "TESTE";
            item341.PontoDeColeta.Horario = "13:00";
            item341.StatusDePassagem = StatusDePassagem.APassar;

            var item342 = new ExecucaoPontoDeColetaViewModel();

            item342.PontoDeColeta.Nome = "TESTE";
            item342.PontoDeColeta.Horario = "13:00";
            item342.StatusDePassagem = StatusDePassagem.APassar;

            var item343 = new ExecucaoPontoDeColetaViewModel();

            item343.PontoDeColeta.Nome = "TESTE";
            item343.PontoDeColeta.Horario = "13:00";
            item343.StatusDePassagem = StatusDePassagem.APassar;

            var item344 = new ExecucaoPontoDeColetaViewModel();

            item344.PontoDeColeta.Nome = "TESTE";
            item344.PontoDeColeta.Horario = "13:00";
            item344.StatusDePassagem = StatusDePassagem.APassar;

            var item345 = new ExecucaoPontoDeColetaViewModel();

            item345.PontoDeColeta.Nome = "TESTE";
            item345.PontoDeColeta.Horario = "13:00";
            item345.StatusDePassagem = StatusDePassagem.APassar;

            var item346 = new ExecucaoPontoDeColetaViewModel();

            item346.PontoDeColeta.Nome = "TESTE";
            item346.PontoDeColeta.Horario = "13:00";
            item346.StatusDePassagem = StatusDePassagem.APassar;
            var item347 = new ExecucaoPontoDeColetaViewModel();

            item347.PontoDeColeta.Nome = "TESTE";
            item347.PontoDeColeta.Horario = "13:00";
            item347.StatusDePassagem = StatusDePassagem.APassar;
            var item348 = new ExecucaoPontoDeColetaViewModel();

            item348.PontoDeColeta.Nome = "TESTE";
            item348.PontoDeColeta.Horario = "13:00";
            item348.StatusDePassagem = StatusDePassagem.APassar;
            var item349 = new ExecucaoPontoDeColetaViewModel();

            item349.PontoDeColeta.Nome = "TESTE";
            item349.PontoDeColeta.Horario = "13:00";
            item349.StatusDePassagem = StatusDePassagem.APassar;
            var item350 = new ExecucaoPontoDeColetaViewModel();

            item350.PontoDeColeta.Nome = "TESTE";
            item350.PontoDeColeta.Horario = "13:00";
            item350.StatusDePassagem = StatusDePassagem.APassar;
            var item351 = new ExecucaoPontoDeColetaViewModel();

            item351.PontoDeColeta.Nome = "TESTE";
            item351.PontoDeColeta.Horario = "13:00";
            item351.StatusDePassagem = StatusDePassagem.APassar;
            var item352 = new ExecucaoPontoDeColetaViewModel();

            item352.PontoDeColeta.Nome = "TESTE";
            item352.PontoDeColeta.Horario = "13:00";
            item352.StatusDePassagem = StatusDePassagem.APassar;
            var item353 = new ExecucaoPontoDeColetaViewModel();

            item353.PontoDeColeta.Nome = "TESTE";
            item353.PontoDeColeta.Horario = "13:00";
            item353.StatusDePassagem = StatusDePassagem.APassar;
            var item354 = new ExecucaoPontoDeColetaViewModel();

            item354.PontoDeColeta.Nome = "TESTE";
            item354.PontoDeColeta.Horario = "13:00";
            item354.StatusDePassagem = StatusDePassagem.APassar;
            var item355 = new ExecucaoPontoDeColetaViewModel();

            item355.PontoDeColeta.Nome = "TESTE";
            item355.PontoDeColeta.Horario = "13:00";
            item355.StatusDePassagem = StatusDePassagem.APassar;
            var item356 = new ExecucaoPontoDeColetaViewModel();

            item356.PontoDeColeta.Nome = "TESTE";
            item356.PontoDeColeta.Horario = "13:00";
            item356.StatusDePassagem = StatusDePassagem.APassar;
            var item357 = new ExecucaoPontoDeColetaViewModel();

            item357.PontoDeColeta.Nome = "TESTE";
            item357.PontoDeColeta.Horario = "13:00";
            item357.StatusDePassagem = StatusDePassagem.APassar;
            var item358 = new ExecucaoPontoDeColetaViewModel();

            item358.PontoDeColeta.Nome = "TESTE";
            item358.PontoDeColeta.Horario = "13:00";
            item358.StatusDePassagem = StatusDePassagem.APassar;
            var item359 = new ExecucaoPontoDeColetaViewModel();

            item359.PontoDeColeta.Nome = "TESTE";
            item359.PontoDeColeta.Horario = "13:00";
            item359.StatusDePassagem = StatusDePassagem.APassar;
            var item360 = new ExecucaoPontoDeColetaViewModel();

            item360.PontoDeColeta.Nome = "TESTE";
            item360.PontoDeColeta.Horario = "13:00";
            item360.StatusDePassagem = StatusDePassagem.APassar;
            var item361 = new ExecucaoPontoDeColetaViewModel();

            item361.PontoDeColeta.Nome = "TESTE";
            item361.PontoDeColeta.Horario = "13:00";
            item361.StatusDePassagem = StatusDePassagem.APassar;
            var item362 = new ExecucaoPontoDeColetaViewModel();

            item362.PontoDeColeta.Nome = "TESTE";
            item362.PontoDeColeta.Horario = "13:00";
            item362.StatusDePassagem = StatusDePassagem.APassar;
            var item363 = new ExecucaoPontoDeColetaViewModel();

            item363.PontoDeColeta.Nome = "TESTE";
            item363.PontoDeColeta.Horario = "13:00";
            item363.StatusDePassagem = StatusDePassagem.APassar;
            var item364 = new ExecucaoPontoDeColetaViewModel();

            item364.PontoDeColeta.Nome = "TESTE";
            item364.PontoDeColeta.Horario = "13:00";
            item364.StatusDePassagem = StatusDePassagem.APassar;
            var item365 = new ExecucaoPontoDeColetaViewModel();

            item365.PontoDeColeta.Nome = "TESTE";
            item365.PontoDeColeta.Horario = "13:00";
            item365.StatusDePassagem = StatusDePassagem.APassar;
            var item366 = new ExecucaoPontoDeColetaViewModel();

            item366.PontoDeColeta.Nome = "TESTE";
            item366.PontoDeColeta.Horario = "13:00";
            item366.StatusDePassagem = StatusDePassagem.APassar;
            var item367 = new ExecucaoPontoDeColetaViewModel();

            item367.PontoDeColeta.Nome = "TESTE";
            item367.PontoDeColeta.Horario = "13:00";
            item367.StatusDePassagem = StatusDePassagem.APassar;
            var item368 = new ExecucaoPontoDeColetaViewModel();

            item368.PontoDeColeta.Nome = "TESTE";
            item368.PontoDeColeta.Horario = "13:00";
            item368.StatusDePassagem = StatusDePassagem.APassar;
            var item369 = new ExecucaoPontoDeColetaViewModel();

            item369.PontoDeColeta.Nome = "TESTE";
            item369.PontoDeColeta.Horario = "13:00";
            item369.StatusDePassagem = StatusDePassagem.APassar;
            var item370 = new ExecucaoPontoDeColetaViewModel();

            item370.PontoDeColeta.Nome = "TESTE";
            item370.PontoDeColeta.Horario = "13:00";
            item370.StatusDePassagem = StatusDePassagem.APassar;
            var item371 = new ExecucaoPontoDeColetaViewModel();

            item371.PontoDeColeta.Nome = "TESTE";
            item371.PontoDeColeta.Horario = "13:00";
            item371.StatusDePassagem = StatusDePassagem.APassar;
            var item372 = new ExecucaoPontoDeColetaViewModel();

            item372.PontoDeColeta.Nome = "TESTE";
            item372.PontoDeColeta.Horario = "13:00";
            item372.StatusDePassagem = StatusDePassagem.APassar;

            var item373 = new ExecucaoPontoDeColetaViewModel();

            item373.PontoDeColeta.Nome = "TESTE";
            item373.PontoDeColeta.Horario = "13:00";
            item373.StatusDePassagem = StatusDePassagem.APassar;

            var item374 = new ExecucaoPontoDeColetaViewModel();

            item374.PontoDeColeta.Nome = "TESTE";
            item374.PontoDeColeta.Horario = "13:00";
            item374.StatusDePassagem = StatusDePassagem.APassar;

            var item375 = new ExecucaoPontoDeColetaViewModel();

            item375.PontoDeColeta.Nome = "TESTE";
            item375.PontoDeColeta.Horario = "13:00";
            item375.StatusDePassagem = StatusDePassagem.APassar;

            var item376 = new ExecucaoPontoDeColetaViewModel();

            item376.PontoDeColeta.Nome = "TESTE";
            item376.PontoDeColeta.Horario = "13:00";
            item376.StatusDePassagem = StatusDePassagem.APassar;

            var item377 = new ExecucaoPontoDeColetaViewModel();

            item377.PontoDeColeta.Nome = "TESTE";
            item377.PontoDeColeta.Horario = "13:00";
            item377.StatusDePassagem = StatusDePassagem.APassar;
            var item378 = new ExecucaoPontoDeColetaViewModel();

            item378.PontoDeColeta.Nome = "TESTE";
            item378.PontoDeColeta.Horario = "13:00";
            item378.StatusDePassagem = StatusDePassagem.APassar;
            var item379 = new ExecucaoPontoDeColetaViewModel();

            item379.PontoDeColeta.Nome = "TESTE";
            item379.PontoDeColeta.Horario = "13:00";
            item379.StatusDePassagem = StatusDePassagem.APassar;
            var item380 = new ExecucaoPontoDeColetaViewModel();

            item380.PontoDeColeta.Nome = "TESTE";
            item380.PontoDeColeta.Horario = "13:00";
            item380.StatusDePassagem = StatusDePassagem.APassar;
            var item381 = new ExecucaoPontoDeColetaViewModel();

            item381.PontoDeColeta.Nome = "TESTE";
            item381.PontoDeColeta.Horario = "13:00";
            item381.StatusDePassagem = StatusDePassagem.APassar;
            var item382 = new ExecucaoPontoDeColetaViewModel();

            item382.PontoDeColeta.Nome = "TESTE";
            item382.PontoDeColeta.Horario = "13:00";
            item382.StatusDePassagem = StatusDePassagem.APassar;
            var item383 = new ExecucaoPontoDeColetaViewModel();

            item383.PontoDeColeta.Nome = "TESTE";
            item383.PontoDeColeta.Horario = "13:00";
            item383.StatusDePassagem = StatusDePassagem.APassar;
            var item384 = new ExecucaoPontoDeColetaViewModel();

            item384.PontoDeColeta.Nome = "TESTE";
            item384.PontoDeColeta.Horario = "13:00";
            item384.StatusDePassagem = StatusDePassagem.APassar;
            var item385 = new ExecucaoPontoDeColetaViewModel();

            item385.PontoDeColeta.Nome = "TESTE";
            item385.PontoDeColeta.Horario = "13:00";
            item385.StatusDePassagem = StatusDePassagem.APassar;
            var item386 = new ExecucaoPontoDeColetaViewModel();

            item386.PontoDeColeta.Nome = "TESTE";
            item386.PontoDeColeta.Horario = "13:00";
            item386.StatusDePassagem = StatusDePassagem.APassar;
            var item387 = new ExecucaoPontoDeColetaViewModel();

            item387.PontoDeColeta.Nome = "TESTE";
            item387.PontoDeColeta.Horario = "13:00";
            item387.StatusDePassagem = StatusDePassagem.APassar;
            var item388 = new ExecucaoPontoDeColetaViewModel();

            item388.PontoDeColeta.Nome = "TESTE";
            item388.PontoDeColeta.Horario = "13:00";
            item388.StatusDePassagem = StatusDePassagem.APassar;
            var item389 = new ExecucaoPontoDeColetaViewModel();

            item389.PontoDeColeta.Nome = "TESTE";
            item389.PontoDeColeta.Horario = "13:00";
            item389.StatusDePassagem = StatusDePassagem.APassar;
            var item390 = new ExecucaoPontoDeColetaViewModel();

            item390.PontoDeColeta.Nome = "TESTE";
            item390.PontoDeColeta.Horario = "13:00";
            item390.StatusDePassagem = StatusDePassagem.APassar;
            var item391 = new ExecucaoPontoDeColetaViewModel();

            item391.PontoDeColeta.Nome = "TESTE";
            item391.PontoDeColeta.Horario = "13:00";
            item391.StatusDePassagem = StatusDePassagem.APassar;
            var item392 = new ExecucaoPontoDeColetaViewModel();

            item392.PontoDeColeta.Nome = "TESTE";
            item392.PontoDeColeta.Horario = "13:00";
            item392.StatusDePassagem = StatusDePassagem.APassar;
            var item393 = new ExecucaoPontoDeColetaViewModel();

            item393.PontoDeColeta.Nome = "TESTE";
            item393.PontoDeColeta.Horario = "13:00";
            item393.StatusDePassagem = StatusDePassagem.APassar;
            var item394 = new ExecucaoPontoDeColetaViewModel();

            item394.PontoDeColeta.Nome = "TESTE";
            item394.PontoDeColeta.Horario = "13:00";
            item394.StatusDePassagem = StatusDePassagem.APassar;
            var item395 = new ExecucaoPontoDeColetaViewModel();

            item395.PontoDeColeta.Nome = "TESTE";
            item395.PontoDeColeta.Horario = "13:00";
            item395.StatusDePassagem = StatusDePassagem.APassar;
            var item396 = new ExecucaoPontoDeColetaViewModel();

            item396.PontoDeColeta.Nome = "TESTE";
            item396.PontoDeColeta.Horario = "13:00";
            item396.StatusDePassagem = StatusDePassagem.APassar;
            var item397 = new ExecucaoPontoDeColetaViewModel();

            item397.PontoDeColeta.Nome = "TESTE";
            item397.PontoDeColeta.Horario = "13:00";
            item397.StatusDePassagem = StatusDePassagem.APassar;
            var item398 = new ExecucaoPontoDeColetaViewModel();

            item398.PontoDeColeta.Nome = "TESTE";
            item398.PontoDeColeta.Horario = "13:00";
            item398.StatusDePassagem = StatusDePassagem.APassar;
            var item399 = new ExecucaoPontoDeColetaViewModel();

            item399.PontoDeColeta.Nome = "TESTE";
            item399.PontoDeColeta.Horario = "13:00";
            item399.StatusDePassagem = StatusDePassagem.APassar;
            var item3100 = new ExecucaoPontoDeColetaViewModel();

            item3100.PontoDeColeta.Nome = "TESTE";
            item3100.PontoDeColeta.Horario = "13:00";
            item3100.StatusDePassagem = StatusDePassagem.APassar;
            var item3101 = new ExecucaoPontoDeColetaViewModel();

            item3101.PontoDeColeta.Nome = "TESTE";
            item3101.PontoDeColeta.Horario = "13:00";
            item3101.StatusDePassagem = StatusDePassagem.APassar;
            var item3102 = new ExecucaoPontoDeColetaViewModel();

            item3102.PontoDeColeta.Nome = "TESTE";
            item3102.PontoDeColeta.Horario = "13:00";
            item3102.StatusDePassagem = StatusDePassagem.APassar;
            var item3103 = new ExecucaoPontoDeColetaViewModel();

            item3103.PontoDeColeta.Nome = "TESTE";
            item3103.PontoDeColeta.Horario = "13:00";
            item3103.StatusDePassagem = StatusDePassagem.APassar;
            var item3104 = new ExecucaoPontoDeColetaViewModel();

            item3104.PontoDeColeta.Nome = "TESTE";
            item3104.PontoDeColeta.Horario = "13:00";
            item3104.StatusDePassagem = StatusDePassagem.APassar;
            var item3105 = new ExecucaoPontoDeColetaViewModel();

            item3105.PontoDeColeta.Nome = "TESTE";
            item3105.PontoDeColeta.Horario = "13:00";
            item3105.StatusDePassagem = StatusDePassagem.APassar;


            setor3.ServicoEmExecucao.Add(item31);
            setor3.ServicoEmExecucao.Add(item32);
            setor3.ServicoEmExecucao.Add(item33);
            setor3.ServicoEmExecucao.Add(item34);
            setor3.ServicoEmExecucao.Add(item35);
            setor3.ServicoEmExecucao.Add(item36);
            setor3.ServicoEmExecucao.Add(item37);
            setor3.ServicoEmExecucao.Add(item38);
            setor3.ServicoEmExecucao.Add(item39);
            setor3.ServicoEmExecucao.Add(item310);
            setor3.ServicoEmExecucao.Add(item311);
            setor3.ServicoEmExecucao.Add(item312);
            setor3.ServicoEmExecucao.Add(item313);
            setor3.ServicoEmExecucao.Add(item314);
            setor3.ServicoEmExecucao.Add(item315);
            setor3.ServicoEmExecucao.Add(item316);
            setor3.ServicoEmExecucao.Add(item317);
            setor3.ServicoEmExecucao.Add(item318);
            setor3.ServicoEmExecucao.Add(item319);
            setor3.ServicoEmExecucao.Add(item320);
            setor3.ServicoEmExecucao.Add(item321);
            setor3.ServicoEmExecucao.Add(item322);
            setor3.ServicoEmExecucao.Add(item323);
            setor3.ServicoEmExecucao.Add(item324);
            setor3.ServicoEmExecucao.Add(item325);
            setor3.ServicoEmExecucao.Add(item326);
            setor3.ServicoEmExecucao.Add(item327);
            setor3.ServicoEmExecucao.Add(item328);
            setor3.ServicoEmExecucao.Add(item329);
            setor3.ServicoEmExecucao.Add(item330);
            setor3.ServicoEmExecucao.Add(item331);
            setor3.ServicoEmExecucao.Add(item332);
            setor3.ServicoEmExecucao.Add(item333);
            setor3.ServicoEmExecucao.Add(item334);
            setor3.ServicoEmExecucao.Add(item335);
            setor3.ServicoEmExecucao.Add(item336);
            setor3.ServicoEmExecucao.Add(item337);
            setor3.ServicoEmExecucao.Add(item338);
            setor3.ServicoEmExecucao.Add(item339);
            setor3.ServicoEmExecucao.Add(item340);
            setor3.ServicoEmExecucao.Add(item341);
            setor3.ServicoEmExecucao.Add(item342);
            setor3.ServicoEmExecucao.Add(item343);
            setor3.ServicoEmExecucao.Add(item344);
            setor3.ServicoEmExecucao.Add(item345);
            setor3.ServicoEmExecucao.Add(item346);
            setor3.ServicoEmExecucao.Add(item347);
            setor3.ServicoEmExecucao.Add(item348);
            setor3.ServicoEmExecucao.Add(item349);
            setor3.ServicoEmExecucao.Add(item350);
            setor3.ServicoEmExecucao.Add(item351);
            setor3.ServicoEmExecucao.Add(item352);
            setor3.ServicoEmExecucao.Add(item353);
            setor3.ServicoEmExecucao.Add(item354);
            setor3.ServicoEmExecucao.Add(item355);
            setor3.ServicoEmExecucao.Add(item356);
            setor3.ServicoEmExecucao.Add(item357);
            setor3.ServicoEmExecucao.Add(item358);
            setor3.ServicoEmExecucao.Add(item359);
            setor3.ServicoEmExecucao.Add(item360);
            setor3.ServicoEmExecucao.Add(item361);
            setor3.ServicoEmExecucao.Add(item362);
            setor3.ServicoEmExecucao.Add(item363);
            setor3.ServicoEmExecucao.Add(item364);
            setor3.ServicoEmExecucao.Add(item365);
            setor3.ServicoEmExecucao.Add(item366);
            setor3.ServicoEmExecucao.Add(item367);
            setor3.ServicoEmExecucao.Add(item368);
            setor3.ServicoEmExecucao.Add(item369);
            setor3.ServicoEmExecucao.Add(item370);
            setor3.ServicoEmExecucao.Add(item371);
            setor3.ServicoEmExecucao.Add(item372);
            setor3.ServicoEmExecucao.Add(item373);
            setor3.ServicoEmExecucao.Add(item374);
            setor3.ServicoEmExecucao.Add(item375);
            setor3.ServicoEmExecucao.Add(item376);
            setor3.ServicoEmExecucao.Add(item377);
            setor3.ServicoEmExecucao.Add(item378);
            setor3.ServicoEmExecucao.Add(item379);
            setor3.ServicoEmExecucao.Add(item380);
            setor3.ServicoEmExecucao.Add(item381);
            setor3.ServicoEmExecucao.Add(item382);
            setor3.ServicoEmExecucao.Add(item383);
            setor3.ServicoEmExecucao.Add(item384);
            setor3.ServicoEmExecucao.Add(item385);
            setor3.ServicoEmExecucao.Add(item386);
            setor3.ServicoEmExecucao.Add(item387);
            setor3.ServicoEmExecucao.Add(item388);
            setor3.ServicoEmExecucao.Add(item389);
            setor3.ServicoEmExecucao.Add(item390);
            setor3.ServicoEmExecucao.Add(item391);
            setor3.ServicoEmExecucao.Add(item392);
            setor3.ServicoEmExecucao.Add(item393);
            setor3.ServicoEmExecucao.Add(item394);
            setor3.ServicoEmExecucao.Add(item395);
            setor3.ServicoEmExecucao.Add(item396);
            setor3.ServicoEmExecucao.Add(item397);
            setor3.ServicoEmExecucao.Add(item398);
            setor3.ServicoEmExecucao.Add(item399);
            setor3.ServicoEmExecucao.Add(item3100);
            setor3.ServicoEmExecucao.Add(item3101);
            setor3.ServicoEmExecucao.Add(item3102);
            setor3.ServicoEmExecucao.Add(item3103);
            setor3.ServicoEmExecucao.Add(item3104);
            setor3.ServicoEmExecucao.Add(item3105);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _setorDaJornadaAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}