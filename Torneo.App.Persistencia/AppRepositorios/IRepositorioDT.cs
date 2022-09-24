using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioDT
    {
        public DirectorTecnico AgregarDT(DirectorTecnico directorTecnico);
        public IEnumerable<DirectorTecnico> GetAllDTs();
        public DirectorTecnico GetDT(int idDT);
        public DirectorTecnico DeleteDT(int idDT);
        public DirectorTecnico UpdateDT(DirectorTecnico directorTecnico);
    }
}