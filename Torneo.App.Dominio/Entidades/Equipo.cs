using System.Collections.Generic;
namespace Torneo.App.Dominio;
using System.ComponentModel.DataAnnotations.Schema;



    public class Equipo 
    {

        public int Id  { get; set; }
        public string Nombre { get; set; }
        public Municipio Municipio { get; set; }
        public DirectorTecnico DirectorTecnico { get; set; }
        public List<Jugador> Jugadores {get; set; }
        
    }
    
