using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace ApiAppointmentReminder.Utilities.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserRegistrationDto, User>();
            CreateMap<Appointment,AppointmentDto>().ReverseMap();
        }
    }
}
