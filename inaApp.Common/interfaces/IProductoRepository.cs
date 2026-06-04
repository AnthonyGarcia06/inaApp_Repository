using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inaApp.Entities;

namespace inaApp.Repository
{
    public interface IProductoRepository
    {
        Task<List<Producto>> obtenerTodosAsync();

        Task<Producto> obtenerPorIdAsync(int id);
        Task<Producto> CrearAsync(Producto producto);

        Task<Producto> ActualizarAsync(Producto producto);

        Task<bool> EliminarAsync(int id);
    }
}
