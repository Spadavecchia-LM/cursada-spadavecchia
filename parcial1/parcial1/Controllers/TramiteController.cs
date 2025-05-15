using Microsoft.AspNetCore.Mvc;
using parcial1.Interfaces;

namespace parcial1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TramiteController(ITramiteRepository tramiteRepository) : ControllerBase
    {

    }
}
