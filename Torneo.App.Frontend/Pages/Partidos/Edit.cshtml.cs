using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Torneo.App.Frontend.Pages.Partidos
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioPartido _repoPartido;
        private readonly IRepositorioEquipo _repoEquipo;

        public Partido partido { get; set; }
        public SelectList EquipoLocalOptions { get; set; }
        public int EquipoLocalSelected { get; set; }
        public SelectList EquipoVisitanteOptions { get; set; }
        public int EquipoVisitanteSelected { get; set; }

        public EditModel(IRepositorioPartido repoPartido, IRepositorioEquipo repoEquipo)
        {
            _repoPartido = repoPartido;
            _repoEquipo = repoEquipo;
        }

        public IActionResult OnGet(int id)
        {
            partido = _repoPartido.GetPartido(id);
            EquipoLocalOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            EquipoLocalSelected = partido.Local.Id;
            EquipoVisitanteOptions = new SelectList(_repoEquipo.GetAllEquipos(), "Id", "Nombre");
            EquipoVisitanteSelected = partido.Visitante.Id;
            if (partido == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(Partido partido, int idLocal, int idVisitante)
        {
            _repoPartido.UpdatePartido(partido, idLocal, idVisitante);
            return RedirectToPage("Index");
        }
    }
}