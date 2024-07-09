using System.ComponentModel.DataAnnotations;

namespace MVCEmployeeCRUD.Models
{
    public class AddEmployeeViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public long Salary { get; set; }

        [Required]
        public string Department { get; set; }
    }
}
