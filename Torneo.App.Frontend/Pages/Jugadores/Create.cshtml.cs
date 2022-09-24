using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Jugadores
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioPosicion _repoPosicion;
        private readonly IRepositorioEquipo _repoEquipo;
        
        public Jugador jugador {get; set;}
        public IEnumerable<Posicion> posicion { get; set; }
        public IEnumerable<Equipo> equipo { get; set; }

        public CreateModel(IRepositorioJugador repoJugador, IRepositorioPosicion repoPosicion, IRepositorioEquipo repoEquipo)
        {
            _repoJugador = repoJugador;
            _repoPosicion = repoPosicion;
            _repoEquipo = repoEquipo;
        }

        public void OnGet()
        {
            jugador = new Jugador();
            posicion = _repoPosicion.GetAllPosiciones();
            equipo = _repoEquipo.GetAllEquipos();
        }

        public IActionResult OnPost(Jugador jugador, int idPosicion, int idEquipo)
        {
            _repoJugador.AgregarJugador(jugador, idPosicion, idEquipo);
            return RedirectToPage("Index");
        }
    }
}