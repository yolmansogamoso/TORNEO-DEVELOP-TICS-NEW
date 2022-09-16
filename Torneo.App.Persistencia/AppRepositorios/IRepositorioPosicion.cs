using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioPosicion
    {
        public Posicion AgregarPosicion(Posicion posicion);
        public IEnumerable<Posicion> GetAllPosiciones();
    }
}