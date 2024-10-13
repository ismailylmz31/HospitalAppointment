using HospitalAppointment.Models;
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
        var result = _appointmentsService.GetAllAppointments();
        return Ok(result);
    }

    [HttpGet("getbyıd")]
    public IActionResult GetById(int id)
    {
        var result = _appointmentsService.GetById(id);
        return Ok(result);
    }


    [HttpPost("add")]
    public IActionResult Add(Appointment appointment)
    {
        var result = _appointmentsService.Add(appointment);
        return Ok(result);
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
