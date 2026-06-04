using System;
using inaApp.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inaApp.Common.interfaces
{
    public interface IProductoService
    {
        Task<List<Producto>> obtenerTodosAsync();

        Task<Producto> obtenerPorIdAsync(int id);
        Task<Producto> CrearAsync(Producto producto);

        Task<Producto> ActualizarAsync(Producto producto);

        Task<bool> EliminarAsync(int id);
    }
}
