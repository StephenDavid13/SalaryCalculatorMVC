using System.ComponentModel.DataAnnotations;

namespace SalaryCalculatorMVC.Models
{
    public class CalculationResultModel
    {
        [DataType(DataType.Currency)]
        [Display(Name = "Package Limit")]
        public decimal PackageLimit { get; set; }
        
        public string Message { get; set; } = string.Empty;
        
        public EmployeeModel Employee { get; set; }
    }
} 