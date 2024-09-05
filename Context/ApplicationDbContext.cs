using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLogin.Models;
using System.CodeDom;
using System.Reflection;
using System.Reflection.Emit;

namespace ProjectLogin.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Para poder usar la configuracion assetsbli : Buscsa todas las clases que implementen IEntityTypeConfiguration de config
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //configurationBuilder.Properties<string>().HaveMaxLength(150);
        }
        public DbSet<Usuario> Usuarios => Set<Usuario>();   

    }
}
