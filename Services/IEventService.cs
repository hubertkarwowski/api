using api.Models;

namespace api.Services;

public interface IEventService
{
     List<Event> GetAll();

     Event? Get(string id);
    
    CreateEventResponse Add(Event _event);
    
}