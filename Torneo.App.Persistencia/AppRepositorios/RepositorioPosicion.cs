using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;

namespace Torneo.App.Persistencia
{
    public class RepositorioPosicion : IRepositorioPosicion
    {
        private readonly DataContext _dataContext = new DataContext();
        
        public Posicion AgregarPosicion(Posicion posicion)
        {
            var posicionInsertada = _dataContext.Posiciones.Add(posicion);
            _dataContext.SaveChanges();
            return posicionInsertada.Entity;
        }

        public IEnumerable<Posicion> GetAllPosiciones()
        {
            return _dataContext.Posiciones;
        }

        public Posicion GetPosicion(int idPosicion)
        {
            var posicionEncontrado = _dataContext.Posiciones.Find(idPosicion);
            return posicionEncontrado;
        }

        public Posicion UpdatePosicion(Posicion posicion)
        {
            var posicionEncontrado = _dataContext.Posiciones.Find(posicion.Id);
            if (posicionEncontrado != null)
            {
                posicionEncontrado.Nombre = posicion.Nombre;
                _dataContext.SaveChanges();
            }
            return posicionEncontrado;
        }


    }
}