using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Jugadores
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioJugador _repoJugador;
        private readonly IRepositorioPosicion _repoPosicion;
        private readonly IRepositorioEquipo _repoEquipo;

        public Jugador jugador { get; set; }
        public SelectList PosicionOptions { get; set; }
        public SelectList EquipoOptions { get; set; }
        public int PosicionSelected { get; set; }
        public int EquipoSelected { get; set; }

        public EditModel(IRepositorioJugador repoJugador, IRepositorioPosicion repoPosicion, IRepositorioEquipo repoEquipo)
        {
            _repoJugador = repoJugador;
            _repoPosicion = repoPosicion;
            _repoEquipo = repoEquipo;
        }

        public IActionResult OnGet(int id)
        {
            jugador = _repoJugador.GetJugador(id);
            PosicionOptions = new SelectList(_repoPosicion.GetAllPosiciones(), "Id", "Nombre");
            PosicionSelected = jugador.Posicion.Id;
            EquipoOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            EquipoSelected = jugador.Equipo.Id;
            if (jugador == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Jugador jugador, int idPosicion, int idEquipo)
        {
            _repoJugador.UpdateJugador(jugador, idPosicion, idEquipo);
            return RedirectToPage("Index");
        }
    }
}