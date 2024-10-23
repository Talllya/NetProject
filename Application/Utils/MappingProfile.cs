using Application.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cart, CartDTO>().ReverseMap();
            CreateMap<CreateCartCommand, Cart>().ReverseMap();
            CreateMap<UpdateCartCommand, Cart>().ReverseMap();
        }
    }
}
