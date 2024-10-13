using HospitalAppointment.Models;
using HospitalAppointment.Models.DTO;
using HospitalAppointment.ReturnModel;

namespace HospitalAppointment.Services.Abstracts
{
    public interface IDoctorService
    {
        List<Doctor> GetAllDoctors();

        Doctor GetById(int id);

        ReturnModel<Doctor> Add(DoctorDto doctorDto);

        Doctor Update(Doctor doctor);

        Doctor Delete(int id);

    }
}
