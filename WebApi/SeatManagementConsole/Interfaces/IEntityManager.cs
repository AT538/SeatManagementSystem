using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement1Console.Interfaces
{
    public interface IEntityManager<T>
    {
        Task<int> Add(T entity);
        Task<List<T>> GetAll();
        Task<List<T>> GetAllWithExtension(string extension);
        void AddMany(string extension);



    }
}
