using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Acme.GeoGarbage.Dominio.EntidadeDinamica;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Dominio.Enums;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;

namespace Acme.GeoGarbage.UI.MVC.Areas.Relatorio.Controllers
{

    public class ConsultaController : Controller
    {
        private readonly IConsultaPastaAplicacaoServico _consultaPastaAplicacaoServico;
        private readonly IConsultaDinamicaAplicacaoServico _consultaDinamicaAplicacaoServico;
        private readonly IConsultaDinamicaTabelaAplicacaoServico _consultaDinamicaTabelaAplicacaoServico;
        private readonly IConsultaDinamicaCampoAplicacaoServico _consultaDinamicaCampoAplicacaoServico;
        private readonly IConsultaDinamicaCondicaoAplicacaoServico _consultaDinamicaCondicaoAplicacaoServico;
        private readonly IAplicacaoServicoConsulta _aplicacaoServicoConsulta;
        private readonly IConstrutorCampoAplicacaoServico _construtorCampoAplicacaoServico;
        private readonly IConstrutorTabelaAplicacaoServico _construtorTabelaAplicacaoServico;
        private readonly IConstrutorChaveEstrangeiraAplicacaoServico _construtorChaveEstrangeiraAplicacaoServico;
        private readonly IConsultaDinamicaAssociacaoAplicacaoServico _consultaDinamicaAssociacaoAplicacaoServico;

        public ConsultaController(IConsultaPastaAplicacaoServico consultaPastaAplicacaoServico,
                                  IConsultaDinamicaAplicacaoServico consultaDinamicaAplicacaoServico,
                                  IConsultaDinamicaTabelaAplicacaoServico consultaDinamicaTabelaAplicacaoServico,
                                  IConsultaDinamicaCampoAplicacaoServico consultaDinamicaCampoAplicacaoServico,
                                  IConsultaDinamicaCondicaoAplicacaoServico consultaDinamicaCondicaoAplicacaoServico,
                                  IAplicacaoServicoConsulta aplicacaoServicoConsulta,
                                  IConstrutorCampoAplicacaoServico contrutorCampoAplicacaoServico,
                                  IConstrutorTabelaAplicacaoServico construtorTabelaAplicacaoServico,
                                  IConstrutorChaveEstrangeiraAplicacaoServico construtorChaveEstrangeiraAplicacaoServico,
                                  IConsultaDinamicaAssociacaoAplicacaoServico consultaDinamicaAssociacaoAplicacaoServico)
        {
            _consultaPastaAplicacaoServico = consultaPastaAplicacaoServico;
            _consultaDinamicaAplicacaoServico = consultaDinamicaAplicacaoServico;
            _consultaDinamicaTabelaAplicacaoServico = consultaDinamicaTabelaAplicacaoServico;
            _consultaDinamicaCampoAplicacaoServico = consultaDinamicaCampoAplicacaoServico;
            _consultaDinamicaCondicaoAplicacaoServico = consultaDinamicaCondicaoAplicacaoServico;
            _aplicacaoServicoConsulta = aplicacaoServicoConsulta;
            _construtorCampoAplicacaoServico = contrutorCampoAplicacaoServico;
            _construtorTabelaAplicacaoServico = construtorTabelaAplicacaoServico;
            _construtorChaveEstrangeiraAplicacaoServico = construtorChaveEstrangeiraAplicacaoServico;
            _consultaDinamicaAssociacaoAplicacaoServico = consultaDinamicaAssociacaoAplicacaoServico;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _consultaPastaAplicacaoServico.Dispose();
                _consultaDinamicaAplicacaoServico.Dispose();
                _consultaDinamicaTabelaAplicacaoServico.Dispose();
                _consultaDinamicaCampoAplicacaoServico.Dispose();
                _consultaDinamicaCondicaoAplicacaoServico.Dispose();
                _aplicacaoServicoConsulta.Dispose();
                _construtorCampoAplicacaoServico.Dispose();
                _construtorTabelaAplicacaoServico.Dispose();
                _construtorChaveEstrangeiraAplicacaoServico.Dispose();
                _consultaDinamicaAssociacaoAplicacaoServico.Dispose();
            }
            base.Dispose(disposing);
        }


        // GET: Relatorio/Consulta
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        [ChildActionOnly]
        public ActionResult ConsultaViewPartial()
        {
            return PartialView();
        }

        private string MontaSQL(string[] tabelas, string[] campos, string[] relacionamentoList, string[] condicoesList, string[] groupby, string[] ordenacao, bool distinto, bool temfuncao)
        {
            string SQL = "SELECT ";
            if (distinto) { SQL += " DISTINCT "; }
            SQL += string.Join(", ", campos);
            if (relacionamentoList.Any())
            {
                SQL += string.Join(" ", relacionamentoList);
            }
            else
            {
                SQL += $" {Environment.NewLine}FROM ";
                SQL += string.Join(", ", tabelas);
            }
            if (condicoesList.Any())
            {
                SQL += $" {Environment.NewLine}WHERE ";
                SQL += string.Join(" And ", condicoesList);
            }
            if (temfuncao && groupby.Any())
            {
                SQL += $" {Environment.NewLine}GROUP BY ";
                SQL += string.Join(", ", groupby);
            }
            if (ordenacao.Any())
            {
                SQL += $" {Environment.NewLine}ORDER BY ";
                SQL += string.Join(", ", ordenacao);
            }

            return SQL;

        }

