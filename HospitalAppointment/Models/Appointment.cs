namespace HospitalAppointment.Models;

public class Appointment : Entity
{
    public Guid Id { get; set; }
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}
