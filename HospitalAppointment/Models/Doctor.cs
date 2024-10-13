using System.Text.Json.Serialization;

namespace HospitalAppointment.Models;

public enum Branch
{
    Cardiology,
    Neurology,
    Orthopedics,
    Pediatrics,
    General
}
public sealed class Doctor : Entity
{
    public int Id { get; set; }
    public string Name { get; set; }

    
    public Branch Branch { get; set; }

    // Nullable ICollection ile randevu listesi
    [JsonIgnore]
    public List<Appointment> Patients { get; set; }
    public Doctor()
    {
        Patients = new List<Appointment>();
    }

}
