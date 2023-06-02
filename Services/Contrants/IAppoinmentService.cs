using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contrants
{
    public interface IAppoinmentService
    {
        Task<IEnumerable<Appointment>> UserGetAllAppointmentAsync(string userId);
        Task<AppointmentDto> GetOneAppointmentByIdAsync(int id);
        Task<AppointmentDto> CreateOneAppointmentAsync(string userId,AppointmentDto appointmentDto);
        Task UpdateOneAppointmentAsync(int id, AppointmentDto appointmentDto);
        Task DeleteOneAppointmentAsync(int id);
        //Task<List<Appointment>> GetAllAppointmentAsync();

    }


}
