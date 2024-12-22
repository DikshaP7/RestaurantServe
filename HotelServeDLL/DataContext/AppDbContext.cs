using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelServeDLL.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelServeDLL.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> x) : base(x) { }

        public DbSet<MenuItem> tblMenuItems { get; set; }
        public DbSet<Orders> tblOrders { get; set; }
        public DbSet<TableTap> tblTableTap { get; set; }
    }
}
