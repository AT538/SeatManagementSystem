using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement1Console.Interfaces
{
    public interface IAllocationManager<T>
    {
        public void Allocate(int entityId, int employeeId);
        public void DeAllocate(int entityId);
    }
}
