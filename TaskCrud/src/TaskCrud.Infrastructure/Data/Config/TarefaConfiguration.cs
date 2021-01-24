using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskList.Core.Entities;

namespace TaskList.Infrastructure.Data.Config
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.Property(t => t.Titulo)
                .IsRequired();

            builder.Property(t => t.DataCriacao)
                .IsRequired();
        }
    }
}
