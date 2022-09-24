using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;

namespace Torneo.App.Persistencia
{
    public class RepositorioEquipo : IRepositorioEquipo
    {
        private readonly DataContext _dataContext = new DataContext();

        public Equipo AgregarEquipo(Equipo equipo, int idMunicipio, int idDT)
        {
            var municipioEncontrado = _dataContext.Municipios.Find(idMunicipio);
            var DTEncontrado = _dataContext.DirectoresTecnicos.Find(idDT);
            equipo.Municipio = municipioEncontrado;
            equipo.DirectorTecnico = DTEncontrado;
            var equipoInsertado = _dataContext.Equipos.Add(equipo);
            _dataContext.SaveChanges();
            return equipoInsertado.Entity;
        }

        public IEnumerable<Equipo> GetAllEquipos()
        {
            var equipos = _dataContext.Equipos
                .Include(e => e.Municipio)
                .Include(e => e.DirectorTecnico)
                .Include(e => e.Jugadores)
                .ToList();
            return equipos;
        }

        public Equipo GetEquipo(int idEquipo)
        {
            var equipoEncontrado = _dataContext.Equipos
            .Where(e => e.Id == idEquipo)
            .Include(e => e.Municipio)
            .Include(e => e.DirectorTecnico)
            .FirstOrDefault();
            return equipoEncontrado;
        }

        public Equipo DeleteEquipo(int idEquipo)
        {
            var equipoEncontrado = _dataContext.Equipos.Find(idEquipo);
            /*   if (equipoEncontrado != null)
              { */
            _dataContext.Equipos.Remove(equipoEncontrado);
            _dataContext.SaveChanges();
            /*    } */
            return equipoEncontrado;
        }

        public Equipo UpdateEquipo(Equipo equipo, int idMunicipio, int idDT)
        {
            var equipoEncontrado = GetEquipo(equipo.Id);
            var municipioEncontrado = _dataContext.Municipios.Find(idMunicipio);
            var DTEncontrado = _dataContext.DirectoresTecnicos.Find(idDT);
            equipoEncontrado.Nombre = equipo.Nombre;
            equipoEncontrado.Municipio = municipioEncontrado;
            equipoEncontrado.DirectorTecnico = DTEncontrado;
            _dataContext.SaveChanges();
            return equipoEncontrado;
        }
    }
}