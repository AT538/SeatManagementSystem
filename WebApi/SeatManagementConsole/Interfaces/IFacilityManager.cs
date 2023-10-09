using SeatManagement1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement1Console.Interfaces
{
    public interface IFacilityManager
    {
        Task<int> OnBoardFacility(Facility facility);
        Task<List<Facility>> GetAllFacilities();
    }
}
