namespace Transport.Core.Modules
{
    internal interface IEntityCofigurationRegistration
    {
        void RegisterEntity<T>() where T : class;
    }
}
