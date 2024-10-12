using HospitalAppointment.Models;

namespace HospitalAppointment.Services.Abstracts
{
    public interface IDoctorService
    {
        List<Doctor> GetAllDoctors();

        Doctor GetById(int id);

        Doctor Add(Doctor doctor);

        Doctor Update(Doctor doctor);

        Doctor Delete(int id);

    }
}
