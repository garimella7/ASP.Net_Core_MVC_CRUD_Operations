﻿
namespace MVCEmployeeCRUD.Models.Domain
{
    public class Employee
    {
        public Guid ID { get; set; }
        public string Name { get; set; }        
        public string Email { get; set; }        
        public DateTime DOB { get; set; }     
        public long Salary { get; set; }  
        public string Department { get; set; }
    }
}
