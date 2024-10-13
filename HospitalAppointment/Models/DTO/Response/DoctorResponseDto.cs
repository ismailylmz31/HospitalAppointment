namespace HospitalAppointment.Models.DTO.Response;
    public class DoctorResponseDto
    {
    public string Name { get; set; }
    public string Branch { get; set; }
    public List<string> PatientsNames { get; set; }

    public static implicit operator DoctorResponseDto(Doctor doctor)
    {
        return new DoctorResponseDto
        {
            Name = doctor.Name,
            Branch = doctor.Branch.ToString(),
            PatientsNames = doctor.Patients.Select(x => x.PatientName).ToList()
        };
    }
    }

