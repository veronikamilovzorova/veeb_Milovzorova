using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace veeb_Milovzorova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimitiividController : ControllerBase
    {
        
        [HttpGet("hello-world")]
        public string HelloWorld()
        {
            return "Hello world at " + DateTime.Now;
        }

        
        [HttpGet("hello-variable/{nimi}")]
        public string HelloVariable(string nimi)
        {
            return "Hello " + nimi;
        }

        
        [HttpGet("add/{nr1}/{nr2}")]
        public int AddNumbers(int nr1, int nr2)
        {
            return nr1 + nr2;
        }

        
        [HttpGet("multiply/{nr1}/{nr2}")]
        public int Multiply(int nr1, int nr2)
        {
            return nr1 * nr2;
        }

        
        [HttpGet("do-logs/{arv}")]
        public void DoLogs(int arv)
        {
            for (int i = 0; i < arv; i++)
            {
                Console.WriteLine("See on logi nr " + i);
            }
        }

        
        [HttpGet("random-number/{min}/{max}")]
        public ActionResult<int> GenerateRandomNumber(int min, int max)
        {
            if (min >= max)
            {
                return BadRequest("Min väärtus peab olema väiksem kui max väärtus.");
            }

            Random rand = new Random();
            int randomNumber = rand.Next(min, max + 1); // 
            return randomNumber;
        }

        
        [HttpGet("age/{birthYear}")]
        public ActionResult<string> CalculateAge(int birthYear)
        {
            int currentYear = DateTime.Now.Year;
            int age = currentYear - birthYear;

            
            bool hadBirthday = DateTime.Now >= new DateTime(currentYear, 1, 1).AddYears(age);

            if (!hadBirthday)
            {
                age--; 
            }

            return $"Oled {(hadBirthday ? age : age + 1)} aastat vana.";
        }
    }
}
