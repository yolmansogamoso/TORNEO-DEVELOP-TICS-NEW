using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioEquipo
    {
        public Equipo AgregarEquipo(Equipo equipo, int idMunicipio, int idDT);
        public IEnumerable<Equipo> GetAllEquipos();
    }
}