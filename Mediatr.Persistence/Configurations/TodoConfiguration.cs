using Mediatr.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mediatr.Persistence;
internal sealed class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("Todos");
        builder.HasKey(t => t.Id);
        builder.Property(todo => todo.Title).IsRequired().HasMaxLength(100);
        builder.Property(todo => todo.Text).IsRequired().HasMaxLength(1024);
    }
}
