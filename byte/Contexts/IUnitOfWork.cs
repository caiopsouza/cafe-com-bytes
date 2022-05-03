namespace Take.Contexts
{
    public interface IUnitOfWork
    {
        public ValueTask SaveChangesAsync(CancellationToken cancellationToken);
    }
}
