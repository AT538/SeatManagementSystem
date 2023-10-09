using SeatManagement1.CustomExceptions;
using SeatManagement1.Models;

namespace SeatManagement1.GenericRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SeatContext _assetContext;
        public Repository(SeatContext assetContext)
        {
            _assetContext = assetContext;
        }
        public void Add(T entity)
        {
            try
            {
                _assetContext.Add(entity);
                _assetContext.SaveChanges();
            }
            catch (Exception ex) { throw new CustomException("Error while adding the current entity", ex); }
        }
        public void AddMany(List<T> entity)
        {
            try
            {
                _assetContext.Set<T>().AddRange(entity);
                _assetContext.SaveChanges();
            }
            catch (Exception ex) { throw new CustomException("Error while adding the current list of entities", ex); }
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _assetContext.Set<T>().Remove(item);
                _assetContext.SaveChanges();
            }
            else
            { throw new Exception("Item doesn't exist"); }
        }

        public T[] GetAll()
        {
            try
            {
                return _assetContext.Set<T>().ToArray();
            }
            catch (Exception ex) { throw new CustomException("Nothing in DB", ex); }
        }

        public T GetById(int id)
        {
            try
            {
                return _assetContext.Set<T>().Find(id);
            }
            catch (Exception ex) { throw new CustomException("The entity of the given id doesn't exist"); }
        }

        public void Update(T entity)
        {
            try
            {
                _assetContext.Set<T>().Update(entity);
                _assetContext.SaveChanges();
            }
            catch (Exception ex) { throw new CustomException("Unable to update"); }
        }




    }
}
