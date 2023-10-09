using SeatManagement1Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement1Console.Managers
{
    public class EntityManager<T> : IEntityManager<T> where T : class
    {
        private readonly APIService<T> _entityAPICall;
        public EntityManager(string apiEndPoint)
        {
            _entityAPICall = new APIService<T>(apiEndPoint);
        }
        public async Task<int> Add(T entity)
        {
            return (int)await _entityAPICall.Post(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _entityAPICall.GetAll<T>();
        }

        public async Task<List<T>> GetAllWithExtension(string extension)
        {
            return await _entityAPICall.GetAllWithExtension<T>(extension);
        }


        public async void AddMany(string extension)
        {
            _entityAPICall.PostWithExtension<T>(extension);
        }
    }
}
