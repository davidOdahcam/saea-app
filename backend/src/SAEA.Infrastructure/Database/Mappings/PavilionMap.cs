using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAEA.Domain.Models;

namespace SAEA.Infrastructure.Database.Mappings
{
    public class PavilionMap : IEntityTypeConfiguration<Pavilion>
    {
        public void Configure(EntityTypeBuilder<Pavilion> builder)
        {
            builder.ToTable("TB_PAVILIONS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("ST_PAVILION_ID");

            builder.Property(x => x.Code)
                   .HasColumnName("ST_CODE")
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.Name)
                   .HasColumnName("ST_NAME")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(x => x.Rooms)
                   .WithOne(x => x.Pavilion)
                   .HasForeignKey(x => x.PavilionId);

            builder.HasIndex(x => x.Code)
                   .HasDatabaseName("UN_PAVILION_CODE")
                   .IsUnique();
        }
    }
}
