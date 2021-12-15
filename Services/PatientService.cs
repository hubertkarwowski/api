using api.Models;

namespace api.Services;

public sealed class EventService : IEventService
{


    public static List<Event> Events { get; } = new List<Event>
        {
            new Event {id=Guid.NewGuid().ToString(), event_type= "mood_observation", timestamp=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss zzz"), caregiver_id="4786d616-259e-4d52-80f7-8cf7dc6d881a", mood="okay"},
            new Event {id=Guid.NewGuid().ToString(), event_type= "mood_observation", timestamp=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss zzz"), caregiver_id="4786d616-259e-4d52-80f7-8cf7dc6d881a", mood="not_okay"}
        };

    public EventService()
    {

    }

    public List<Event> GetAll()
    {
        return Events;
    }

    public Event? Get(string id) => Events.Find(p => p.id == id);

    public CreateEventResponse Add(Event _event)
    {
        _event.id = Guid.NewGuid().ToString();
        Events.Add(_event);
        return new CreateEventResponse(_event.id);
    }
}