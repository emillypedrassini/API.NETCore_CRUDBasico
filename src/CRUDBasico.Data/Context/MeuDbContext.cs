using CRUDBasico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRUDBasico.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ConfigureFuncionario(modelBuilder);
            //ConfigureEndereco(modelBuilder);

            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.Name == "Id")))
            //{
            //    property.IsPrimaryKey();
            //}

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


        //private void ConfigureFuncionario(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Funcionario>(e =>
        //    {
        //        e.ToTable("Funcionario");
        //        e.HasKey(p => p.Id).HasName("Id");
        //        e.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
        //    });
        //}

        //private void ConfigureEndereco(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Endereco>(e =>
        //    {
        //        e.ToTable("Endereco");
        //        e.HasKey(p => p.Id).HasName("Id");
        //        e.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();
        //    });
        //}
    }
}
