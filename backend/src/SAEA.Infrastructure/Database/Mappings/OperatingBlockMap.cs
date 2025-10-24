using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAEA.Domain.Models;

namespace SAEA.Infrastructure.Database.Mappings
{
    public sealed class OperatingBlockMap : IEntityTypeConfiguration<OperatingBlock>
    {
        public void Configure(EntityTypeBuilder<OperatingBlock> builder)
        {
            builder.ToTable("TB_OPERATING_BLOCKS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("ST_OPERATING_BLOCK_ID");

            builder.Property(x => x.ResourceType)
                   .HasColumnName("NB_RESOURCE_TYPE")
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(x => x.ResourceId)
                   .HasColumnName("ST_RESOURCE_ID")
                   .IsRequired();

            builder.Property(x => x.StartDateTime)
                   .HasColumnName("DT_START_DATE_TIME")
                   .IsRequired();

            builder.Property(x => x.EndDateTime)
                   .HasColumnName("DT_END_DATE_TIME")
                   .IsRequired();

            builder.Property(x => x.Reason)
                   .HasColumnName("ST_REASON")
                   .HasMaxLength(500)
                   .IsRequired(false);

            builder.HasIndex(x => new { x.ResourceType, x.ResourceId })
                   .HasDatabaseName("IX_OPERATING_BLOCKS_RESOURCE");

            builder.HasIndex(x => x.StartDateTime)
                   .HasDatabaseName("IX_OPERATING_BLOCKS_START");

            builder.HasIndex(x => x.EndDateTime)
                   .HasDatabaseName("IX_OPERATING_BLOCKS_END");

            builder.HasIndex(x => new { x.ResourceType, x.ResourceId, x.StartDateTime, x.EndDateTime })
                   .HasDatabaseName("IX_OPERATING_BLOCKS_RESOURCE_PERIOD");
        }
    }
}
