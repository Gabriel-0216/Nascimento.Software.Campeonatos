using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campeonatos.Application.Servicos.Contratos
{
    public interface ICommomService<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);

    }
}
