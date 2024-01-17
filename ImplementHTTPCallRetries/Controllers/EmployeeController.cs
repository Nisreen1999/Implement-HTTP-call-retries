using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImplementHTTPCallRetries.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // create constrocor and inject test class
        private readonly Test _test;
        public EmployeeController(Test test)
        {
            _test = test;
        }
        //create function to call path from another project
        [HttpGet]
        [Route("GetEmployee")]
        public string GetEmployee()
        {
            var result = _test.GetWeather();
            //write if statement to check if result is true or false
            if (result.Status .ToString()== "Faulted")
            {
                return "Connection failed";
            }
            else
            {
                return "Connection succeeded";
            }
        }
    }
}
