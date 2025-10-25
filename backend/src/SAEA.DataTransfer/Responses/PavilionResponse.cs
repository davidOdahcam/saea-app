namespace SAEA.DataTransfer.Responses
{
    public sealed record PavilionResponse
    {
        public Guid Id { get; init; }
        public required string Code { get; init; }
        public required string Name { get; init; }
    }
}
