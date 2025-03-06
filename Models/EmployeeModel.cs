using System.ComponentModel.DataAnnotations;

namespace SalaryCalculatorMVC.Models
{
    public enum CompanyType
    {
        Corporate,
        Hospital,
        PBI
    }

    public enum EmploymentType
    {
        FullTime,
        PartTime,
        Casual
    }

    public class EmployeeModel
    {
        [Required(ErrorMessage = "Please select a company type")]
        [Display(Name = "Company Type")]
        public CompanyType CompanyType { get; set; }

        [Required(ErrorMessage = "Please select an employment type")]
        [Display(Name = "Employment Type")]
        public EmploymentType EmploymentType { get; set; }

        [Required(ErrorMessage = "Please enter your annual salary")]
        [Range(1, 1000000, ErrorMessage = "Salary must be between $1 and $1,000,000")]
        [DataType(DataType.Currency)]
        [Display(Name = "Annual Salary")]
        public decimal Salary { get; set; }

        [Display(Name = "Do you have a bachelor's degree or higher?")]
        public bool IsEducated { get; set; }

        [Range(0, 38, ErrorMessage = "Hours per week must be between 0 and 38")]
        [Display(Name = "Hours Per Week")]
        public decimal? HoursPerWeek { get; set; }
    }
} 