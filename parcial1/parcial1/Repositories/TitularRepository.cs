

using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using parcial1.EF;
using parcial1.Interfaces;
using parcial1.Models;

namespace parcial1.Repositories
{
    public class TitularRepository(MiDBContext _context) : ITitularRepository
    {
        public async Task<bool> CreateTitular(TitularModel titular)
        {
            var titularEntity = new Titulare
            {
                Nombre = titular.Nombre,
                Apellido = titular.Apellido,
                Dni = titular.Dni
            };

            _context.Titulares.Add(titularEntity);

            var result = await _context.SaveChangesAsync();

            return (result > 0);
        }

        //6) Nice To Have: En el punto 5, que solo se muestren los primeros 100 registros para no romper la prueba.
        public async Task<List<TitularModel>> GetForeignTitulars()
        {
            var fTitulares = new List<TitularModel>();

            var titulares = await _context.Titulares
                .Where(t =>
                    t.Dni.StartsWith("92") ||
                    t.Dni.StartsWith("93") ||
                    t.Dni.StartsWith("94") ||
                    t.Dni.StartsWith("95"))
                .Take(100)
                .ToListAsync();

            foreach (var t in titulares)
            {
                var titularModel = new TitularModel
                {
                    Nombre = t.Nombre,
                    Apellido = t.Apellido,
                    Dni = t.Dni
                };

                fTitulares.Add(titularModel);
            }

            return fTitulares;
        }
    }
}
