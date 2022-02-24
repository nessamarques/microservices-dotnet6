using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }
    

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Invalid input");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sub.ToString());
        }

        return BadRequest("Invalid input");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var multiplication = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(multiplication.ToString());
        }

        return BadRequest("Invalid input");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {
        try
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
        }
        catch (DivideByZeroException)
        {
            throw new Exception("Attempted to divide by zero.");
        }

        return BadRequest("Invalid input");
    }

    [HttpGet("mean/{firstNumber}/{secondNumber}")]
    public IActionResult Mean(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var mean = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

            return Ok(mean.ToString());
        }

        return BadRequest("Invalid input");
    }

    [HttpGet("square-root/{number}")]
    public IActionResult SquareRoot(string number)
    {
        if (IsNumeric(number))
        {
            var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
            return Ok(squareRoot.ToString());
        }

        return BadRequest("Invalid input");
    }


    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, 
                                        System.Globalization.NumberStyles.Any, 
                                        System.Globalization.NumberFormatInfo.InvariantInfo, 
                                        out number);

        return isNumber;
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;

        if (decimal.TryParse(strNumber, out decimalValue))
            return decimalValue;

        return 0;
    }


}
