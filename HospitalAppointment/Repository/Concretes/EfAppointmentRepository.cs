using HospitalAppointment.Context;
using HospitalAppointment.Models;
using HospitalAppointment.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Repository.Concretes
{
    public class EfAppointmentRepository : IAppointmentRepository
    {
        private PostgreSqlContext _context;

        public EfAppointmentRepository(PostgreSqlContext context)
        {
            _context = context;
        }
        public Appointment Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public Appointment Delete(int id)
        {
            Appointment? appointment = GetById(id);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return appointment;


        }

        public List<Appointment> GetAll()
        {
            return _context.Appointments
                    .Include(a => a.Doctor)
                    .ToList();
        }

        public Appointment? GetById(int id)
        {
            return _context.Appointments
                    .Include(a => a.Doctor)
                    .FirstOrDefault(a => a.Id == id);

        }

        public Appointment Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
            return appointment;
        }
    }
}
