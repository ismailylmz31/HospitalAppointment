using HospitalAppointment.Models;
using HospitalAppointment.Models.DTO;

namespace HospitalAppointment.Services.Abstracts
{
    public interface IAppointmentService
    {
        List<Appointment> GetAllAppointments();

        Appointment GetById(int id);

        Appointment Add(AppointmentDto appointmentDto);

        Appointment Update(Appointment appointment);

        Appointment Delete(int id);

        void DeleteExpiredAppointments();
    }
}
