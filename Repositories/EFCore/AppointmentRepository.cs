using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public sealed class AppointmentRepository : RepositoryBase<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneAppointment(Appointment appointment)
        => Create(appointment);

        public void DeleteOneAppointment(Appointment appointment)
        => Delete(appointment);

        //admin
        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await GetAll().OrderBy(a => a.AppointmentCreated).ToListAsync();
        }

        public async Task<Appointment> GetOneAppointmentByIdAsync(int appointmentId)
        {
            return await FindByCondition(b => b.AppointmentId.Equals(appointmentId))
            .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Appointment>> GetUserAllAppointmentsAsync(string userId)
        {
            return await _context.Appointments.Where(a => a.UserId.Equals(userId)).ToListAsync();

        }

        public void UpdateOneAppointment(Appointment appointment)
        => Update(appointment);
    }
}