        public JsonResult EditarConsultaDinamica(Guid idConsultaDinamicaConstrutor)
        {
            ConsultaDinamica consultaDinamica = _consultaDinamicaAplicacaoServico.BuscaId(idConsultaDinamicaConstrutor);

            if (consultaDinamica != null)
            {
                IEnumerable<ConsultaDinamicaTabela> listConsultaDinamicaTabelas = _consultaDinamicaTabelaAplicacaoServico
                    .BuscaTodos()
                    .Where(p => p.IdConsultaDinamica == idConsultaDinamicaConstrutor);

                IEnumerable<ConsultaDinamicaCampo> listConsultaDinamicaCampos = _consultaDinamicaCampoAplicacaoServico
                    .BuscaTodos()
                    .Where(p => p.IdConsultaDinamica == idConsultaDinamicaConstrutor)
                    .OrderBy(p => p.Apresentacao);

                IEnumerable<ConsultaDinamicaCondicao> listConsultaDinamicaCondicaos = _consultaDinamicaCondicaoAplicacaoServico
                    .BuscaTodos()
                    .Where(p => p.IdConsultaDinamica == idConsultaDinamicaConstrutor);

                IEnumerable<ConsultaDinamicaAssociacao> listConsultaDinamicaAssociacao =
                    _consultaDinamicaAssociacaoAplicacaoServico
                        .BuscaTodos()
                        .Where(p => p.IdConsultaDinamica == idConsultaDinamicaConstrutor);

                var retornaConsulta = new
                {
                    tabelas = listConsultaDinamicaTabelas,
                    campos = listConsultaDinamicaCampos,
                    condicoes = listConsultaDinamicaCondicaos,
                    relacionamentos = listConsultaDinamicaAssociacao
                };

                return Json(retornaConsulta, JsonRequestBehavior.AllowGet);

            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private void strGerarRelacionamento(IEnumerable<ConsultaDinamicaAssociacao> listConsultaDinamicaAssociacao, List<ConsultaDinamicaAssociacao> associacoes, Guid tabelaid, List<Guid> tabelasJoin, List<string> relacionamentoList)
        {
            foreach (ConsultaDinamicaAssociacao consultaDinamicaAssociacao in listConsultaDinamicaAssociacao)
            {

                if (!associacoes.Contains(consultaDinamicaAssociacao))
                {
                    ConstrutorChaveEstrangeira construtorChaveEstrangeira =
                        _construtorChaveEstrangeiraAplicacaoServico.BuscaId(consultaDinamicaAssociacao
                            .IdConstrutorChaveEstrangeira);
                    string tabelaesquerda = _construtorTabelaAplicacaoServico.BuscaId(construtorChaveEstrangeira.IdConstrutorTabela).Nome;
                    string campoesquerdo = _construtorCampoAplicacaoServico.BuscaId(construtorChaveEstrangeira.IdConstrutorCampo).Nome;
                    string tabeladireita = _construtorTabelaAplicacaoServico.BuscaId(construtorChaveEstrangeira.IdConstrutorTabelaMestre).Nome;
                    string campodireito = _construtorCampoAplicacaoServico.BuscaId(construtorChaveEstrangeira.IdConstrutorCampoMestre).Nome;

                    if (tabelaid == construtorChaveEstrangeira.IdConstrutorTabela ||
                        tabelaid == construtorChaveEstrangeira.IdConstrutorTabelaMestre)
                    {

                        if (!tabelasJoin.Any())
                        {
                            tabelasJoin.Add(tabelaid);
                            relacionamentoList.Add($" FROM {_construtorTabelaAplicacaoServico.BuscaId(tabelaid).Nome} ");
                        }

                        if (tabelasJoin.Contains(construtorChaveEstrangeira.IdConstrutorTabelaMestre))
                        {
                            tabelaesquerda = _construtorTabelaAplicacaoServico.BuscaId(construtorChaveEstrangeira.IdConstrutorTabelaMestre).Nome;
                            campoesquerdo = _construtorCampoAplicacaoServico.BuscaId(construtorChaveEstrangeira.IdConstrutorCampoMestre).Nome;
                            tabeladireita = _construtorTabelaAplicacaoServico.BuscaId(construtorChaveEstrangeira.IdConstrutorTabela).Nome;
                            campodireito = _construtorCampoAplicacaoServico.BuscaId(construtorChaveEstrangeira.IdConstrutorCampo).Nome;
                            switch (consultaDinamicaAssociacao.TipoAssociacao)
                            {
                                case TipoAssociacao.LeftJoin:
                                    {
                                        consultaDinamicaAssociacao.TipoAssociacao = TipoAssociacao.RightJoin;
                                        break;
                                    }
                                case TipoAssociacao.RightJoin:
                                    {
                                        consultaDinamicaAssociacao.TipoAssociacao = TipoAssociacao.LeftJoin;
                                        break;
                                    }
                            }
                        }
                        string join;
                        switch (consultaDinamicaAssociacao.TipoAssociacao)
                        {
                            case TipoAssociacao.LeftJoin:
                                {
                                    join = " left join ";
                                    break;
                                }
                            case TipoAssociacao.RightJoin:
                                {
                                    join = " right join ";
                                    break;
                                }
                            case TipoAssociacao.FullJoin:
                                {
                                    join = " full join ";
                                    break;
                                }
                            default:
                                {
                                    join = " inner join ";
                                    break;
                                }
                        }

                        relacionamentoList.Add($" {join} {tabeladireita}  on ( {tabelaesquerda}.{campoesquerdo} = {tabeladireita}.{campodireito} )");

                        associacoes.Add(consultaDinamicaAssociacao);

                        if (!tabelasJoin.Contains(construtorChaveEstrangeira.IdConstrutorTabela))
                        {
                            tabelasJoin.Add(construtorChaveEstrangeira.IdConstrutorTabela);
                            strGerarRelacionamento(listConsultaDinamicaAssociacao, associacoes, construtorChaveEstrangeira.IdConstrutorTabela, tabelasJoin, relacionamentoList);
                        }

                        if (!tabelasJoin.Contains(construtorChaveEstrangeira.IdConstrutorTabelaMestre))
                        {
                            tabelasJoin.Add(construtorChaveEstrangeira.IdConstrutorTabelaMestre);
                            strGerarRelacionamento(listConsultaDinamicaAssociacao, associacoes, construtorChaveEstrangeira.IdConstrutorTabelaMestre, tabelasJoin, relacionamentoList);
                        }
                    }
                }
            }
        }


        public JsonResult RetornaConsultaDinamica(Guid idConsultaDinamica)
        {
            ConsultaDinamica consultaDinamica = _consultaDinamicaAplicacaoServico.BuscaId(idConsultaDinamica);

            if (consultaDinamica != null)
            {
                IEnumerable<ConsultaDinamicaTabela> listConsultaDinamicaTabelas = _consultaDinamicaTabelaAplicacaoServico
                    .BuscaTodos()
                    .Where(p => p.IdConsultaDinamica == idConsultaDinamica);

                IEnumerable<ConsultaDinamicaCampo> listConsultaDinamicaCampos = _consultaDinamicaCampoAplicacaoServico
                    .BuscaTodos()
                    .Where(p => p.IdConsultaDinamica == idConsultaDinamica);

                IEnumerable<ConsultaDinamicaCondicao> listConsultaDinamicaCondicaos = _consultaDinamicaCondicaoAplicacaoServico
                    .BuscaTodos()
                    .Where(p => p.IdConsultaDinamica == idConsultaDinamica);

                IEnumerable<ConsultaDinamicaAssociacao> listConsultaDinamicaAssociacao =
                    _consultaDinamicaAssociacaoAplicacaoServico
                        .BuscaTodos()
                        .Where(p => p.IdConsultaDinamica == idConsultaDinamica);

                List<string> tabelas = new List<string>();
                List<Guid> tabelasId = new List<Guid>();
                foreach (ConsultaDinamicaTabela tabela in listConsultaDinamicaTabelas)
                {
                    tabelas.Add(_construtorTabelaAplicacaoServico.BuscaId(tabela.IdConstrutorTabela).Nome);
                    tabelasId.Add(tabela.IdConstrutorTabela);
                }

                List<Guid> tabelasJoin = new List<Guid>();
                List<string> relacionamentoList = new List<string>();
                List<ConsultaDinamicaAssociacao> associacoes = new List<ConsultaDinamicaAssociacao>();


                if (listConsultaDinamicaAssociacao.Any())
                {
                    foreach (Guid tabelaid in tabelasId)
                    {
                        strGerarRelacionamento(listConsultaDinamicaAssociacao, associacoes, tabelaid, tabelasJoin, relacionamentoList);
                    }

                    foreach (Guid tabelaid in tabelasId)
                    {
                        if (!tabelasJoin.Contains(tabelaid))
                        {
                            relacionamentoList.Add($", {_construtorTabelaAplicacaoServico.BuscaId(tabelaid).Nome}");
                        }
                    }

                }

                List<string> campos = new List<string>();
                List<string> apelidos = new List<string>();
                List<string> camposid = new List<string>();
                List<string> groupby = new List<string>();
                var temfuncao = false;
                foreach (ConsultaDinamicaCampo campo in listConsultaDinamicaCampos.Where(p => p.Apresentacao >= 0).OrderBy(p => p.Apresentacao))
                {
                    ConstrutorCampo field = _construtorCampoAplicacaoServico.BuscaId(campo.IdConstrutorCampo);
                    ConstrutorTabela table = _construtorTabelaAplicacaoServico.BuscaId(field.IdConstrutorTabela);
                    switch (campo.TipoAgregacao)
                    {
                        case TipoAgregacao.None:
                            {
                                if (!EhEnumerator(campos, $"{table.Nome}.{field.Nome}"))
                                    campos.Add($"{table.Nome}.{field.Nome} {table.Nome}{field.Nome}");
                                camposid.Add(field.IdConstrutorCampo.ToString());
                                groupby.Add($"{table.Nome}.{field.Nome}");
                                break;
                            }
                        case TipoAgregacao.Count:
                            {
                                campos.Add($"Count({table.Nome}.{field.Nome}) Contar{table.Nome}{field.Nome}");
                                camposid.Add($"{field.IdConstrutorCampo}&Contar");
                                temfuncao = true;
                                break;
                            }
                        case TipoAgregacao.Avg:
                            {
                                campos.Add($"AVG({table.Nome}.{field.Nome}) Media{table.Nome}{field.Nome}");
                                camposid.Add($"{field.IdConstrutorCampo}&Media");
                                temfuncao = true;
                                break;
                            }
                        case TipoAgregacao.Max:
                            {
                                campos.Add($"Max({table.Nome}.{field.Nome}) Maximo{table.Nome}{field.Nome}");
                                camposid.Add($"{field.IdConstrutorCampo}&Maximo");
                                temfuncao = true;
                                break;
                            }
                        case TipoAgregacao.Min:
                            {
                                campos.Add($"Min({table.Nome}.{field.Nome}) Minimo{table.Nome}{field.Nome}");
                                camposid.Add($"{field.IdConstrutorCampo}&Minimo");
                                temfuncao = true;
                                break;
                            }
                        case TipoAgregacao.Sum:
                            {
                                campos.Add($"Sum({table.Nome}.{field.Nome}) Soma{table.Nome}{field.Nome}");
                                camposid.Add($"{field.IdConstrutorCampo}&Soma");
                                temfuncao = true;
                                break;
                            }
                    }
                    apelidos.Add(campo.ApelidoCampo);
                }

                List<string> ordenacao = new List<string>();
                foreach (ConsultaDinamicaCampo campo in listConsultaDinamicaCampos.Where(p => p.Ordenacao >= 0).OrderBy(p => p.Ordenacao))
                {
                    ConstrutorCampo field = _construtorCampoAplicacaoServico.BuscaId(campo.IdConstrutorCampo);
                    ConstrutorTabela table = _construtorTabelaAplicacaoServico.BuscaId(field.IdConstrutorTabela);
                    ordenacao.Add($"{table.Nome}.{field.Nome}");
                }

                List<string> condicoesList = new List<string>();
                foreach (ConsultaDinamicaCondicao consultaDinamicaCondicao in listConsultaDinamicaCondicaos)
                {
                    string operador = "";
                    string valor_auxiliar = "";
                    ConstrutorCampo field =
                        _construtorCampoAplicacaoServico.BuscaId(consultaDinamicaCondicao.IdConstrutorCampo);
                    ConstrutorTabela table = _construtorTabelaAplicacaoServico.BuscaId(field.IdConstrutorTabela);
                    switch (consultaDinamicaCondicao.Operador)
                    {
                        //Igual = 1,
                        case TipoOperador.Igual:
                            {
                                operador = "=";
                                break;
                            }
                        //NaoIgual = 2,
                        case TipoOperador.NaoIgual:
                            {
                                operador = "<>";
                                break;
                            }
                        //Nulo = 3,
                        case TipoOperador.Nulo:
                            {
                                operador = "is null";
                                break;
                            }
                        //NaoNulo = 4,
                        case TipoOperador.NaoNulo:
                            {
                                operador = "Not is null";
                                break;
                            }
                        //Entre = 5,
                        case TipoOperador.Entre:
                            {
                                operador = "between";
                                break;
                            }
                        //NaoEntre = 6,
                        case TipoOperador.NaoEntre:
                            {
                                operador = "Not between";
                                break;
                            }
                        //MenorQue = 7,
                        case TipoOperador.MenorQue:
                            {
                                operador = "<";
                                break;
                            }
                        //MaiorQue = 8,
                        case TipoOperador.MaiorQue:
                            {
                                operador = ">";
                                break;
                            }
                        //MenorQueOuIgual = 9,
                        case TipoOperador.MenorQueOuIgual:
                            {
                                operador = "<=";
                                break;
                            }
                        //MaiorQueOuIgual = 10,
                        case TipoOperador.MaiorQueOuIgual:
                            {
                                operador = ">=";
                                break;
                            }
                        //NaLista = 11,
                        case TipoOperador.NaLista:
                            {
                                operador = "in";
                                break;
                            }
                        //NaoNaLista = 12,
                        case TipoOperador.NaoNaLista:
                            {
                                operador = "not in";
                                break;
                            }
                        //Como = 13,
                        //ComoEnd = 15,
                        case TipoOperador.Como:
                        case TipoOperador.ComoEnd:
                            {
                                operador = "like";
                                valor_auxiliar = "%";
                                break;
                            }
                        //NaoComo = 14,
                        //NaoComoEnd = 16
                        case TipoOperador.NaoComo:
                        case TipoOperador.NaoComoEnd:
                            {
                                operador = "not like";
                                valor_auxiliar = "%";
                                break;
                            }

                    }
                    switch (consultaDinamicaCondicao.TipoDados)
                    {
                        case TipoDados.Guid:
                        case TipoDados.Texto:
                        case TipoDados.Datahora:
                            {
                                if (consultaDinamicaCondicao.Operador == TipoOperador.ComoEnd || consultaDinamicaCondicao.Operador == TipoOperador.NaoComoEnd)
                                {
                                    condicoesList.Add($"{table.Nome}.{field.Nome} {operador} '{valor_auxiliar}{consultaDinamicaCondicao.Valor}' ");
                                }
                                else
                                {
                                    condicoesList.Add($"{table.Nome}.{field.Nome} {operador} '{consultaDinamicaCondicao.Valor}{valor_auxiliar}' ");
                                }
                                break;
                            }
                        case TipoDados.Numero:
                        case TipoDados.Booleano:
                        case TipoDados.Decimal:
                        case TipoDados.Flutuante:
                            {
                                condicoesList.Add($"{table.Nome}.{field.Nome} {operador} {consultaDinamicaCondicao.Valor} ");
                                break;
                            }
                    }
                }

                string SQL = MontaSQL(tabelas.ToArray(), campos.ToArray(), relacionamentoList.ToArray(), condicoesList.ToArray(), groupby.ToArray(), ordenacao.ToArray(), consultaDinamica.Distinto, temfuncao);

                var returnQuery = new { camposlist = campos, apelidoslist = apelidos, querylist = EntidadeDinamica(camposid, SQL) };

                return Json(returnQuery, JsonRequestBehavior.AllowGet);
            }
            return Json(null);
        }

        [HttpPost]
        public JsonResult DeletarConsultaDinamica(Guid idConsultaDinamica)
        {
            bool retorno = false;
            ConsultaDinamica consultaDinamica = _consultaDinamicaAplicacaoServico.BuscaId(idConsultaDinamica);
            if (consultaDinamica != null)
            {
                _consultaDinamicaAssociacaoAplicacaoServico.RemoveTodosConsultaDinamicaAssociacao(consultaDinamica);
                _consultaDinamicaCondicaoAplicacaoServico.RemoveTodosConsultaDinamicaCondicao(consultaDinamica);
                _consultaDinamicaCampoAplicacaoServico.RemoveTodosConsultaDinamicaCampo(consultaDinamica);
                _consultaDinamicaTabelaAplicacaoServico.RemoveTodosConsultaDinamicaTabela(consultaDinamica);
                _consultaDinamicaAplicacaoServico.Remove(consultaDinamica);

                retorno = true;
            }
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        private bool EhEnumerator(List<string> campos, string v)
        {
            bool retorno = false;
            switch (v)
            {
                case "Jornada.Status":
                    {
                        campos.Add("CASE Jornada.Status WHEN 1 Then \'Em andamento\' When 2 Then \'Não concluida\' When 3 Then \'Finalizada\' Else \'Desconhecido\' End [JornadaStatus]");
                        retorno = true;
                        break;
                    }
                case "ExecucaoPontoDeColeta.StatusDePassagem":
                    {
                        campos.Add("CASE ExecucaoPontoDeColeta.StatusDePassagem WHEN 1 Then \'A passar\' When 2 Then \'Não cumprido\' When 3 Then \'Pulado\' When 4 Then \'Passado\' Else \'Desconhecido\' End [ExecucaoPontoDeColetaStatusDePassagem]");
                        retorno = true;
                        break;
                    }
                case "RecursoDaJornada.Perfil":
                    {
                        campos.Add("CASE RecursoDaJornada.Perfil WHEN 0 Then \'Coletor\' When 1 Then \'Motorista\' Else \'Desconhecido\' End [RecursoDaJornadaPerfil]");
                        retorno = true;
                        break;
                    }
                case "RecursoDeColeta.Perfil":
                    {
                        campos.Add("CASE RecursoDeColeta.Perfil WHEN 0 Then \'Coletor\' When 1 Then \'Motorista\' Else \'Desconhecido\' End [RecursoDeColetaPerfil]");
                        retorno = true;
                        break;
                    }
            }
            return retorno;
        }

        [HttpGet]
        public JsonResult Resultado(List<string> camposid, string SQL)
        {
            try
            {
                var lista = EntidadeDinamica(camposid, SQL);
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("Erro na Consulta", JsonRequestBehavior.DenyGet);
            }
        }

        private dynamic EntidadeDinamica(List<string> camposid, string SQL)
        {
            TypeBuilder builder = Consulta.CreateTypeBuilder("MyDinamicAssembly", "MyModule", "MyType");

            foreach (string id in camposid)
            {
                if (id.IndexOf("&", StringComparison.Ordinal) >= 0)
                {
                    Guid idGuid = Guid.Parse(id.Split('&')[0]);
                    ConstrutorCampo campo = _construtorCampoAplicacaoServico.BuscaId(idGuid);
                    ConstrutorTabela tabela = _construtorTabelaAplicacaoServico.BuscaId(campo.IdConstrutorTabela);

                    switch (id.Split('&')[1])
                    {
                        case "Contar":
                            {
                                Consulta.CreateAutoImplementedProperty(builder, $"Contar{tabela.Nome}{campo.Nome}", typeof(int?));
                                break;
                            }
                        default:
                            {
                                string apelido = $"{id.Split('&')[1]}{tabela.Nome}{campo.Nome}";
                                switch (campo.Tipo)
                                {
                                    case TipoDados.Guid:
                                        Consulta.CreateAutoImplementedProperty(builder, apelido, typeof(Guid?));
                                        break;
                                    case TipoDados.Texto:
                                        Consulta.CreateAutoImplementedProperty(builder, apelido, typeof(string));
                                        break;
                                    case TipoDados.Numero:
                                        Consulta.CreateAutoImplementedProperty(builder, apelido, typeof(int?));
                                        break;
                                    case TipoDados.Datahora:
                                        Consulta.CreateAutoImplementedProperty(builder, apelido, typeof(DateTime?));
                                        break;
                                    case TipoDados.Booleano:
                                        Consulta.CreateAutoImplementedProperty(builder, apelido, typeof(bool?));
                                        break;
                                    case TipoDados.Decimal:
                                        Consulta.CreateAutoImplementedProperty(builder, apelido, typeof(double?));
                                        break;
                                    case TipoDados.Flutuante:
                                        Consulta.CreateAutoImplementedProperty(builder, apelido, typeof(float?));
                                        break;
                                    case TipoDados.Hora:
                                        Consulta.CreateAutoImplementedProperty(builder, apelido, typeof(TimeSpan?));
                                        break;
                                    default:
                                        Consulta.CreateAutoImplementedProperty(builder, apelido, typeof(string));
                                        break;
                                }
                                break;
                            }
                    }
                }
                else
                {
                    Guid idGuid = Guid.Parse(id);
                    ConstrutorCampo campo = _construtorCampoAplicacaoServico.BuscaId(idGuid);
                    ConstrutorTabela tabela = _construtorTabelaAplicacaoServico.BuscaId(campo.IdConstrutorTabela);

                    List<string> listaEnumerator = new List<string>();
                    listaEnumerator.Add("Jornada.Status");
                    listaEnumerator.Add("ExecucaoPontoDeColeta.StatusDePassagem");
                    listaEnumerator.Add("RecursoDaJornada.Perfil");
                    listaEnumerator.Add("RecursoDeColeta.Perfil");

                    if (listaEnumerator.Contains($"{tabela.Nome}.{campo.Nome}"))
                    {
                        Consulta.CreateAutoImplementedProperty(builder, $"{tabela.Nome}{campo.Nome}", typeof(string));
                    }
                    else
                    {
                        switch (campo.Tipo)
                        {
                            case TipoDados.Guid:
                                Consulta.CreateAutoImplementedProperty(builder, $"{tabela.Nome}{campo.Nome}", typeof(Guid?));
                                break;
                            case TipoDados.Texto:
                                Consulta.CreateAutoImplementedProperty(builder, $"{tabela.Nome}{campo.Nome}", typeof(string));
                                break;
                            case TipoDados.Numero:
                                Consulta.CreateAutoImplementedProperty(builder, $"{tabela.Nome}{campo.Nome}", typeof(int?));
                                break;
                            case TipoDados.Datahora:
                                Consulta.CreateAutoImplementedProperty(builder, $"{tabela.Nome}{campo.Nome}", typeof(DateTime?));
                                break;
                            case TipoDados.Booleano:
                                Consulta.CreateAutoImplementedProperty(builder, $"{tabela.Nome}{campo.Nome}", typeof(bool?));
                                break;
                            case TipoDados.Decimal:
                                Consulta.CreateAutoImplementedProperty(builder, $"{tabela.Nome}{campo.Nome}", typeof(double?));
                                break;
                            case TipoDados.Flutuante:
                                Consulta.CreateAutoImplementedProperty(builder, $"{tabela.Nome}{campo.Nome}", typeof(float?));
                                break;
                            case TipoDados.Hora:
                                Consulta.CreateAutoImplementedProperty(builder, $"{tabela.Nome}{campo.Nome}", typeof(TimeSpan?));
                                break;
                            default:
                                Consulta.CreateAutoImplementedProperty(builder, $"{tabela.Nome}{campo.Nome}", typeof(string));
                                break;
                        }
                    }
                }
            }

            Type resultType = builder.CreateType();

            return _aplicacaoServicoConsulta.Lista(resultType, SQL); ;

        }

        [HttpGet]
        public JsonResult ListaPastas()
        {
            var consultaPastaViewModel = _consultaPastaAplicacaoServico.BuscaTodos();

            foreach (var pasta in consultaPastaViewModel)
            {
                pasta.ConsultasDinamicas = _consultaDinamicaAplicacaoServico.BuscaTodos()
                    .Where(p => p.IdConsultaPasta == pasta.IdConsultaPasta);
            }

            return Json(consultaPastaViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CriarPasta(string pasta)
        {
            ConsultaPasta folder = _consultaPastaAplicacaoServico.BuscaPorPasta(pasta);

            string msg = "";

            if (folder == null)
            {
                folder = new ConsultaPasta();
                folder.IdConsultaPasta = Guid.NewGuid();
                folder.NomePasta = pasta;
                _consultaPastaAplicacaoServico.Adiciona(folder);
                msg = "Pasta criada com sucesso";
            }
            else
            {
                msg = "Pasta já existente, por favor informe outro nome!";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CriarConsultaDinamica(Guid? idConsultaDinamica, Guid pasta, string nomeconsulta, Guid[] postTabelas, string[] postAssociacoes, string[] postCampos, string[] postFuncoes, string[] postFiltros, Guid[] postPosicoes, bool distinto)
        {
            try
            {
                if (postFuncoes != null && postPosicoes != null)
                {
                    foreach (Guid posicao in postPosicoes)
                    {
                        if (postCampos.All(p => posicao.ToString() != p.Split('&')[0]) && postFuncoes.All(p => posicao.ToString() != p.Split('&')[0])) { throw new Exception("Não é permitido campo na ordenação que não esteja na lista de campos ou na lista de funções!"); }
                    }
                }

                Guid idGuid;
                if (idConsultaDinamica != null)
                {
                    DeletarConsultaDinamica(idConsultaDinamica.GetValueOrDefault());
                    idGuid = idConsultaDinamica.Value;
                }
                else
                {
                    idGuid = Guid.NewGuid();
                }

                ConsultaPasta consultapasta = _consultaPastaAplicacaoServico.BuscaId(pasta);

                if (consultapasta != null)
                {

                    ConsultaDinamica consultaDinamica = new ConsultaDinamica();
                    consultaDinamica.IdConsultaDinamica = idGuid;
                    consultaDinamica.NomeConsultaDinamica = nomeconsulta;
                    consultaDinamica.Distinto = distinto;
                    consultaDinamica.IdConsultaPasta = pasta;
                    _consultaDinamicaAplicacaoServico.Adiciona(consultaDinamica);

                    foreach (Guid tabela in postTabelas)
                    {
                        ConsultaDinamicaTabela consultaDinamicaTabela = new ConsultaDinamicaTabela();
                        consultaDinamicaTabela.IdConsultaDinamicaTabela = Guid.NewGuid();
                        consultaDinamicaTabela.IdConstrutorTabela = tabela;
                        consultaDinamicaTabela.IdConsultaDinamica = consultaDinamica.IdConsultaDinamica;
                        _consultaDinamicaTabelaAplicacaoServico.Adiciona(consultaDinamicaTabela);
                    }

                    if (postCampos != null)
                    {
                        foreach (string postCampo in postCampos)
                        {
                            Guid campo = Guid.Parse(postCampo.Split('&')[0]);
                            ConsultaDinamicaCampo consultaDinamicaCampo = new ConsultaDinamicaCampo();
                            consultaDinamicaCampo.IdConsultaDinamicaCampo = Guid.NewGuid();
                            consultaDinamicaCampo.IdConsultaDinamica = consultaDinamica.IdConsultaDinamica;
                            consultaDinamicaCampo.IdConstrutorCampo = campo;
                            consultaDinamicaCampo.ApelidoCampo = postCampo.Split('&')[1];
                            consultaDinamicaCampo.TipoAgregacao = TipoAgregacao.None;
                            consultaDinamicaCampo.Apresentacao = Array.IndexOf(postCampos, postCampo);
                            if (postPosicoes != null)
                                consultaDinamicaCampo.Ordenacao = Array.IndexOf(postPosicoes, postCampo);
                            else consultaDinamicaCampo.Ordenacao = -1;
                            _consultaDinamicaCampoAplicacaoServico.Adiciona(consultaDinamicaCampo);
                        }
                    }

                    if (postFuncoes != null)
                    {
                        foreach (string funcao in postFuncoes)
                        {
                            Guid campo = Guid.Parse(funcao.Split('&')[0]);
                            ConsultaDinamicaCampo consultaDinamicaCampo = new ConsultaDinamicaCampo();
                            consultaDinamicaCampo.IdConsultaDinamicaCampo = Guid.NewGuid();
                            consultaDinamicaCampo.IdConsultaDinamica = consultaDinamica.IdConsultaDinamica;
                            consultaDinamicaCampo.IdConstrutorCampo = campo;
                            consultaDinamicaCampo.ApelidoCampo = funcao.Split('&')[2];
                            switch (funcao.Split('&')[1])
                            {
                                case "Contar": { consultaDinamicaCampo.TipoAgregacao = TipoAgregacao.Count; break; }
                                case "Média": { consultaDinamicaCampo.TipoAgregacao = TipoAgregacao.Avg; break; }
                                case "Máximo": { consultaDinamicaCampo.TipoAgregacao = TipoAgregacao.Max; break; }
                                case "Mínimo": { consultaDinamicaCampo.TipoAgregacao = TipoAgregacao.Min; break; }
                                case "Soma": { consultaDinamicaCampo.TipoAgregacao = TipoAgregacao.Sum; break; }
                            }
                            consultaDinamicaCampo.Apresentacao = (postCampos?.Length ?? 0) + Array.IndexOf(postFuncoes, funcao);
                            consultaDinamicaCampo.Ordenacao = -1;
                            _consultaDinamicaCampoAplicacaoServico.Adiciona(consultaDinamicaCampo);
                        }
                    }

                    if (postAssociacoes != null)
                    {
                        foreach (string associacao in postAssociacoes)
                        {
                            Guid ConstrutorChaveEstrangeiraId = Guid.Parse(associacao.Split('&')[0]);
                            ConsultaDinamicaAssociacao consultaDinamicaAssociacao = new ConsultaDinamicaAssociacao();
                            consultaDinamicaAssociacao.IdConsultaDinamicaAssociacao = Guid.NewGuid();
                            consultaDinamicaAssociacao.IdConsultaDinamica = consultaDinamica.IdConsultaDinamica;
                            consultaDinamicaAssociacao.IdConstrutorChaveEstrangeira = ConstrutorChaveEstrangeiraId;
                            switch (associacao.Split('&')[1])
                            {
                                case "=": { consultaDinamicaAssociacao.TipoAssociacao = TipoAssociacao.InnerJoin; break; }
                                case "+=": { consultaDinamicaAssociacao.TipoAssociacao = TipoAssociacao.LeftJoin; break; }
                                case "=+": { consultaDinamicaAssociacao.TipoAssociacao = TipoAssociacao.RightJoin; break; }
                                case "++": { consultaDinamicaAssociacao.TipoAssociacao = TipoAssociacao.FullJoin; break; }
                            }
                            _consultaDinamicaAssociacaoAplicacaoServico.Adiciona(consultaDinamicaAssociacao);
                        }
                    }

                    if (postFiltros != null)
                    {
                        foreach (string filtro in postFiltros)
                        {
                            ConsultaDinamicaCondicao consultaDinamicaCondicao = new ConsultaDinamicaCondicao();

                            ConstrutorCampo campo =
                                _construtorCampoAplicacaoServico.BuscaId(Guid.Parse(filtro.Split('&')[0]));

                            if (campo != null)
                            {
                                consultaDinamicaCondicao.IdConsultaDinamicaCondicao = Guid.NewGuid();
                                consultaDinamicaCondicao.IdConsultaDinamica = consultaDinamica.IdConsultaDinamica;
                                consultaDinamicaCondicao.IdConstrutorCampo = campo.IdConstrutorCampo;

                                switch (filtro.Split('&')[1])
                                {
                                    case "=":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.Igual;
                                            break;
                                        }
                                    case "<>":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.NaoIgual;
                                            break;
                                        }
                                    case "<":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.MenorQue;
                                            break;
                                        }
                                    case "<=":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.MenorQueOuIgual;
                                            break;
                                        }
                                    case ">":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.MaiorQue;
                                            break;
                                        }
                                    case ">=":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.MaiorQueOuIgual;
                                            break;
                                        }
                                    case "Inicia":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.Como;
                                            break;
                                        }
                                    case "Termina":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.ComoEnd;
                                            break;
                                        }
                                    case "Não inicia":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.NaoComo;
                                            break;
                                        }
                                    case "Não termina":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.NaoComoEnd;
                                            break;
                                        }
                                    case "Entre":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.Entre;
                                            break;
                                        }
                                    case "Não está Entre":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.NaoEntre;
                                            break;
                                        }
                                    case "Na Lista":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.NaLista;
                                            break;
                                        }
                                    case "Não está na Lista":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.NaoNaLista;
                                            break;
                                        }
                                    case "Vazio":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.Nulo;
                                            break;
                                        }
                                    case "Não é Vazio":
                                        {
                                            consultaDinamicaCondicao.Operador = TipoOperador.NaoNulo;
                                            break;
                                        }
                                }

                                consultaDinamicaCondicao.Valor = filtro.Split('&')[2];
                                consultaDinamicaCondicao.TipoDados = campo.Tipo;
                                consultaDinamicaCondicao.Fixo = true;
                                _consultaDinamicaCondicaoAplicacaoServico.Adiciona(consultaDinamicaCondicao);
                            }

                        }
                    }

                    if (postPosicoes != null)
                    {
                        foreach (Guid posicao in postPosicoes)
                        {
                            if (postCampos == null || Array.IndexOf(postCampos, posicao) < 0)
                            {
                                ConsultaDinamicaCampo consultaDinamicaCampo = new ConsultaDinamicaCampo();
                                consultaDinamicaCampo.IdConsultaDinamicaCampo = Guid.NewGuid();
                                consultaDinamicaCampo.IdConsultaDinamica = consultaDinamica.IdConsultaDinamica;
                                consultaDinamicaCampo.IdConstrutorCampo = posicao;
                                consultaDinamicaCampo.ApelidoCampo = string.Empty;
                                consultaDinamicaCampo.TipoAgregacao = TipoAgregacao.None;
                                consultaDinamicaCampo.Apresentacao = -1;
                                consultaDinamicaCampo.Ordenacao = Array.IndexOf(postPosicoes, posicao);
                                _consultaDinamicaCampoAplicacaoServico.Adiciona(consultaDinamicaCampo);
                            }
                        }
                    }

                }

                var msg = new { sucesso = true, resposta = $"{nomeconsulta} salvo com sucesso!" };

                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var msg = new { sucesso = false, resposta = e.Message };
                return Json(msg, JsonRequestBehavior.DenyGet);
            }
        }

        [HttpGet]
        public JsonResult ExecutarConsultaDinamica(Guid? idConsultaDinamica, Guid pasta, string nomeconsulta, Guid[] postTabelas, string[] postAssociacoes, string[] postCampos, string[] postFuncoes, string[] postFiltros, Guid[] postPosicoes, bool distinto)
        {
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ExportarExcel(string dados)
        {
            var gv = new GridView();
            gv.DataSource = dados;
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();

            return Json(true, JsonRequestBehavior.AllowGet);

        }
    }
}