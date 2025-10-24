namespace SAEA.Domain.Models
{
    public sealed class Pavilion
    {
        public Guid Id { get; init; }
        public required string Code { get; set; }
        public required string Name { get; set; }

        public ICollection<Room>? Rooms { get; set; }
    }
}
