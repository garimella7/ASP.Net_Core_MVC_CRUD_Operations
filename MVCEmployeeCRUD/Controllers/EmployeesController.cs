using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEmployeeCRUD.Data;
using MVCEmployeeCRUD.Models;
using MVCEmployeeCRUD.Models.Domain;

namespace MVCEmployeeCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDBContext _dbContext;
        public EmployeesController(EmployeeDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeViewModel addEmployee)
        {
            var employee = new Employee()
            {
                ID = Guid.NewGuid(),
                Name = addEmployee.Name,
                Salary = addEmployee.Salary,
                DOB = addEmployee.DOB,
                Department = addEmployee.Department,
                Email = addEmployee.Email
            };

            await _dbContext.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Create");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.ID == id);

            if (employee != null)
            {
                var viewModel = new EditEmployeeViewModel()
                {
                    ID = employee.ID,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    DOB = employee.DOB,
                    Department = employee.Department,
                    Email = employee.Email
                };

                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.ID == id);

            if (employee != null)
            {
                var viewModel = new EditEmployeeViewModel()
                {
                    ID = employee.ID,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    DOB = employee.DOB,
                    Department = employee.Department,
                    Email = employee.Email
                };

                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeViewModel editEmployee)
        {
            var employee = await _dbContext.Employees.FindAsync(editEmployee.ID);

            if(employee != null)
            {
                employee.Name = editEmployee.Name;
                employee.Salary = editEmployee.Salary;
                employee.Email = editEmployee.Email;
                employee.Department = editEmployee.Department;
                employee.DOB = editEmployee.DOB;

                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);

            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
