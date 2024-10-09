using System.ComponentModel.DataAnnotations;

namespace project12.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; } // Primary Key
        public string DepartmentName { get; set; }
        public string Location { get; set; }

        //Foregin Key
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }

        // Navigation property for employees in the department

        public ICollection<Employee> Employees { get; set; }

    }
}
