namespace Transport.Infrastructure.DatabaseManagement
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
