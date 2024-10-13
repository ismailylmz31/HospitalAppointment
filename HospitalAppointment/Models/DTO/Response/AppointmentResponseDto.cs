namespace HospitalAppointment.Models.DTO.Response;

public class AppointmentResponseDto
{
    public string PatientName { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string DoctorName { get; set; }

    public static implicit operator AppointmentResponseDto(Appointment appointment)
    {
        return new AppointmentResponseDto
        {
            PatientName = appointment.PatientName,
            AppointmentDate = appointment.AppointmentDate,
            DoctorName = appointment.Doctor?.Name
        };
    }
}