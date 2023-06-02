using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IAppointmentRepository _appointmentRepository;

        public RepositoryManager(RepositoryContext context,
            IAppointmentRepository appointmentRepository)
        {
            _context = context;
            _appointmentRepository = appointmentRepository;
        }

        public IAppointmentRepository Appointment => _appointmentRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }


}
