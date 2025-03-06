using Microsoft.AspNetCore.Mvc;
using SalaryCalculatorMVC.Models;
using SalaryCalculatorMVC.Services;

namespace SalaryCalculatorMVC.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorController(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public IActionResult Index()
        {
            return View(new EmployeeModel());
        }

        [HttpPost]
        public IActionResult Calculate(EmployeeModel employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", employee);
            }

            var result = _calculatorService.Calculate(employee);
            return View("Result", result);
        }
    }
} 