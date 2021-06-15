using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Repositorio.ConfigEntidades;

namespace Acme.GeoGarbage.Repositorio.Contexto
{
    public class GeoGarbageContext : DbContext
    {
        public GeoGarbageContext()
            : base("GeoGarbage")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ConfiguracaoApp> ConfiguracaoApps { get; set; }
        public DbSet<ConstrutorCampo> ConstrutorCampos { get; set; }
        public DbSet<ConstrutorTabela> ConstrutorTabelas { get; set; }
        public DbSet<ConstrutorChaveEstrangeira> ConstrutorChaveEstrangeiras { get; set; }
        public DbSet<ConsultaPasta> ConsultaPastas { get; set; }
        public DbSet<ConsultaDinamica> ConsultaDinamicas { get; set; }
        public DbSet<ConsultaDinamicaTabela> ConsultaDinamicaTabela { get; set; }
        public DbSet<ConsultaDinamicaAssociacao> ConsultaDinamicaAssociacaos { get; set; }
        public DbSet<ConsultaDinamicaCampo> ConsultaDinamicaCampo { get; set; }
        public DbSet<ConsultaDinamicaCondicao> ConsultaDinamicaCondicao { get; set; }
        public DbSet<DescargaAterro> DescargaAterros { get; set; }
        public DbSet<DescargaDeColeta> DescargaDeColetas { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceInstalado> DeviceInstalados { get; set; }
        public DbSet<Garagem> Garagems { get; set; }
        public DbSet<Interrupcao> Interrupcaos { get; set; }
        public DbSet<Jornada> Jornadas { get; set; }
        public DbSet<MotivoInterrupcao> MotivoInterrupcaos { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<RecursoDaJornada> RecursoDaJornadas { get; set; }
        public DbSet<RecursoDeColeta> RecursoDeColetas { get; set; }
        public DbSet<RetornoParaCompletarColeta> RetornoParaCompletarColetas { get; set; }
        public DbSet<RetornoParaGaragem> RetornoParaGaragems { get; set; }
        public DbSet<RotaRealizada> RotaRealizadas { get; set; }
        public DbSet<SelecaoDeNovoSetor> SelecaoDeNovoSetors { get; set; }
        public DbSet<SetorDaJornada> SetorDaJornadas { get; set; }
        public DbSet<Setor> Setors { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioDeCliente> UsuarioDeClientes { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfils { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<ExecucaoPontoDeColeta> ExecucaoPontoDeColetas { get; set; }
        public DbSet<PadraoDaConta> PadraoDaContas { get; set; }
        public DbSet<PontoDeColeta> PontoDeColetas { get; set; }
        public DbSet<ClienteAcessoTraffilog> ClienteAcessoTraffilogs { get; set; }
        public DbSet<ViagemTraffilog> ViagemTraffilogs { get; set; }
        public DbSet<LocalizacaoTraffilog> LocalizacaoTraffilogs { get; set; }
        public DbSet<VeiculoAPITraffilog> VeiculoApiTraffilogs { get; set; }
        public DbSet<LastMileageEngine> LastMileageEngines { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id" + p.ReflectedType.Name)
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new ConfiguracaoAppConfig());
            modelBuilder.Configurations.Add(new ConstrutorCampoConfig());
            modelBuilder.Configurations.Add(new ConstrutorTabelaConfig());
            modelBuilder.Configurations.Add(new ConstrutorChaveEstrangeiraConfig());
            modelBuilder.Configurations.Add(new ConsultaPastaConfig());
            modelBuilder.Configurations.Add(new ConsultaDinamicaConfig());
            modelBuilder.Configurations.Add(new ConsultaDinamicaTabelaConfig());
            modelBuilder.Configurations.Add(new ConsultaDinamicaAssociacaoConfig());
            modelBuilder.Configurations.Add(new ConsultaDinamicaCampoConfig());
            modelBuilder.Configurations.Add(new ConsultaDinamicaCondicaoConfig());
            modelBuilder.Configurations.Add(new DescargaAterroConfig());
            modelBuilder.Configurations.Add(new DescargaDeColetaConfig());
            modelBuilder.Configurations.Add(new DeviceConfig());
            modelBuilder.Configurations.Add(new DeviceInstaladoConfig());
            modelBuilder.Configurations.Add(new GaragemConfig());
            modelBuilder.Configurations.Add(new InterrupcaoConfig());
            modelBuilder.Configurations.Add(new JornadaConfig());
            modelBuilder.Configurations.Add(new MotivoInterrupcaoConfig());
            modelBuilder.Configurations.Add(new PerfilConfig());
            modelBuilder.Configurations.Add(new RecursoDaJornadaConfig());
            modelBuilder.Configurations.Add(new RecursoDeColetaConfig());
            modelBuilder.Configurations.Add(new RetornoParaCompletarColetaConfig());
            modelBuilder.Configurations.Add(new RetornoParaGaragemConfig());
            modelBuilder.Configurations.Add(new RotaRealizadaConfig());
            modelBuilder.Configurations.Add(new SelecaoDeNovoSetorConfig());
            modelBuilder.Configurations.Add(new SetorConfig());
            modelBuilder.Configurations.Add(new SetorDaJornadaConfig());
            modelBuilder.Configurations.Add(new TokenConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new UsuarioDeClienteConfig());
            modelBuilder.Configurations.Add(new UsuarioPerfilConfig());
            modelBuilder.Configurations.Add(new VeiculoConfig());
            modelBuilder.Configurations.Add(new ExecucaoPontoDeColetaConfig());
            modelBuilder.Configurations.Add(new PadraoDaContaConfig());
            modelBuilder.Configurations.Add(new PontoDeColetaConfig());
            modelBuilder.Configurations.Add(new ClienteAcessoTraffilogConfig());
            modelBuilder.Configurations.Add(new ViagemTraffilogConfig());
            modelBuilder.Configurations.Add(new LocalizacaoTraffilogConfig());
            modelBuilder.Configurations.Add(new VeiculoAPITraffilogConfig());
            modelBuilder.Configurations.Add(new LastMileageEngineConfig());
        }
    }
}