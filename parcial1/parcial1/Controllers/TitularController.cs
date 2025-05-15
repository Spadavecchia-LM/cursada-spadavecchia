using Microsoft.AspNetCore.Mvc;
using parcial1.EF;
using parcial1.Interfaces;
using parcial1.Models;
using System.Collections.Generic;
using System.Net;

namespace parcial1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitularController(ITitularRepository titularRepository) : ControllerBase
    {
        //Registrar al titular del trámite (la persona destinataria del DNI o Pasaporte) Si el titular ya existe no nos importa, esto es un MVP. Aunque sería ideal que no se repitieran....
        [HttpPost("createTitular")]
        public async Task<bool> CreateTitular([FromBody] TitularModel titular)
        {
            if (titular == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(titular.Nombre) || string.IsNullOrEmpty(titular.Apellido) || string.IsNullOrEmpty(titular.Dni))
            {
                return false;
            }
            return await titularRepository.CreateTitular(titular);
        }
        //Para una parte de administración, será necesario consultar los titulares cuyo DNI comiencen con 92;93;94 ó 95 millones para listar a los extranjeros.
        [HttpGet("getForeignTitulares")]
        public async Task<List<TitularModel>> GetForeingTitular()
        {
            return await titularRepository.GetForeignTitulars();
        }

    }
}
