using HospitalAppointment.Models;
using HospitalAppointment.Models.DTO;
using HospitalAppointment.Repository.Abstracts;
using HospitalAppointment.ReturnModel;
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

        public ReturnModel<Doctor> Add(DoctorDto doctorDto)
        {
            if (doctorDto.Name == null || doctorDto.Name == "")
            {
                return new ReturnModel<Doctor>
                {
                    Data = null,
                    Success = false,
                    Message = "Doktor isim alanı boş bırakılamaz."
                };
            }
            var doctor = new Doctor
            {
                Name = doctorDto.Name,
                Branch = doctorDto.Branch,
                Patients = new List<Appointment>()
            };

            // Doktoru ekleme
            Doctor addedDoctor = _doctorRepository.Add(doctor);
            return new ReturnModel<Doctor>
            {
                Data = addedDoctor,
                Success = true,
                Message = "Doktor Başarı ile eklendi."
            };
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
