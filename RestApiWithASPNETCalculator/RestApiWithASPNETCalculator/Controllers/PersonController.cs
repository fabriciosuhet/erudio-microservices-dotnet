using Microsoft.AspNetCore.Mvc;

namespace RestApiWithASPNETCalculator.Controllers
{
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
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Input inválido");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sub.ToString());
            }
            return BadRequest("Inválid input");
        }

        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult GetMulti(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var multi = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(multi.ToString());
            }
            return BadRequest("Inválid input");
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(div.ToString());
            }
            return BadRequest("Inválid input");
        }

        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult GetMedia(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var media = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
                return Ok(media.ToString());
            }
            return BadRequest("Inválid input");
        }

        [HttpGet("sqrt/{firstNumber}")]
        public IActionResult GetSqrt(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var number = ConvertToDecimal(firstNumber);
                if (number >= 0)
                {
                    var sqrt = Math.Sqrt((double)number);
                    return Ok(sqrt.ToString());
                }
                else
                {
                    return BadRequest("Número negativo");
                }
            }
            return BadRequest("Invalid input");
        }

        private bool IsNumeric(string strNumber)
        {
            double number;
            bool IsNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out number);
            return IsNumber;
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }
    }
}
