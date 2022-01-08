using AutoMapper;
using BL.DTO;
using DL.Models;

namespace BL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Smartphone, SmartphoneDTO>();
            CreateMap<Case, CaseDTO>();
            CreateMap<Headphones, HeadphonesDTO>();
            CreateMap<Charger, ChargerDTO>();
            CreateMap<Review, ReviewDTO>();
        }
    }
}


