using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CompuMaintenance.App.Dominio;
using CompuMaintenance.App.Persistencia;



namespace CompuMaintenance.App.Frontend.Pages
{

    public class ListModel : PageModel
    {
        private readonly IRepositorioCliente repositorioClientes;

        public IEnumerable<Cliente> clientes {get;set;}   
       

        public ListModel()
       {
            this.repositorioClientes= new RepositorioCliente(new CompuMaintenance.App.Persistencia.AppContext());
       }
       
        public void OnGet(string filtroBusqueda)
        {
            clientes = repositorioClientes.GetAllClientes();
          
        }
    }
}
