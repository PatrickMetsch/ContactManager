using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter a rating")]
        public string Email { get; set; }

        public string Organization { get; set; }

        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Please enter a category")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        

        public string Slug => FirstName?.ToLower() + '-' + LastName?.ToLower();
    }
}
