using AutoMapper;
using Lab11_MiguelQuispe.Application.DTOs;
using Lab11_MiguelQuispe.Domain.Models;

namespace Lab11_MiguelQuispe.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Ticket, TicketDto>();
            CreateMap<UserRole, UserRoleDto>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.RoleName, 
                    opt => opt.MapFrom(src => src.Role.RoleName));
        }
    }
}