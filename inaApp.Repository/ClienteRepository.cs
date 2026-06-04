using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inaApp.Common.interfaces;
using inaApp.Entities;

namespace inaApp.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public Task<Cliente> ActualizarAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> CrearAsync(Cliente cliente)
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
            throw new NotImplementedException();
        }
    }
}
