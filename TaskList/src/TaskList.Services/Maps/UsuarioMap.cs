using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskList.Domain.ViewModels;

namespace TaskList.Services.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Usuario");

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();
        }
    }
}