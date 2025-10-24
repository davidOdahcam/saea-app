namespace SAEA.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPavilionRepository Pavilions { get; }

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
