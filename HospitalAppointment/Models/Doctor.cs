namespace HospitalAppointment.Models;

public sealed class Doctor : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public enum Branch
    {
        Cardiology,
        Neurology,
        Orthopedics,
        Pediatrics,
        General
    }
    public List<Appointment> Patients { get; set; }
}
