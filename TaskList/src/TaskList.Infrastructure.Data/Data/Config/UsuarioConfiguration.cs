using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskList.Domain.Entities;

namespace TaskList.Infrastructure.Data.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(t => t.Username)
                .IsRequired();

            builder.Property(t => t.Password)
                .IsRequired();
        }
    }
}
