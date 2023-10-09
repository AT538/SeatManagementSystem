using SeatManagement1.Models;
using SeatManagement1.CustomExceptions;
using SeatManagement1.Models.DTO;
using SeatManagement1.GenericRepository;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using SeatManagement1.Services.Interfaces;


namespace SeatManagement1.Services
{
    public class SeatService : ISeat
    {
        private readonly IRepository<Seat> _seatRepository;
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public SeatService(IRepository<Seat> seatRepository, IRepository<Facility> facilityRepository, IRepository<Employee> employeeRepository)
        {
            _seatRepository = seatRepository;
            _facilityRepository = facilityRepository;
            _employeeRepository = employeeRepository;
        }

        public Seat[] GetAllSeats()
        {
            return _seatRepository.GetAll();
        }

        public int AddSeat(SeatDTO seatdto)
        {
           Seat seat = new Seat { FacilityId= seatdto.FacilityId };
            _seatRepository.Add(seat);
            return seat.SeatId;
        }


        public Seat GetSeatById(int id)
        {
            
            return _seatRepository.GetById(id);
        }


        public void EditSeat(Seat seat)
        {
            var originalSeat = _seatRepository.GetById(seat.SeatId);
            if (originalSeat == null) { throw new CustomException(" Seat not found"); }

            originalSeat.EmployeeId = seat.EmployeeId;
            

            _seatRepository.Update(originalSeat);
        }


        public void DeleteSeatById(int id)
        {
            _seatRepository.DeleteById(id);
        }

        public void AddBulkSeats(int TotalSeats, int FacilityId)
        {
            if (TotalSeats == null)
            {
                Seat emptyseat = new Seat { FacilityId=FacilityId};
                _seatRepository.Add(emptyseat);
            }
            
                List<Seat> emptySeats = new List<Seat>();
                if (_facilityRepository.GetById(FacilityId) == null)
                {
                    throw new  CustomException("Facility doesn't exist");
                }
             
                for (int i = 0; i < TotalSeats ; i++)
                {

                    Seat emptySeat = new Seat
                    {
                        FacilityId = FacilityId,
                        
                    };
                    emptySeats.Add(emptySeat);
                }

                _seatRepository.AddMany(emptySeats);

            }

        public void AllocateSeat(int SeatId, int EmployeeId)
        {
            Employee employee = _employeeRepository.GetById(EmployeeId);
            Console.WriteLine(employee);
            Seat seat = _seatRepository.GetById(SeatId);
            Facility facility=_facilityRepository.GetById(seat.FacilityId);
            if (employee.IsAllocated == false && seat.EmployeeId == null)
            {
                employee.IsAllocated = true;
                seat.EmployeeId = EmployeeId;
               
                _employeeRepository.Update(employee);
                _seatRepository.Update(seat);



            }
            else
            {
                if (employee.IsAllocated == true) { throw new CustomException("Employee already has a seat or cabin"); }
                if(seat.EmployeeId==1) { throw new CustomException("Seat of this id is already occupied"); }
            }
        }
        public void DeAllocateSeat(int SeatId) {
            
            Seat seat = _seatRepository.GetById(SeatId);
           
            Employee employee = _employeeRepository.GetById((int)seat.EmployeeId);
            seat.EmployeeId = null;
            employee.IsAllocated = false;
            
           _employeeRepository.Update(employee);
            _seatRepository.Update(seat);




        }

        public IEnumerable GetFreeSeats(List<int>? cityIds, List<int>? buildingIds, List<int>? facilityIds,List<int>?Floor, int? page, int? pageSize)
        {
            var filteredSeats = _seatRepository.GetAll()
                .Where(x => x.EmployeeId == null).AsQueryable();
            var allfacilties = _facilityRepository.GetAll().AsQueryable();
          

            if ( cityIds.Any())
            {
                filteredSeats = filteredSeats.Include(x => x.Facility)
                                             .Where(x => cityIds.Contains(x.Facility.CityId));
            }

            if ( buildingIds.Any())
            {
                filteredSeats = filteredSeats.Include(x => x.Facility)
                                            .Where(x => buildingIds.Contains(x.Facility.BuildingId));
            }
            if (Floor.Any())
            {
                filteredSeats = filteredSeats.Include(x => x.Facility)
                                            .Where(x => Floor.Contains(x.Facility.FloorNumber));
            }



            if ( facilityIds.Any())
            {
                filteredSeats = filteredSeats.Include(x => x.Facility)
                                            .Where(x => facilityIds.Contains(x.Facility.FacilityId));
            }

            if (page != null && pageSize != null)
            {
                int skip = (int)((page - 1) * pageSize);





                return filteredSeats.Skip(skip).Take((int)pageSize).ToList();
            }
            else { return filteredSeats; }
        
        }









    }

}
    

