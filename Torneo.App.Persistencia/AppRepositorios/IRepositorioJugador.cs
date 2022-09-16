using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioJugador
    {
        public Jugador AgregarJugador(Jugador jugador, int idEquipo, int idPosicion);
        public IEnumerable<Jugador> GetAllJugadores();
    }
}