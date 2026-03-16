using Microsoft.AspNetCore.Mvc;

namespace Day50WebApi_Example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : Controller
    {
        public static List<string> Data { get; set; } =new List<string>
        {
            "Data Item1",
            "Data Item2",
            "Data Item3"
        };
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Data);
        }
        [HttpPost]
        public IActionResult Post(string newItem)
        {
            Data.Add(newItem);
            return Ok(new {Message = "Data Added",newItem});
        }

    }
}
