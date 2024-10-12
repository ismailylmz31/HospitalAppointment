using HospitalAppointment.Models;

namespace HospitalAppointment.Services.Abstracts
{
    public interface IAppointmentService
    {
        List<Appointment> GetAllAppointments();

        Appointment GetById(int id);

        Appointment Add(Appointment appointment);

        Appointment Update(Appointment appointment);

        Appointment Delete(int id);
    }
}
