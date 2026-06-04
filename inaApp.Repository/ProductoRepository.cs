using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inaApp.Entities;

namespace inaApp.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        public Task<Producto> ActualizarAsync(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> CrearAsync(Producto producto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> obtenerPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Producto>> obtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
