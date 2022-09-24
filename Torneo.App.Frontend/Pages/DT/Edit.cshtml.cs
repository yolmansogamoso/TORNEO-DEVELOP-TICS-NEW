using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;


namespace Torneo.App.Frontend.Pages.DT
{
    public class EditModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;

        public EditModel(IRepositorioDT repoDT)
        {
            _repoDT= repoDT;
        }

        public DirectorTecnico dt { get; set; }

        public IActionResult OnGet(int id)
        {
            dt = _repoDT.GetDT(id);
            if (dt == null)
            {
                return NotFound();
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost(DirectorTecnico dt)
        {
            _repoDT.UpdateDT(dt);
            return RedirectToPage("Index");
        }
    }
}
