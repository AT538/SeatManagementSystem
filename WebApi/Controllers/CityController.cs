using Microsoft.AspNetCore.Mvc;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {



        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]

        public IActionResult GetCities([FromQuery] int? id)
        {
            if (id.HasValue)
            {
                var city = _cityService.GetCityById(id.Value);
                if (city == null)
                {
                    return NotFound();
                }
                return Ok(city);
            }
            else
            {
                var cities = _cityService.GetAllCities();
                return Ok(cities);
            }
        }


        [HttpPost]

        public IActionResult Add(CityDTO city)
        {
            int id = _cityService.AddCity(city);
            return Ok(id);
        }




        [HttpPut]
        public IActionResult Edit(City city)
        {
            _cityService.EditCity(city);
            return Ok();
        }

        [HttpDelete("{id}")]
            public IActionResult DeleteById(int id)
            {
                _cityService.DeleteCityById(id);
                return Ok();
            }
        }
    }

