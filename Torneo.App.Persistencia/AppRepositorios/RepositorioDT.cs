using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;

namespace Torneo.App.Persistencia
{
    public class RepositorioDT : IRepositorioDT
    {
        private readonly DataContext _dataContext = new DataContext();

        public DirectorTecnico AgregarDT(DirectorTecnico directorTecnico)
        {
            var DTInsertado = _dataContext.DirectoresTecnicos.Add(directorTecnico);
            _dataContext.SaveChanges();
            return DTInsertado.Entity;
        }

        public IEnumerable<DirectorTecnico> GetAllDTs()
        {
            var dt = _dataContext.DirectoresTecnicos
              .Include(m => m.Equipos)
              .ToList();
            return dt;
        }

        public DirectorTecnico GetDT(int idDT)
        {
            var DTEncontrado = _dataContext.DirectoresTecnicos.Find(idDT);
            return DTEncontrado;
        }


        public DirectorTecnico DeleteDT(int idDT)
        {
            var DTEncontrado = _dataContext.DirectoresTecnicos.Find(idDT);
            if (DTEncontrado != null)
            {
                _dataContext.DirectoresTecnicos.Remove(DTEncontrado);
                _dataContext.SaveChanges();
            }
            return DTEncontrado;
        }

        public DirectorTecnico UpdateDT(DirectorTecnico directorTecnico)
        {
            var DTEncontrado = _dataContext.DirectoresTecnicos.Find(directorTecnico.Id);
            if (DTEncontrado != null)
            {
                DTEncontrado.Nombre = directorTecnico.Nombre;
                _dataContext.SaveChanges();
            }
            return DTEncontrado;
        }
    }
}