namespace Torneo.App.Dominio
{
    public class Municipio
    {
        public int id { get; set; }
        public string Nombre { get; set; }

        public List<Equipo> Equipos { get; set; }
    }
}