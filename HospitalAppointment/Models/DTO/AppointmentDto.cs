namespace HospitalAppointment.Models.DTO
{
    public class AppointmentDto
    {
          public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int DoctorId { get; set; }
    }
}
