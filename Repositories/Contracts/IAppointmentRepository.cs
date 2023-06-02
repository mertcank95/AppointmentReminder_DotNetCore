using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IAppointmentRepository : IRepositoyBase<Appointment>
    {
        //Admin
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<IEnumerable<Appointment>> GetUserAllAppointmentsAsync(string userId);
        Task<Appointment> GetOneAppointmentByIdAsync(int appointmentId);
        void CreateOneAppointment(Appointment appointment);
        void UpdateOneAppointment(Appointment appointment);
        void DeleteOneAppointment(Appointment appointment);
    }

}
