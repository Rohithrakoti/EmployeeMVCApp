using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeMVCApp.Models
{
    public class Employee
    {
        [Required]

        public int EmployeeID { get; set; }


        [Required]

        public string FirstName { get; set; }


        [Required]

        public string LastName { get; set; }


        [Required]

        [EmailAddress]

        public string Email { get; set; }


        [Required]

        [Phone]

        public string PhoneNumber { get; set; }


        [Required]

        public DateTime DOJ { get; set; }


        [Required]

        [Range(1, int.MaxValue)]

        public decimal Salary { get; set; }


    }
}