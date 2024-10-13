using HospitalAppointment.Models;
using HospitalAppointment.Models.DTO;

namespace HospitalAppointment.Services.Abstracts
{
    public interface IDoctorService
    {
        List<Doctor> GetAllDoctors();

        Doctor GetById(int id);

        Doctor Add(DoctorDto doctorDto);

        Doctor Update(Doctor doctor);

        Doctor Delete(int id);

    }
}
