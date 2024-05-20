using EmployeeMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMVCApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee


        private readonly List<Employee> employees = new List<Employee>();


        // API endpoint to store employee details

        [HttpPost]

        public IActionResult StoreEmployeeDetails([FromBody] Employee employee)

        {

            if (!ModelState.IsValid)

            {

                return BadRequest(ModelState);

            }


            employees.Add(employee);

            return Ok();

        }

        private IActionResult Ok()
        {
            throw new NotImplementedException();
        }

        private IActionResult BadRequest(ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }


        // API endpoint to return employees' tax deduction for the current financial year

        [HttpGet]

        public IActionResult GetTaxDeductions()

        {

            var taxDeductions = employees.Select(e => new

            {

                EmployeeCode = e.EmployeeID,

                FirstName = e.FirstName,

                LastName = e.LastName,

                YearlySalary = CalculateYearlySalary(e),

                TaxAmount = CalculateTax(e),

                CessAmount = CalculateCess(e)

            });

            return Ok(taxDeductions);

        }

        private IActionResult Ok(IEnumerable<object> taxDeductions)
        {
            throw new NotImplementedException();
        }

        private decimal CalculateYearlySalary(Employee e)

        {

            var totalSalary = e.Salary * GetNumberOfMonths(e.DOJ);

            return totalSalary;

        }


        private decimal CalculateTax(Employee e)

        {

            var yearlySalary = CalculateYearlySalary(e);

            if (yearlySalary <= 250000) return 0;

            else if (yearlySalary <= 500000) return (yearlySalary - 250000) * 0.05m;

            else if (yearlySalary <= 1000000) return (yearlySalary - 500000) * 0.10m + 12500;

            else return (yearlySalary - 1000000) * 0.20m + 37500;

        }

        private decimal CalculateCess(Employee e)

        {

            var yearlySalary = CalculateYearlySalary(e);

            if (yearlySalary > 2500000) return (yearlySalary - 2500000) * 0.02m;

            else return 0;
        }

        private int GetNumberOfMonths(DateTime doj)

        {

            var months = (DateTime.Now.Year - doj.Year) * 12 + DateTime.Now.Month - doj.Month;

            if (DateTime.Now.Day >= doj.Day) return months;

            else return months - 1;

        }


    }
}