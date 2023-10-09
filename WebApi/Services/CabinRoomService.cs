using SeatManagement1.CustomExceptions;
using SeatManagement1.GenericRepository;
using SeatManagement1.Models;
using SeatManagement1.Models.DTO;
using SeatManagement1.Services.Interfaces;

namespace SeatManagement1.Services
{
    public class CabinRoomService : ICabinRoomService
    {
        private readonly IRepository<CabinRoom> _cabinRoomRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public CabinRoomService(IRepository<CabinRoom> cabinRoomRepository, IRepository<Employee> employeeRepository, IRepository<Facility> facilityRepository)
        {
            _cabinRoomRepository = cabinRoomRepository;
            _employeeRepository = employeeRepository;
            _facilityRepository = facilityRepository;
        }

        public CabinRoom[] GetAllCabin()
        {
            return _cabinRoomRepository.GetAll();
        }

        public int AddCabinRoom(CabinRoomDTO cabinRoomDTO)
        {
            CabinRoom cabinRoom = new CabinRoom
            {
               FacilityId=cabinRoomDTO.FacilityId
               
            };
            _cabinRoomRepository.Add(cabinRoom);
            return cabinRoom.CabinRoomId;
        }

        public CabinRoom GetCabinRoomById(int id)
        {
            return _cabinRoomRepository.GetById(id);
        }

        public void EditCabin(CabinRoom cabinRoom)
        {
            var originalCabinRoom = _cabinRoomRepository.GetById(cabinRoom.CabinRoomId);
            if (originalCabinRoom == null)
            {
                throw new Exception("CabinRoom not found");
            }

          

            _cabinRoomRepository.Update(originalCabinRoom);
        }

        public void DeleteCabinRoom(int id)
        {
            _cabinRoomRepository.DeleteById(id);
        }
        public void AddBulkCabins(int TotalCabins, int FacilityId)
        {


            List<CabinRoom> emptyCabins = new List<CabinRoom>();
            if (_facilityRepository.GetById(FacilityId) == null)
            {
                throw new CustomException("Facility doesn't exist");
            }
         
            for (int i=0; i < TotalCabins ; i++)
            {

                CabinRoom emptyCabin = new CabinRoom
                {
                    FacilityId = FacilityId,

                };
                emptyCabins.Add(emptyCabin);
            }

           _cabinRoomRepository.AddMany(emptyCabins);

        }

        public void AllocateCabin(int CabinRoomId, int EmployeeId)
        {
            Employee employee = _employeeRepository.GetById(EmployeeId);
          
            CabinRoom cabin =_cabinRoomRepository.GetById(CabinRoomId);
            if (employee.IsAllocated == false && cabin.EmployeeId == null)
            {
                employee.IsAllocated = true;
                cabin.EmployeeId = EmployeeId;
                _employeeRepository.Update(employee);
             _cabinRoomRepository.Update(cabin);



            }
            else
            {
                if (employee.IsAllocated == true) { throw new CustomException("Employee already has a seat or cabin"); }
                if (cabin.EmployeeId == 1) { throw new CustomException("Cabin of this id is already occupied"); }
            }
        }
        public void DeAllocateCabin(int CabinRoomId)
        {

            CabinRoom cabin = _cabinRoomRepository.GetById(CabinRoomId);

            Employee employee = _employeeRepository.GetById((int)cabin.EmployeeId);
            cabin.EmployeeId = null;
            employee.IsAllocated = false;
            _employeeRepository.Update(employee);
            _cabinRoomRepository.Update(cabin);




        }



    }

}
