using CadastroMotorista.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CadastroMotorista.Context
{
    public class ContextBD: DbContext
    {
        public ContextBD(DbContextOptions<ContextBD> options) : base(options)
        {

        }

        public DbSet<Motorista> Motoristas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextBD).Assembly);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
