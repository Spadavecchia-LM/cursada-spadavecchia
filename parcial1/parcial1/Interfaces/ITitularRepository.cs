using parcial1.Models;

namespace parcial1.Interfaces
{
    public interface ITitularRepository
    {
        //Registrar al titular del trámite (la persona destinataria del DNI o Pasaporte) Si el titular ya existe no nos importa, esto es un MVP. Aunque sería ideal que no se repitieran....
        public Task<bool> CreateTitular(TitularModel titular);

        //Para una parte de administración, será necesario consultar los titulares cuyo DNI comiencen con 92;93;94 ó 95 millones para listar a los extranjeros.
        public Task<List<TitularModel>> GetForeignTitulars();
    }
}
