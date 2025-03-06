using SalaryCalculatorMVC.Models;

namespace SalaryCalculatorMVC.Services
{
    public class CalculatorService
    {
        public CalculationResultModel Calculate(EmployeeModel employee)
        {
            var result = new CalculationResultModel
            {
                Employee = employee,
                Message = "Calculation successful"
            };

            // Basic validation
            if (employee.Salary <= 0)
            {
                result.Message = "Salary must be greater than zero.";
                return result;
            }

            // Part-time validation
            if (employee.EmploymentType == EmploymentType.PartTime && 
                (!employee.HoursPerWeek.HasValue || employee.HoursPerWeek < 0 || employee.HoursPerWeek > 38))
            {
                result.Message = "Part-time employees must specify valid hours per week (0-38)";
                return result;
            }

            // Calculate based on company type
            decimal packageLimit = 0;
            
            switch (employee.CompanyType)
            {
                case CompanyType.Corporate:
                    // Corporate: 1% of salary, 0 for casual employees
                    if (employee.EmploymentType != EmploymentType.Casual)
                    {
                        packageLimit = employee.Salary * 0.01m;
                        
                        // Adjust for part-time
                        if (employee.EmploymentType == EmploymentType.PartTime && employee.HoursPerWeek.HasValue)
                        {
                            packageLimit *= employee.HoursPerWeek.Value / 38m;
                        }
                    }
                    break;
                    
                case CompanyType.Hospital:
                    // Hospital: $10,000 or 20% of salary (whichever is greater), plus education bonus
                    packageLimit = Math.Max(10000, employee.Salary * 0.2m);
                    
                    if (employee.IsEducated)
                    {
                        packageLimit += 5000;
                    }
                    break;
                    
                case CompanyType.PBI:
                    // PBI: 30% of salary for full-time, 24% for part-time, 10% for casual
                    if (employee.EmploymentType == EmploymentType.FullTime)
                    {
                        packageLimit = employee.Salary * 0.3m;
                    }
                    else if (employee.EmploymentType == EmploymentType.PartTime)
                    {
                        packageLimit = employee.Salary * 0.24m;
                    }
                    else // Casual
                    {
                        packageLimit = employee.Salary * 0.1m;
                    }
                    
                    // Education bonus
                    if (employee.IsEducated)
                    {
                        packageLimit += 2000;
                    }
                    break;
            }
            
            result.PackageLimit = Math.Round(packageLimit, 2);
            return result;
        }
    }
} 