using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioPartido
    {
        public Partido AgregarPartido(Partido partido, int Local, int Visitante);
        public IEnumerable<Partido> GetAllPartidos();
    }
}