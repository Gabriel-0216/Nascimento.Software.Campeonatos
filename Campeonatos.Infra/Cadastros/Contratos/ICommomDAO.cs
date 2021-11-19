namespace Campeonatos.Infra.Cadastros.Contratos
{
    public interface ICommomDAO<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);


    }
}
