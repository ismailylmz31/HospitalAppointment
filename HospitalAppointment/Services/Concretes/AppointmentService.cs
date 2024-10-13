using HospitalAppointment.Models;
using HospitalAppointment.Repository.Abstracts;
using HospitalAppointment.Services.Abstracts;

namespace HospitalAppointment.Services.Concretes
{
    public class AppointmentService : IAppointmentService
    {
        private IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public Appointment Add(Appointment appointment)
        {
            // Tarih validasyonunu yapıyoruz
            if (!IsValidAppointmentDate(appointment.AppointmentDate))
            {
                throw new ArgumentException("Appointmenti minimum 3 gün öncesinde alabilirsiniz!");
            }


            if (!IsValidDoctor(appointment.DoctorId))
            {
                throw new ArgumentException("Geçerli bir doktor olmalı.");
            }

            // Doktorun randevu sayıvalidasyonu
            if (HasReachedMaxAppointments(appointment.DoctorId))
            {
                throw new InvalidOperationException("Bir Doktor en fazla 10 randevu alabilir!");
            }

            Appointment addAppointment = _appointmentRepository.Add(appointment);
            return addAppointment;
        }

        // APPOİNTMENT VALİDASYONU KONTROL EDEN KOD LAR AŞAĞIDA
        private bool IsValidAppointmentDate(DateTime appointmentDate)
        {
            DateTime minimumDate = DateTime.Today.AddDays(3);
            return appointmentDate.Date >= minimumDate;
        }

        private bool IsValidDoctor(int doctorId)
        {
            return doctorId > 0; // DOKTOR KONTROLÜ  NASIL YAPILIR AKLIMA GELMEDİ
        }
        // Doktorun randevu sayısını kontrol eden fonksiyon
        private bool HasReachedMaxAppointments(int doctorId)
        {
            var doctorAppointments = _appointmentRepository.GetAll()
                .Where(a => a.DoctorId == doctorId)
                .Count();

            return doctorAppointments >= 10;
        }

        public void DeleteExpiredAppointments()
        {
            // Geçmiş tarihli randevuları alıyoruz KESİNLİKLE GPT DEN ÇALMADIM
            var expiredAppointments = _appointmentRepository
                .GetAll()
                .Where(a => a.AppointmentDate < DateTime.Now)
                .ToList();

            // Geçmiş randevuları veritabanından siliyoruz
            foreach (var appointment in expiredAppointments)
            {
                _appointmentRepository.Delete(appointment.Id);
            }
        }

        public Appointment Delete(int id)
        {
            Appointment appointment = _appointmentRepository.Delete(id);
            return appointment;
        }

       


        public List<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll().ToList();
        }

        public Appointment GetById(int id)
        {
           Appointment appointment = _appointmentRepository.GetById(id);
            return appointment;
        }

        public Appointment Update(Appointment appointment)
        {
            Appointment updated = _appointmentRepository.Update(appointment);
            return updated;
        }
    }
}
