using System.ComponentModel.DataAnnotations;

namespace project12.Models
{
    public class Manager
    {
        [Key]
        public int ManagerId { get; set; } // Primary Key
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Navigation property for the department (One-to-One relationship)
        public Department Department { get; set; }


    }
}
