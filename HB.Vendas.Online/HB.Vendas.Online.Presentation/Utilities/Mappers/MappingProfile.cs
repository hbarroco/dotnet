using AutoMapper;
using HB.Vendas.Online.Domain.Entities;
using HB.Vendas.Online.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB.Vendas.Online.Presentation.Utilities.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to DTO
            CreateMap<User, UserDTO>();
            CreateMap<Store, StoreDTO>();

            // DTO to Domain
            CreateMap<UserDTO, User>();
            CreateMap<StoreDTO, Store>();
        }
    }
}
