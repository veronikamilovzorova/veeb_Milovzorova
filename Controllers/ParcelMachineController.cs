using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace veeb_Milovzorova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelMachineController : ControllerBase
    {

        [HttpGet]
        public string GetParcelMachines()
        {
            return "PAKIAUTOMAADID";
        }
    }
}