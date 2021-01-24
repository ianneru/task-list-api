using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskList.Domain.ViewModels;

namespace TaskList.Services.Maps
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Tarefa");

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(e => e.Titulo)
                .HasColumnName("Titulo")
                .HasMaxLength(100)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}