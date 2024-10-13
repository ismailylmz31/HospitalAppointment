using HospitalAppointment.Models;
using HospitalAppointment.Models.DTO;
using HospitalAppointment.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointment.Controllers;



[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private IDoctorService _doctorService;
    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _doctorService.GetAllDoctors();
        return Ok(result);
    }

    [HttpGet("getbyıd")]
    public IActionResult GetById(int id) { 
        var result = _doctorService.GetById(id);
        return Ok(result);
    }


    [HttpPost("add")]
    public IActionResult Add(DoctorDto doctorDto)
    {
        var doctor = new Doctor
        {
            Name = doctorDto.Name,
            Patients = new List<Appointment>(), 
        };

        var result = _doctorService.Add(doctor);
        return Ok(result);
    }



    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        var result = _doctorService.Delete(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(Doctor doctor)
    {
        var result = _doctorService.Update(doctor);
        return Ok(result);

    }



}
