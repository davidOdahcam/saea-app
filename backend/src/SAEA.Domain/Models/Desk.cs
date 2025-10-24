namespace SAEA.Domain.Models
{
    public sealed class Desk
    {
        public Guid Id { get; init; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required int Capacity { get; set; }
        public required Guid RoomId { get; set; }

        public Room? Room { get; set; }
    }
}
