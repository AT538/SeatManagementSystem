using SeatManagement1.GenericRepository;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Services
{
    public class CityService:ICityService
    {
        private readonly IRepository<City> _cityRepository;

        public CityService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public City[] GetAllCities()
        {
            return _cityRepository.GetAll();
        }

        public int AddCity(CityDTO city)
        {
            City c = new City { CityName = city.CityName, CityAbbreviation = city.CityAbbreviation };
            _cityRepository.Add(c);
            return c.CityId;
        }


        public City GetCityById(int id)
        {
            return _cityRepository.GetById(id);
        }


        public void EditCity(City city)
        {
            var originalCity = _cityRepository.GetById(city.CityId);
            if (originalCity == null) { throw new Exception(" City not found"); }

            originalCity.CityName = city.CityName;
            originalCity.CityAbbreviation = city.CityAbbreviation;

            _cityRepository.Update(originalCity);
        }


        public void DeleteCityById(int id)
        {
            _cityRepository.DeleteById(id);
        }
    }
}
