using Microsoft.EntityFrameworkCore;
using SeatManagement1.Models;

namespace SeatManagement1
{
    public class SeatContext : DbContext
    {
        public SeatContext(DbContextOptions<SeatContext> options) : base(options)
        {
        }





        public DbSet<Asset> Assets { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<CabinRoom> CabinRooms { get; set; }


        public DbSet<City> Cities { get; set; }




        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Facility> Facilities { get; set; }




        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<MeetingRoomAssets> MeetingRoomAssetAllocations { get; set; }

        public DbSet<Seat> Seats { get; set; }




    }
}


