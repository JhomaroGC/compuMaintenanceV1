using System;
using System.Collections.Generic;
using System.Linq;
using CompuMaintenance.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace CompuMaintenance.App.Persistencia
{

    public class RepositorioCliente : IRepositorioCliente
    {
        /// <summary>
        /// Referencia al contexto de Cliente
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioCliente(AppContext appContext)
        {
            _appContext = appContext;
        }


        public Cliente AddCliente(Cliente cliente)
        {
            var clienteAdicionado = _appContext.Clientes.Add(cliente);
            _appContext.SaveChanges();
            return clienteAdicionado.Entity;

        }

        public void DeleteCliente(int idCliente)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            if (clienteEncontrado == null)
                return;
            _appContext.Clientes.Remove(clienteEncontrado);
            _appContext.SaveChanges();
        }

       public IEnumerable<Cliente> GetAllClientes()
        {
            return GetAllClientes_();
        }
        public IEnumerable<Cliente> GetClientesPorFiltro(string filtro)
        {
            var clientes = GetAllClientes(); // Obtiene todos los saludos
            if (clientes != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    clientes = clientes.Where(s => s.Nombre.Contains(filtro));
                }

            }
            return clientes;

        }

        public IEnumerable<Cliente> GetAllClientes_()
        {
            return _appContext.Clientes;
        }

        public Cliente GetCliente(int idCliente)
        {
            return _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
        }

        public Cliente UpdateCliente(Cliente cliente)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
            if (clienteEncontrado != null)
            {
                clienteEncontrado.Nombre = cliente.Nombre;
                clienteEncontrado.Apellidos = cliente.Apellidos;
                clienteEncontrado.NumeroTelefono = cliente.NumeroTelefono;
                clienteEncontrado.Genero = cliente.Genero;
                clienteEncontrado.Direccion = cliente.Direccion;

                _appContext.SaveChanges();


            }
            return clienteEncontrado;
        }

        public IEnumerable<Cliente> GetClientesMasculinos()
        {

            return _appContext.Clientes.Where(c => c.Genero == Genero.Masculino).ToList();        
        }

    }
}