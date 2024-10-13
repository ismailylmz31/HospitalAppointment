using HospitalAppointment.Models;
using HospitalAppointment.Models.DTO;
using HospitalAppointment.ReturnModel;

namespace HospitalAppointment.Services.Abstracts
{
    public interface IAppointmentService
    {
        List<Appointment> GetAllAppointments();

        Appointment GetById(int id);

        ReturnModel<Appointment> Add(AppointmentDto appointmentDto);

        Appointment Update(Appointment appointment);

        Appointment Delete(int id);

        void DeleteExpiredAppointments();
    }
}
