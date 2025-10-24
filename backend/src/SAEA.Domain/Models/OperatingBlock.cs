using SAEA.Domain.Enums;

namespace SAEA.Domain.Models
{
    public sealed class OperatingBlock
    {
        public Guid Id { get; init; }
        public EResourceType ResourceType { get; set; }
        public Guid ResourceId { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
        public string? Reason { get; set; }
    }
}
