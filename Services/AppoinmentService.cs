using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contrants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AppoinmentService : IAppoinmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public AppoinmentService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

       

        public async Task<AppointmentDto> CreateOneAppointmentAsync(string userId, AppointmentDto appointmentDto)
        {
            // var user = await _authenticationService.get
            var entity = _mapper.Map<Appointment>(appointmentDto);
            entity.AppointmentDate= DateTime.Now;
            entity.UserId = userId;
            _repositoryManager.Appointment.CreateOneAppointment(entity);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<AppointmentDto>(entity);
        }

        public async Task DeleteOneAppointmentAsync(int id)
        {
            var entity = await GetOneAppointmentByIdAndCheckExists(id);
            _repositoryManager.Appointment.Delete(entity);
            await _repositoryManager.SaveAsync();
        }

        /*
        public async Task<List<Appointment>> GetAllAppointmentAsync()
        {
            var appointment = await _repositoryManager.Appointment.GetAllAppointmentsAsync();
            return appointment;
        }*/

        public async Task<AppointmentDto> GetOneAppointmentByIdAsync(int id)
        {
            var appointment = await GetOneAppointmentByIdAndCheckExists(id);
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task UpdateOneAppointmentAsync(int id, AppointmentDto appointmentDto)
        {
            var entity = await GetOneAppointmentByIdAndCheckExists(id);
            entity = _mapper.Map<Appointment>(appointmentDto);
            _repositoryManager.Appointment.Update(entity);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Appointment>> UserGetAllAppointmentAsync(string userId)
        {
            return await _repositoryManager.Appointment.GetUserAllAppointmentsAsync(userId);
        }



        private async Task<Appointment> GetOneAppointmentByIdAndCheckExists(int id)
        {
            // check entity 
            var entity = await _repositoryManager.Appointment.GetOneAppointmentByIdAsync(id);

            if (entity is null)
                throw new Exception("not found"+id);

            return entity;
        }














    }
}
