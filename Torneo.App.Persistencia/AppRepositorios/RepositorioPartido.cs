using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;

namespace Torneo.App.Persistencia
{
    public class RepositorioPartido : IRepositorioPartido
    {
        private readonly DataContext _dataContext = new DataContext();
        
        public Partido AgregarPartido(Partido partido, int Local, int Visitante)
        {
            var localEncontrado = _dataContext.Equipos.Find(Local);
            var visitanteEncontrado = _dataContext.Equipos.Find(Visitante);
            partido.Local = localEncontrado;
            partido.Visitante = visitanteEncontrado;
            var partidoInsertado = _dataContext.Partidos.Add(partido);
            _dataContext.SaveChanges();
            return partidoInsertado.Entity;
        }

        public IEnumerable<Partido> GetAllPartidos()
        {
            var partidos = _dataContext.Partidos
                .Include(e => e.Local)
                .Include(e => e.Visitante)
                .ToList();
            return partidos;
        }

        public Partido GetPartido(int idPartido)
        {
            var partidoEncontrado = _dataContext.Partidos
            .Where(e => e.Id == idPartido)
            .Include(e => e.Visitante)
            .Include(e => e.Local)
            .FirstOrDefault();
            return partidoEncontrado;
        }
    }   
}