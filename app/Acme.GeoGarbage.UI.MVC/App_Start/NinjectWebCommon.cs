using Acme.GeoGarbage.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Aplicacao;
using Acme.GeoGarbage.Dominio.Interfaces.Servicos;
using Acme.GeoGarbage.Repositorio.Repositorios;
using Acme.GeoGarbage.Servicos;
using Acme.GeoGarbage.Dominio.Interfaces.Repositorios;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Acme.GeoGarbage.UI.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Acme.GeoGarbage.UI.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Acme.GeoGarbage.UI.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using Ninject.Web.WebApi;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAplicacaoServicoBase<>)).To(typeof(AplicacaoServicoBase<>));
            kernel.Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
            kernel.Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>));

            kernel.Bind(typeof(IAplicacaoServicoConsulta)).To(typeof(AplicacaoServicoConsulta));
            kernel.Bind(typeof(IServicoConsulta)).To(typeof(ServicoConsulta));
            kernel.Bind(typeof(IRepositorioConsulta)).To(typeof(RepositorioConsulta));

            kernel.Bind<IClienteAplicacaoServico>().To<ClienteAplicacaoServico>();
            kernel.Bind<IClienteServico>().To<ClienteServico>();
            kernel.Bind<IClienteRepositorio>().To<ClienteRepositorio>();

            kernel.Bind<IConstrutorCampoAplicacaoServico>().To<ConstrutorCampoAplicacaoServico>();
            kernel.Bind<IConstrutorCampoServico>().To<ConstrutorCampoServico>();
            kernel.Bind<IConstrutorCampoRepositorio>().To<ConstrutorCampoRepositorio>();

            kernel.Bind<IConstrutorChaveEstrangeiraAplicacaoServico>().To<ConstrutorChaveEstrangeiraAplicacaoServico>();
            kernel.Bind<IConstrutorChaveEstrangeiraServico>().To<ConstrutorChaveEstrangeiraServico>();
            kernel.Bind<IConstrutorChaveEstrangeiraRepositorio>().To<ConstrutorChaveEstrangeiraRepositorio>();

            kernel.Bind<IConstrutorTabelaAplicacaoServico>().To<ConstrutorTabelaAplicacaoServico>();
            kernel.Bind<IConstrutorTabelaServico>().To<ConstrutorTabelaServico>();
            kernel.Bind<IConstrutorTabelaRepositorio>().To<ConstrutorTabelaRepositorio>();

            kernel.Bind<IConfiguracaoAppAplicacaoServico>().To<ConfiguracaoAppAplicacaoServico>();
            kernel.Bind<IConfiguracaoAppServico>().To<ConfiguracaoAppServico>();
            kernel.Bind<IConfiguracaoAppRepositorio>().To<ConfiguracaoAppRepositorio>();

            kernel.Bind<IConsultaPastaAplicacaoServico>().To<ConsultaPastaAplicacaoServico>();
            kernel.Bind<IConsultaPastaServico>().To<ConsultaPastaServico>();
            kernel.Bind<IConsultaPastaRepositorio>().To<ConsultaPastaRepositorio>();

            kernel.Bind<IConsultaDinamicaAplicacaoServico>().To<ConsultaDinamicaAplicacaoServico>();
            kernel.Bind<IConsultaDinamicaServico>().To<ConsultaDinamicaServico>();
            kernel.Bind<IConsultaDinamicaRepositorio>().To<ConsultaDinamicaRepositorio>();

            kernel.Bind<IConsultaDinamicaTabelaAplicacaoServico>().To<ConsultaDinamicaTabelaAplicacaoServico>();
            kernel.Bind<IConsultaDinamicaTabelaServico>().To<ConsultaDinamicaTabelaServico>();
            kernel.Bind<IConsultaDinamicaTabelaRepositorio>().To<ConsultaDinamicaTabelaRepositorio>();

            kernel.Bind<IConsultaDinamicaCampoAplicacaoServico>().To<ConsultaDinamicaCampoAplicacaoServico>();
            kernel.Bind<IConsultaDinamicaCampoServico>().To<ConsultaDinamicaCampoServico>();
            kernel.Bind<IConsultaDinamicaCampoRepositorio>().To<ConsultaDinamicaCampoRepositorio>();

            kernel.Bind<IConsultaDinamicaCondicaoAplicacaoServico>().To<ConsultaDinamicaCondicaoAplicacaoServico>();
            kernel.Bind<IConsultaDinamicaCondicaoServico>().To<ConsultaDinamicaCondicaoServico>();
            kernel.Bind<IConsultaDinamicaCondicaoRepositorio>().To<ConsultaDinamicaCondicaoRepositorio>();

            kernel.Bind<IConsultaDinamicaAssociacaoAplicacaoServico>().To<ConsultaDinamicaAssociacaoAplicacaoServico>();
            kernel.Bind<IConsultaDinamicaAssociacaoServico>().To<ConsultaDinamicaAssociacaoServico>();
            kernel.Bind<IConsultaDinamicaAssociacaoRepositorio>().To<ConsultaDinamicaAssociacaoRepositorio>();

            kernel.Bind<IDescargaAterroAplicacaoServico>().To<DescargaAterroAplicacaoServico>();
            kernel.Bind<IDescargaAterroServico>().To<DescargaAterroServico>();
            kernel.Bind<IDescargaAterroRepositorio>().To<DescargaAterroRepositorio>();

            kernel.Bind<IDescargaDeColetaAplicacaoServico>().To<DescargaDeColetaAplicacaoServico>();
            kernel.Bind<IDescargaDeColetaServico>().To<DescargaDeColetaServico>();
            kernel.Bind<IDescargaDeColetaRepositorio>().To<DescargaDeColetaRepositorio>();

            kernel.Bind<IDeviceAplicacaoServico>().To<DeviceAplicacaoServico>();
            kernel.Bind<IDeviceServico>().To<DeviceServico>();
            kernel.Bind<IDeviceRepositorio>().To<DeviceRepositorio>();

            kernel.Bind<IDeviceInstaladoAplicacaoServico>().To<DeviceInstaladoAplicacaoServico>();
            kernel.Bind<IDeviceInstaladoServico>().To<DeviceInstaladoServico>();
            kernel.Bind<IDeviceInstaladoRepositorio>().To<DeviceInstaladoRepositorio>();

            kernel.Bind<IGaragemAplicacaoServico>().To<GaragemAplicacaoServico>();
            kernel.Bind<IGaragemServico>().To<GaragemServico>();
            kernel.Bind<IGaragemRepositorio>().To<GaragemRepositorio>();

            kernel.Bind<IInterrupcaoAplicacaoServico>().To<InterrupcaoAplicacaoServico>();
            kernel.Bind<IInterrupcaoServico>().To<InterrupcaoServico>();
            kernel.Bind<IInterrupcaoRepositorio>().To<InterrupcaoRepositorio>();

            kernel.Bind<IJornadaAplicacaoServico>().To<JornadaAplicacaoServico>();
            kernel.Bind<IJornadaServico>().To<JornadaServico>();
            kernel.Bind<IJornadaRepositorio>().To<JornadaRepositorio>();

            kernel.Bind<IMotivoInterrupcaoAplicacaoServico>().To<MotivoInterrupcaoAplicacaoServico>();
            kernel.Bind<IMotivoInterrupcaoServico>().To<MotivoInterrupcaoServico>();
            kernel.Bind<IMotivoInterrupcaoRepositorio>().To<MotivoInterrupcaoRepositorio>();

            kernel.Bind<IPerfilAplicacaoServico>().To<PerfilAplicacaoServico>();
            kernel.Bind<IPerfilServico>().To<PerfilServico>();
            kernel.Bind<IPerfilRepositorio>().To<PerfilRepositorio>();

            kernel.Bind<IRecursoDaJornadaAplicacaoServico>().To<RecursoDaJornadaAplicacaoServico>();
            kernel.Bind<IRecursoDaJornadaServico>().To<RecursoDaJornadaServico>();
            kernel.Bind<IRecursoDaJornadaRepositorio>().To<RecursoDaJornadaRepositorio>();

            kernel.Bind<IRecursoDeColetaAplicacaoServico>().To<RecursoDeColetaAplicacaoServico>();
            kernel.Bind<IRecursoDeColetaServico>().To<RecursoDeColetaServico>();
            kernel.Bind<IRecursoDeColetaRepositorio>().To<RecursoDeColetaRepositorio>();

            kernel.Bind<IRetornoParaCompletarColetaAplicacaoServico>().To<RetornoParaCompletarColetaAplicacaoServico>();
            kernel.Bind<IRetornoParaCompletarColetaServico>().To<RetornoParaCompletarColetaServico>();
            kernel.Bind<IRetornoParaCompletarColetaRepositorio>().To<RetornoParaCompletarColetaRepositorio>();

            kernel.Bind<IRetornoParaGaragemAplicacaoServico>().To<RetornoParaGaragemAplicacaoServico>();
            kernel.Bind<IRetornoParaGaragemServico>().To<RetornoParaGaragemServico>();
            kernel.Bind<IRetornoParaGaragemRepositorio>().To<RetornoParaGaragemRepositorio>();

            kernel.Bind<IRotaRealizadaAplicacaoServico>().To<RotaRealizadaAplicacaoServico>();
            kernel.Bind<IRotaRealizadaServico>().To<RotaRealizadaServico>();
            kernel.Bind<IRotaRealizadaRepositorio>().To<RotaRealizadaRepositorio>();

            kernel.Bind<ISelecaoDeNovoSetorAplicacaoServico>().To<SelecaoDeNovoSetorAplicacaoServico>();
            kernel.Bind<ISelecaoDeNovoSetorServico>().To<SelecaoDeNovoSetorServico>();
            kernel.Bind<ISelecaoDeNovoSetorRepositorio>().To<SelecaoDeNovoSetorRepositorio>();

            kernel.Bind<ISetorAplicacaoServico>().To<SetorAplicacaoServico>();
            kernel.Bind<ISetorServico>().To<SetorServico>();
            kernel.Bind<ISetorRepositorio>().To<SetorRepositorio>();

            kernel.Bind<ISetorDaJornadaAplicacaoServico>().To<SetorDaJornadaAplicacaoServico>();
            kernel.Bind<ISetorDaJornadaServico>().To<SetorDaJornadaServico>();
            kernel.Bind<ISetorDaJornadaRepositorio>().To<SetorDaJornadaRepositorio>();

            kernel.Bind<ITokenAplicacaoServico>().To<TokenAplicacaoServico>();
            kernel.Bind<ITokenServico>().To<TokenServico>();
            kernel.Bind<ITokenRepositorio>().To<TokenRepositorio>();

            kernel.Bind<IUsuarioAplicacaoServico>().To<UsuarioAplicacaoServico>();
            kernel.Bind<IUsuarioServico>().To<UsuarioServico>();
            kernel.Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();

            kernel.Bind<IUsuarioDeClienteAplicacaoServico>().To<UsuarioDeClienteAplicacaoServico>();
            kernel.Bind<IUsuarioDeClienteServico>().To<UsuarioDeClienteServico>();
            kernel.Bind<IUsuarioDeClienteRepositorio>().To<UsuarioDeClienteRepositorio>();

            kernel.Bind<IUsuarioPerfilAplicacaoServico>().To<UsuarioPerfilAplicacaoServico>();
            kernel.Bind<IUsuarioPerfilServico>().To<UsuarioPerfilServico>();
            kernel.Bind<IUsuarioPerfilRepositorio>().To<UsuarioPerfilRepositorio>();

            kernel.Bind<IVeiculoAplicacaoServico>().To<VeiculoAplicacaoServico>();
            kernel.Bind<IVeiculoServico>().To<VeiculoServico>();
            kernel.Bind<IVeiculoRepositorio>().To<VeiculoRepositorio>();

            kernel.Bind<IExecucaoPontoDeColetaAplicacaoServico>().To<ExecucaoPontoDeColetaAplicacaoServico>();
            kernel.Bind<IExecucaoPontoDeColetaServico>().To<ExecucaoPontoDeColetaServico>();
            kernel.Bind<IExecucaoPontoDeColetaRepositorio>().To<ExecucaoPontoDeColetaRepositorio>();

            kernel.Bind<IPadraoDaContaAplicacaoServico>().To<PadraoDaContaAplicacaoServico>();
            kernel.Bind<IPadraoDaContaServico>().To<PadraoDaContaServico>();
            kernel.Bind<IPadraoDaContaRepositorio>().To<PadraoDaContaRepositorio>();

            kernel.Bind<IPontoDeColetaAplicacaoServico>().To<PontoDeColetaAplicacaoServico>();
            kernel.Bind<IPontoDeColetaServico>().To<PontoDeColetaServico>();
            kernel.Bind<IPontoDeColetaRepositorio>().To<PontoDeColetaRepositorio>();

            kernel.Bind<IClienteAcessoTraffilogAplicacaoServico>().To<ClienteAcessoTraffilogAplicacaoServico>();
            kernel.Bind<IClienteAcessoTraffilogServico>().To<ClienteAcessoTraffilogServico>();
            kernel.Bind<IClienteAcessoTraffilogRepositorio>().To<ClienteAcessoTraffilogRepositorio>();

            kernel.Bind<IViagemTraffilogAplicacaoServico>().To<ViagemTraffilogAplicacaoServico>();
            kernel.Bind<IViagemTraffilogServico>().To<ViagemTraffilogServico>();
            kernel.Bind<IViagemTraffilogRepositorio>().To<ViagemTraffilogRepositorio>();

            kernel.Bind<ILocalizacaoTraffilogAplicacaoServico>().To<LocalizacaoTraffilogAplicacaoServico>();
            kernel.Bind<ILocalizacaoTraffilogServico>().To<LocalizacaoTraffilogServico>();
            kernel.Bind<ILocalizacaoTraffilogRepositorio>().To<LocalizacaoTraffilogRepositorio>();

            kernel.Bind<IVeiculoAPITraffilogAplicacaoServico>().To<VeiculoAPITraffilogAplicacaoServico>();
            kernel.Bind<IVeiculoAPITraffilogServico>().To<VeiculoAPITraffilogServico>();
            kernel.Bind<IVeiculoAPITraffilogRepositorio>().To<VeiculoAPITraffilogRepositorio>();

            kernel.Bind<ILastMileageEngineAplicacaoServico>().To<LastMileageEngineAplicacaoServico>();
            kernel.Bind<ILastMileageEngineServico>().To<LastMileageEngineServico>();
            kernel.Bind<ILastMileageEngineRepositorio>().To<LastMileageEngineRepositorio>();

        }
    }
}
