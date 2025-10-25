namespace SAEA.Domain.Models
{
    public sealed class DateAvailability
    {
        public DateOnly Date { get; set; }
        public bool IsAvailable { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string? Reason { get; set; }

        public DateAvailability(DateOnly date, TimeOnly startTime, TimeOnly endTime)
        {
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
            IsAvailable = true;
        }

        public DateAvailability(DateOnly date, string reason)
        {
            Date = date;
            Reason = reason;
            IsAvailable = false;
        }
    }
}
