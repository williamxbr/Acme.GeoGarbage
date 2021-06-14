using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Acme.GeoGarbage.Dominio.Entidades;
using Acme.GeoGarbage.Repositorio.ConfigEntidades;

namespace Acme.GeoGarbage.Repositorio.Contexto
{
    public class ProjetoAmbientalContext : DbContext
    {
        public ProjetoAmbientalContext()
            : base("ProjetoAmbiental")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ConstrutorCampo> ConstrutorCampos { get; set; }
        public DbSet<ConstrutorTabela> ConstrutorTabelas { get; set; }
        public DbSet<ConstrutorChaveEstrangeira> ConstrutorChaveEstrangeira { get; set; }
        public DbSet<ConsultaPasta> ConsultaPasta { get; set; }
        public DbSet<ConsultaDinamica> ConsultaDinamica { get; set; }
        public DbSet<ConsultaDinamicaTabela> ConsultaDinamicaTabela { get; set; }
        public DbSet<ConsultaDinamicaCampo> ConsultaDinamicaCampo { get; set; }
        public DbSet<ConsultaDinamicaCondicao> ConsultaDinamicaCondicao { get; set; }

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

            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new ConstrutorCampoConfig());
            modelBuilder.Configurations.Add(new ConstrutorTabelaConfig());
            modelBuilder.Configurations.Add(new ConstrutorChaveEstrangeiraConfig());
            modelBuilder.Configurations.Add(new ConsultaPastaConfig());
            modelBuilder.Configurations.Add(new ConsultaDinamicaConfig());
            modelBuilder.Configurations.Add(new ConsultaDinamicaTabelaConfig());
            modelBuilder.Configurations.Add(new ConsultaDinamicaCampoConfig());
            modelBuilder.Configurations.Add(new ConsultaDinamicaCondicaoConfig());

        }

    }
}