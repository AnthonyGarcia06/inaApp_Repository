using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inaApp.Common.Exceptions;
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

            // reglas de negocio
            //precio sea mayor a 0 - InvalidPriceException
            //Nombre repetido - DuplicateProductNameException
            //Stock negativo o 0 --invalidStockException

            if (entity.Precio <= 0)
            {
                throw new InvalidPriceException("El precio debe ser mayor a 0");
            }

            if (entity.Stock <= 0)
            {
                throw new invalidStockException("El stock debe ser mayor a 0");
            }

            var productos = await _productoRepo.obtenerTodosAsync();
            if (productos.Any(p => p.Nombre.ToLower() == entity.Nombre.ToLower() && p.Id != entity.Id))
            {
                throw new DuplicateNameException($"El nombre {entity.Nombre} ya existe");
            }
            return await _productoRepo.ActualizarAsync(entity);
        }

        public async Task<Producto> CrearAsync(Producto entity)
        {
            //reglas de negocio
            //precio sea mayor a 0 - InvalidPriceException
            //Nombre repetido - DuplicateProductNameException
            //Stock negativo o 0 --invalidStockException

            if (entity.Precio <= 0)
            {
                throw new InvalidPriceException("El precio debe ser mayor a 0");
            }

            if (entity.Stock <= 0)
            {
                throw new invalidStockException("El stock debe ser mayor a 0");
            }

            var productos = await _productoRepo.obtenerTodosAsync();
            if (productos.Any(p => p.Nombre.ToLower() == entity.Nombre.ToLower()))
            {
                throw new DuplicateNameException($"El nombre {entity.Nombre} ya existe");
            }


            return await _productoRepo.CrearAsync(entity);
        }

        public async Task<bool> EliminarAsync(int id)
        {
            //reglas de negocio 
            
            return await _productoRepo.EliminarAsync(id); 
        }

        public async Task<Producto> obtenerPorIdAsync(int id)
        {
            //Regla de negocio para que el producto exista
            var pro= await _productoRepo.obtenerPorIdAsync(id);

            if (pro is null) { 
                //se uso string template para esto
                throw new NotFoundException ($"El producto con el id {id} no existe"); 
            }

            return pro;
        }

        public async Task<List<Producto>> obtenerTodosAsync()
        {
           return await _productoRepo.obtenerTodosAsync();
            //return null;
        }
    }
}
