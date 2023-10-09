using SeatManagement1.Models;
using SeatManagement1.Models.DTO;

namespace SeatManagement1.Services.Interfaces
{
    public interface ICityService
    {
        void DeleteCityById(int id);
        void EditCity(City city);
        City GetCityById(int id);
        int AddCity(CityDTO city);
        City[] GetAllCities();
    }
}
