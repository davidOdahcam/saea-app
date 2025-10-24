namespace SAEA.Domain.Models
{
    public sealed class Room
    {
        public Guid Id { get; init; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required int Capacity { get; set; }
        public required Guid PavilionId { get; set; }

        public Pavilion? Pavilion { get; set; }
        public ICollection<Desk> Desks { get; set; } = [];
    }
}
