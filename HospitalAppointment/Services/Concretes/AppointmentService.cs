using HospitalAppointment.Models;
using HospitalAppointment.Repository.Abstracts;
using HospitalAppointment.Services.Abstracts;

namespace HospitalAppointment.Services.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment Add(Appointment appointment)
        {
            Appointment addAppointment = _appointmentRepository.Add(appointment);
            return addAppointment;
        }

        public Appointment Delete(int id)
        {
            Appointment appointment = _appointmentRepository.Delete(id);
            return appointment;
        }

        public List<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll().ToList();
        }

        public Appointment GetById(int id)
        {
           Appointment appointment = _appointmentRepository.GetById(id);
            return appointment;
        }

        public Appointment Update(Appointment appointment)
        {
            Appointment updated = _appointmentRepository.Update(appointment);
            return updated;
        }
    }
}
