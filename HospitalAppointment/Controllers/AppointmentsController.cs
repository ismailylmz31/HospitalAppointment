using HospitalAppointment.Models;
using HospitalAppointment.Models.DTO;
using HospitalAppointment.Models.DTO.Response;
using HospitalAppointment.Services.Abstracts;
using HospitalAppointment.Services.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private IAppointmentService _appointmentsService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentsService = appointmentService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var appointments = _appointmentsService.GetAllAppointments();
        var appointmentDtos = appointments.Select(a => (AppointmentResponseDto)a).ToList();
        return Ok(appointmentDtos);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var appointment = _appointmentsService.GetById(id);
        if (appointment == null)
        {
            return NotFound();
        }

        var appointmentDto = (AppointmentResponseDto)appointment;
        return Ok(appointmentDto);
    }


    [HttpPost("add")]
    public IActionResult Add(AppointmentDto appointmentDto)
    {
        var result = _appointmentsService.Add(appointmentDto);
        var appointmentResponseDto = (AppointmentResponseDto)result;
        return Ok(appointmentResponseDto);
    }


    [HttpDelete("delete")]
    public IActionResult Delete(int id)
    {
        var result = _appointmentsService.Delete(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update(Appointment appointment)
    {
        var result = _appointmentsService.Update(appointment);
        return Ok(result);

    }



}
