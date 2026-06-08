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
    public class ProductoService : IGenericService<Producto>
    {

        private readonly IGenericRepository<Producto> _productoRepo;
        public ProductoService(IGenericRepository<Producto> productoRepo)
        {
            _productoRepo = productoRepo;
        }

        public async Task<Producto> ActualizarAsync(Producto entity)
        {
            return await _productoRepo.ActualizarAsync(entity);
        }

        public async Task<Producto> CrearAsync(Producto entity)
        {
            //reglas de negocio


            return await _productoRepo.CrearAsync(entity);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            //reglas de negocio 
            
            return await _productoRepo.EliminarAsync(id); 
        }

        public async Task<Producto> obtenerPorIdAsync(int id)
        {
            return await _productoRepo.obtenerPorIdAsync(id);
            //throw new NotImplementedException();
        }

        public async Task<List<Producto>> obtenerTodosAsync()
        {
           return await _productoRepo.obtenerTodosAsync();
            //return null;
        }
    }
}
