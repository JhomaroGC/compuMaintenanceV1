using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompuMaintenance.App.Dominio;
using CompuMaintenance.App.Persistencia;

namespace CompuMaintenance.App.FrontEnd.Pages.Clientes
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositorioCliente repositorioClientes;

        public Cliente Cliente { get; set; }

        public DetailsModel()
        {
            this.repositorioClientes=new RepositorioCliente(new CompuMaintenance.App.Persistencia.AppContext());
        }

        public IActionResult OnGet(int clienteId)
        {
            Cliente = repositorioClientes.GetCliente(clienteId);

            if(Cliente==null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }
    }
}
