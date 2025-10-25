namespace SAEA.DataTransfer.Responses
{
    public sealed record DateAvailabilityResponse
    {
        public required DateOnly Date { get; init; }
        public required TimeOnly? StartTime { get; init; }
        public required TimeOnly? EndTime { get; init; }
        public required bool IsAvailable { get; init; }
        public required string? Reason { get; init; }
    }
}
