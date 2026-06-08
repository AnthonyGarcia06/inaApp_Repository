using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inaApp.Common.interfaces;
using inaApp.Entities;
using inaApp.Repository;

namespace inaApp.Services
{
    public class ClienteService : IGenericService<Cliente>
    {

        //inyeccion de dependencia que viene del repo
        private readonly IGenericRepository<Cliente> _clienteRepo;
        public ClienteService(IGenericRepository<Cliente> clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public Task<Cliente> ActualizarAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> CrearAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> obtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> obtenerTodosAsync()
        {
            _clienteRepo.obtenerTodosAsync();
            return null;
        }
    }
}
