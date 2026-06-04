using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inaApp.Entities;

namespace inaApp.Common.interfaces
{
    public interface IClienteService
    {
        Task<List<Cliente>> obtenerTodosAsync();

        Task<Cliente> obtenerPorIdAsync(int id);
        Task<Cliente> CrearAsync(Cliente cliente);

        Task<Cliente> ActualizarAsync(Cliente cliente);

        Task<bool> EliminarAsync(int id);
    }
}
