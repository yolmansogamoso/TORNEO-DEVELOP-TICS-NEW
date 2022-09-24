using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Frontend.Pages.DT
{
    public class CreateModel : PageModel
    {
        private readonly IRepositorioDT _repoDT;
        public DirectorTecnico dt { get; set; }

        public CreateModel(IRepositorioDT repoDT)
        {
            _repoDT = repoDT;
        }

        public void OnGet()
        {
            dt = new DirectorTecnico();
        }

        public IActionResult OnPost(DirectorTecnico dt)
        {
           
                _repoDT.AgregarDT(dt);
                return RedirectToPage("Index");
            

        }
    }
}
