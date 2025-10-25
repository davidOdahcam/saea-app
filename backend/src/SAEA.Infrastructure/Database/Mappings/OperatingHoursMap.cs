using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAEA.Domain.Models;

namespace SAEA.Infrastructure.Database.Mappings
{
    public sealed class OperatingHoursMap : IEntityTypeConfiguration<OperatingHour>
    {
        public void Configure(EntityTypeBuilder<OperatingHour> builder)
        {
            builder.ToTable("TB_OPERATING_HOURS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("ST_OPERATING_HOURS_ID");

            builder.Property(x => x.ResourceType)
                   .HasColumnName("NB_RESOURCE_TYPE")
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(x => x.ResourceId)
                   .HasColumnName("ST_RESOURCE_ID")
                   .IsRequired();

            builder.Property(x => x.DayOfWeek)
                   .HasColumnName("NB_DAY_OF_WEEK")
                   .IsRequired()
                   .HasConversion<int>();

            builder.Property(x => x.StartTime)
                   .HasColumnName("DT_START_TIME")
                   .IsRequired()
                   .HasConversion(
                        time => time.ToTimeSpan(),
                        timeSpan => TimeOnly.FromTimeSpan(timeSpan)
                    );

            builder.Property(x => x.EndTime)
                   .HasColumnName("DT_END_TIME")
                   .IsRequired()
                   .HasConversion(
                        time => time.ToTimeSpan(),
                        timeSpan => TimeOnly.FromTimeSpan(timeSpan)
                   );

            builder.HasIndex(x => new { x.ResourceType, x.ResourceId })
                   .HasDatabaseName("IX_OPERATING_HOURS_RESOURCE");

            builder.HasIndex(x => x.DayOfWeek)
                   .HasDatabaseName("IX_OPERATING_HOURS_DAY");
        }
    }
}
