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
    public class ProductoService : IProductoService
    {

        private readonly IProductoRepository _productoRepo;
        public ProductoService(IProductoRepository productoRepo)
        {
            _productoRepo = productoRepo;
        }

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

            _productoRepo.obtenerTodosAsync();
;            return null;
        }
    }
}
