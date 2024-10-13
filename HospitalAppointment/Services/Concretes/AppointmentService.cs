using HospitalAppointment.Models;
using HospitalAppointment.Models.DTO;
using HospitalAppointment.Repository.Abstracts;
using HospitalAppointment.ReturnModel;
using HospitalAppointment.Services.Abstracts;

namespace HospitalAppointment.Services.Concretes
{
    public class AppointmentService : IAppointmentService
    {

        private IAppointmentRepository _appointmentRepository;
        private IDoctorService _doctorService;

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorService doctorService)
        {
            _appointmentRepository = appointmentRepository;
            _doctorService = doctorService;
        }

        public ReturnModel<Appointment> Add(AppointmentDto appointmentDto)
        {
            // Tarih validasyonunu yapıyoruz
            
            if (!IsValidAppointmentDate(appointmentDto.AppointmentDate))
            {
                return new ReturnModel<Appointment>
                {
                    Data = null,
                    Success = false,
                    Message = "En az 3 gün sonrasına randevu alabilirsiniz."
                };
            }

            
            if (!IsValidDoctor(appointmentDto.DoctorId))
            {
                return new ReturnModel<Appointment>
                {
                    Data = null,
                    Success = false,
                    Message = "Geçerli bir doktor olmalı."
                };
            }
            // Doktorun randevu sayıvalidasyonu
            if (HasReachedMaxAppointments(appointmentDto.DoctorId))
            {
                return new ReturnModel<Appointment>
                {
                    Data = null,
                    Success = false,
                    Message = "Bu doktor için en fazla 10 randevu oluşturulabilir."
                };
            }

            if (appointmentDto.PatientName is null || appointmentDto.PatientName == "")
            {
                return new ReturnModel<Appointment>
                {
                    Data = null,
                    Success = false,
                    Message = "Hasta isim alanı boş bırakılamaz."
                };
            }

            var appointment = new Appointment
            {
                PatientName = appointmentDto.PatientName,
                AppointmentDate = appointmentDto.AppointmentDate,
                DoctorId = appointmentDto.DoctorId
            };

            return new ReturnModel<Appointment>
            {

                Data = _appointmentRepository.Add(appointment),
                Success = true,
                Message = "Randevu başarıyla oluşturuldu."
            };

            

            
            
        }

        // APPOİNTMENT VALİDASYONU KONTROL EDEN KOD LAR AŞAĞIDA
        private bool IsValidAppointmentDate(DateTime appointmentDate)
        {
            DateTime minimumDate = DateTime.Today.AddDays(3);
            return appointmentDate.Date >= minimumDate;
        }

        private bool IsValidDoctor(int doctorId)
        {
            var doctor = _doctorService.GetById(doctorId);
            return doctor != null; // DOKTOR KONTROLÜ  NASIL YAPILIR AKLIMA GELMEDİ
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
