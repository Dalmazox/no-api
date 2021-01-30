using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using No.API.Entities;

namespace No.API.Context.Map
{
    public class LetterMap : IEntityTypeConfiguration<Letter>
    {
        public void Configure(EntityTypeBuilder<Letter> builder)
        {
            builder.Property(x => x.Content).HasColumnType("TEXT").IsRequired();
            builder.Property(x => x.WritedAt).HasColumnType("DATE").IsRequired();

            builder.HasIndex(x => x.WritedAt).IsUnique();
        }
    }
}