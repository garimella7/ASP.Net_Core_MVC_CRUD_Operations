using Microsoft.EntityFrameworkCore;
using MVCEmployeeCRUD.Models.Domain;
using MVCEmployeeCRUD.Models;

namespace MVCEmployeeCRUD.Data
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<MVCEmployeeCRUD.Models.EditEmployeeViewModel> EditEmployeeViewModel { get; set; } = default!;
    }
}
