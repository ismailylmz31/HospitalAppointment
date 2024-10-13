using HospitalAppointment.Context;
using HospitalAppointment.Models;
using HospitalAppointment.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;

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
            return _context.Doctors.Include(d => d.Patients).ToList();
        }

        public Doctor GetById(int id)
        {
            return _context.Doctors.Include(d => d.Patients).FirstOrDefault(d => d.Id == id);
        }

        public Doctor Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            return doctor;
        }
    }
}
