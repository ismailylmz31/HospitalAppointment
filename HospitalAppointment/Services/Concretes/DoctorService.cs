using HospitalAppointment.Models;
using HospitalAppointment.Models.DTO;
using HospitalAppointment.Repository.Abstracts;
using HospitalAppointment.Services.Abstracts;

namespace HospitalAppointment.Services.Concretes
{
    public class DoctorService : IDoctorService
    {
        private IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }       

        public Doctor Add(DoctorDto doctorDto)
        {
            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Branch = doctorDto.Branch,
                Patients = new List<Appointment>()
            };

            // Doktoru ekleme
            Doctor addedDoctor = _doctorRepository.Add(doctor);
            return addedDoctor;
        }

        public Doctor Delete(int id)
        {
            Doctor doctor = _doctorRepository.Delete(id);
            return doctor;
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll().ToList();

        }

        public Doctor GetById(int id)
        {
            Doctor doctor = _doctorRepository.GetById(id);
            return doctor;
        }

        public Doctor Update(Doctor doctor)
        {
            Doctor updated = _doctorRepository.Update(doctor);
            return updated;
        }
    }
}
