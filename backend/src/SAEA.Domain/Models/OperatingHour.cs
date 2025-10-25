using SAEA.Domain.Enums;

namespace SAEA.Domain.Models
{
    public sealed class OperatingHour
    {
        public Guid Id { get; init; }
        public EResourceType ResourceType { get; set; }
        public Guid ResourceId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
