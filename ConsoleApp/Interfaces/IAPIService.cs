using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement1Console.Interfaces
{
    public interface IAPIService<T>
    {
        Task<int?> Post<T>(T newObject);
        void PostWithExtension<T>(string extension);

        Task<List<T>> GetAll<T>();
        Task<List<T>> GetAllWithExtension<T>(string extension);

        Task<T> GetById<T>(int id);
        void PutWithExtension<T>(string extension);
        void PatchWithExtension<T>(string extension);
    }
}
