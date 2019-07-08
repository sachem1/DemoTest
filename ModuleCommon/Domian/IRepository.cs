namespace ModuleCommon.Domian
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetFirst();
        TEntity GetById(long id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(long id);
    }
}
