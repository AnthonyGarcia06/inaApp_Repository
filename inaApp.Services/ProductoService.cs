using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using inaApp.Common.Exceptions;
using inaApp.Common.interfaces;
using inaApp.DTOs.Producto;
using inaApp.Common.Response;
using inaApp.Entities;
using inaApp.Repository;
namespace inaApp.Services
{
    public class ProductoService : IGenericService<ProductoResponseDTO, ProductoCreateDTO, ProductoUpdateDTO>
    {

        private readonly IGenericRepository<Producto> _productoRepo;
        private readonly IMapper _mapper;
        public ProductoService(IGenericRepository<Producto> productoRepo,IMapper mapper)
        {
            _productoRepo = productoRepo;
            _mapper = mapper;
        }

        public async Task<Response<ProductoResponseDTO>> ActualizarAsync(ProductoUpdateDTO entity)
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

            //Validar que la categoria exista, si no existe lanzar una excepcion personalizada NotFoundException con el mensaje "La categoría con el id {id} no existe"
            //var categoria = await _productoRepo.obtenerPorIdAsync(entity.CategoriaId);
            //if (categoria == null)
            //{
            //    throw new NotFoundException($"La categoría con el id {entity.CategoriaId} no existe");
            //}

            var productos = await _productoRepo.obtenerTodosAsync();
            if (productos.Any(p => p.Nombre.ToLower() == entity.Nombre.ToLower() && p.Id != entity.Id))
            {
                throw new DuplicateNameException($"El nombre {entity.Nombre} ya existe");
            }

            var producto= _mapper.Map<Producto>(entity);
            producto = await _productoRepo.ActualizarAsync(producto);

            //var productoResponse= _mapper.Map<ProductoResponseDTO>(producto);

            //return productoResponse;

            // Cargar la categoría asociada para que salga la categoría en el response, esto es porque el producto que retorna el repo no tiene cargada la categoria
            producto = await _productoRepo.obtenerPorIdAsync(producto.Id);

            return new Response<ProductoResponseDTO>
            {
                Data = _mapper.Map<ProductoResponseDTO>(producto),
                Message = "Producto actualizado exitosamente",
                Success = true
            };
        }

        public async Task<Response<ProductoResponseDTO>> CrearAsync(ProductoCreateDTO entity)
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

            ////Misma validacion que en el de actualizar para validar que la categoria exista, si no existe lanzar una excepcion personalizada NotFoundException con el mensaje "La categoría con el id {id} no existe"
            //var categoria = await _productoRepo.obtenerPorIdAsync(entity.CategoriaId);
            //if (categoria == null)
            //{
            //    throw new NotFoundException($"La categoría con el id {entity.CategoriaId} no existe");
            //}

            var productos = await _productoRepo.obtenerTodosAsync();
            if (productos.Any(p => p.Nombre.ToLower() == entity.Nombre.ToLower()))
            {
                throw new DuplicateNameException($"El nombre {entity.Nombre} ya existe");
            }

            //aqui tenemos que convertir el dto a entity y guardarlo en base de datos 
            //Asi era la manera vieja de mappear sin automapper
            //Producto producto= new Producto()
            //{
            //    Nombre = entity.Nombre,
            //    Precio = entity.Precio,
            //    Stock = entity.Stock,
            //    Descripcion = entity.Descripcion,
            //    Estado = true
            //};
            Producto producto = _mapper.Map<Producto>(entity);

            producto = await _productoRepo.CrearAsync(producto);

            //aqui tenemos que convertir entity y retomar producto responmse //igual esto es sin automapper a pata
            //ProductoResponseDTO productoResponse = new ProductoResponseDTO()
            //{
            //    Id = producto.Id,
            //    Nombre = producto.Nombre,
            //    Precio = producto.Precio,
            //    Stock = producto.Stock,
            //    Descripcion = producto.Descripcion
            //};

            //ProductoResponseDTO productoResponse= _mapper.Map<ProductoResponseDTO>(producto);
            //return productoResponse;

            // Cargar la categoría asociada para que salga la categoría en el response, esto es porque el producto que retorna el repo no tiene cargada la categoria
            producto = await _productoRepo.obtenerPorIdAsync(producto.Id);

            return new Response<ProductoResponseDTO>
            {
                Data = _mapper.Map<ProductoResponseDTO>(producto),
                Message = "Producto creado exitosamente",
                Success = true
            };


        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            //reglas de negocio 

            
            
            //return await _productoRepo.EliminarAsync(id);

            return new Response<bool>
            {
                Data =  await _productoRepo.EliminarAsync(id),
                Message = "Producto obtenidos exitosamente",
                Success = true
            };

        }

        public async Task<Response<ProductoResponseDTO>> ObtenerPorIdAsync(int id)
        {
            var pro = await _productoRepo.obtenerPorIdAsync(id);

            if (pro is null)
            {
                //se uso string template para esto
                throw new NotFoundException($"El producto con el id {id} no existe");
            }

            ////convierte a dto response
            //var productoResponse= _mapper.Map<ProductoResponseDTO>(pro);
            //return productoResponse;

            return new Response<ProductoResponseDTO>
            {
                Data = _mapper.Map<ProductoResponseDTO>(pro),
                Message = "Producto obtenido exitosamente",
                Success = true
            };
        }

        

        public async Task<Response<List<ProductoResponseDTO>>> ObtenerTodosAsync()
        {
            var listaProd = await _productoRepo.obtenerTodosAsync();
            //var listaDTOs= _mapper.Map<List<ProductoResponseDTO>>(listaProd);

            //validar que la lista no este vacia, si esta vacia lanzar una excepcion personalizada NotFoundException con el mensaje "No hay productos registrados"
            if (!listaProd.Any())
                throw new NotFoundException("No hay productos registrados");

            //return listaDTOs;

            return new Response<List<ProductoResponseDTO>>
            {
                Data = _mapper.Map<List<ProductoResponseDTO>>(listaProd),
                Message = "Producto obtenidos exitosamente",
                Success = true
            };
        }
       

    }
}
