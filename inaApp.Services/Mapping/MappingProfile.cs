using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using inaApp.DTOs.Cliente;
using inaApp.DTOs.Producto;
using inaApp.Entities;

namespace inaApp.Services.Mapping
{
    public class MappingProfile : Profile
    {

    
        public MappingProfile()
        {

            //DTO create -> Entity
            CreateMap<ProductoCreateDTO, Producto>();
            CreateMap<ClienteCreateDTO, Cliente>();

            //DTO Update -> Entity
            CreateMap<ProductoUpdateDTO, Producto>();
            CreateMap<ClienteUpdateDTO, Cliente>();

            //Entity -> DTO Response    //ademas un mapeo personalizado para obtener el nombre de la categoria desde la entidad Producto
            CreateMap<Producto, ProductoResponseDTO>().ForMember(dest => dest.CategoriaNombre, opt => opt.MapFrom(src => src.Categoria.Nombre)); 
            CreateMap<Cliente, ClienteResponseDTO>();
        }


    }
}
