using CadastroMotorista.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroMotorista.Mappins
{
    public class MotoristaMapping : IEntityTypeConfiguration<Motorista>
    {
        public void Configure(EntityTypeBuilder<Motorista> builder)
        {
            builder.HasKey(p => p.Codigo);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.ToTable("Motorista");
        }
    }
}
