using HospitalAppointment.Context;
using HospitalAppointment.Models;
using HospitalAppointment.Repository.Abstracts;

namespace HospitalAppointment.Repository.Concretes
{
    public class EfDoctorRepository : IDoctorRepository
    {
        private PostgreSqlContext _context;

        public EfDoctorRepository(PostgreSqlContext context)
        {
            _context = context;
        }

        public Doctor Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public Doctor Delete(int id)
        {
            Doctor doctor = GetById(id);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor? GetById(int id)
        {
            Doctor? doctor = _context.Doctors.Find(id);
            return doctor;
        }

        public Doctor Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            return doctor;
        }
    }
}
