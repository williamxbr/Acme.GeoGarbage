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

            kernel.Bind<IUsuarioAplicacaoServico>().To<UsuarioAplicacaoServico>();
            kernel.Bind<IUsuarioServico>().To<UsuarioServico>();
            kernel.Bind<IUsuarioRepositorio>().To<UsuarioRepositorio>();

            kernel.Bind<IConstrutorTabelaAplicacaoServico>().To<ConstrutorTabelaAplicacaoServico>();
            kernel.Bind<IConstrutorTabelaServico>().To<ConstrutorTabelaServico>();
            kernel.Bind<IConstrutorTabelaRepositorio>().To<ConstrutorTabelaRepositorio>();

            kernel.Bind<IConstrutorCampoAplicacaoServico>().To<ConstrutorCampoAplicacaoServico>();
            kernel.Bind<IConstrutorCampoServico>().To<ConstrutorCampoServico>();
            kernel.Bind<IConstrutorCampoRepositorio>().To<ConstrutorCampoRepositorio>();

            kernel.Bind<IConstrutorChaveEstrangeiraAplicacaoServico>().To<ConstrutorChaveEstrangeiraAplicacaoServico>();
            kernel.Bind<IConstrutorChaveEstrangeiraServico>().To<ConstrutorChaveEstrangeiraServico>();
            kernel.Bind<IConstrutorChaveEstrangeiraRepositorio>().To<ConstrutorChaveEstrangeiraRepositorio>();

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

        }
    }
}
