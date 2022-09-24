using Torneo.App.Dominio;
using System.Collections.Generic;

namespace Torneo.App.Persistencia
{
    public interface IRepositorioMunicipio
    {
        public Municipio AgregarMunicipio(Municipio municipio);
        public IEnumerable<Municipio> GetAllMunicipios();
        public Municipio GetMunicipio(int idMunicipio);
        public Municipio DeleteMunicipio(int idMunicipio);
        public Municipio UpdateMunicipio(Municipio municipio);
    }
}