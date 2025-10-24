using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAEA.Domain.Models;

namespace SAEA.Infrastructure.Database.Mappings
{
    public sealed class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("TB_ROOMS");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("ST_ROOM_ID");

            builder.Property(x => x.PavilionId)
                   .HasColumnName("ST_PAVILION_ID")
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasColumnName("ST_NAME")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Code)
                   .HasColumnName("ST_CODE")
                   .IsRequired()
                   .HasMaxLength(30);

            builder.Property(x => x.Capacity)
                   .HasColumnName("NB_CAPACITY")
                   .IsRequired();
            
            builder.HasOne(x => x.Pavilion)
                   .WithMany(x => x.Rooms)
                   .HasForeignKey(x => x.PavilionId);

            builder.HasMany(x => x.Desks)
                   .WithOne(x => x.Room)
                   .HasForeignKey(x => x.RoomId);

            builder.HasIndex(x => x.Code)
                   .HasDatabaseName("UN_ROOM_CODE")
                   .IsUnique();
        }
    }
}
