
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CompuMaintenance.App.Dominio;

namespace CompuMaintenance.App.Persistencia
{
    public interface IRepositorioCliente
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente AddCliente(Cliente cliente);
        Cliente UpdateCliente(Cliente cliente);
        void DeleteCliente(int idCliente);    
        Cliente GetCliente(int idCliente);
        IEnumerable<Cliente>  GetClientesMasculinos();
             
       
    }


}