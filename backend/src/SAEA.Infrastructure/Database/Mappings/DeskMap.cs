using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAEA.Domain.Models;

namespace SAEA.Infrastructure.Database.Mappings
{
    public sealed class DeskMap : IEntityTypeConfiguration<Desk>
    {
        public void Configure(EntityTypeBuilder<Desk> builder)
        {
            builder.ToTable("TB_DESKS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("ST_DESK_ID");

            builder.Property(x => x.Code)
                   .HasColumnName("ST_CODE")
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.Name)
                   .HasColumnName("ST_NAME")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Capacity)
                   .HasColumnName("NB_CAPACITY")
                   .IsRequired();

            builder.Property(x => x.RoomId)
                   .HasColumnName("ST_ROOM_ID")
                   .IsRequired();

            builder.HasOne(x => x.Room)
                   .WithMany(x => x.Desks)
                   .HasForeignKey(x => x.RoomId);

            builder.HasIndex(x => x.Code)
                   .HasDatabaseName("UN_DESK_CODE")
                   .IsUnique();
        }
    }
}
