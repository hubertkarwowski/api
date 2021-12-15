using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
namespace api.Controllers;
[ApiController]
[Route("[controller]")]

public class PatientController : ControllerBase
{
    private readonly IEventService eventService;
    public PatientController(IEventService eventService)
    {
        this.eventService = eventService;
    }

    [HttpGet]
    public ActionResult<List<Event>> GetAll(string? mood)
    {
        if (mood != null)
        {
            return this.eventService.GetAll().FindAll(pacient => pacient.mood == mood);
        }
        return this.eventService.GetAll();
    }

    [HttpPost]
    public ActionResult<CreateEventResponse> Create(Event _event)
    {   var zmienna = this.eventService.Add(_event);
        Console.WriteLine(zmienna.ToString());
        return zmienna;
    }


    [HttpGet("{id}")]
    public ActionResult<Event> Get(string id)
    {
        var patient = this.eventService.Get(id);
        if (patient == null)
            return NotFound();
        return patient;
    }

    
}