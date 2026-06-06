using AutoMapper;
using Ein.DTOS;
using EIN.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica_2.DATA.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<GeneracionSetDTO, GeneracionEntity>()
                .ForMember(campo => campo.EstaActivo, asignar => asignar.MapFrom(valor => true));


            CreateMap<GeneracionEntity, GeneracionGetDTO>();

            CreateMap<GrupoSetDto, GrupoEntity>()
                .ForMember(campo => campo.EstaActivo, asignar => asignar.MapFrom(valor => true));

            CreateMap<GrupoEntity, GrupoGetDto>()
                .ForMember(campo=> campo.NombreGeneracion, asignar => asignar.MapFrom (valor=>valor.Generacion.Nombre));
        }
        
    }
}
