using System.Threading.Tasks;
using EventCalender_proj.Client.Shared.Models;
using EventCalender_proj.Server.Services;
using EventCalender_proj.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventCalender_proj.Server.Controllers
{
    // Define the namespace for the controller
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private bool result;

        // Constructor injection: The controller requires an implementation of IEventService
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // HTTP GET endpoint to retrieve a specific event by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EventClass>> GetEvent(int id)
        {
            // Call the GetEventClassAsync method of the event service to retrieve the event
            var eventItem = await _eventService.GetEventClassAsync(id);

            // If the event is not found, return a 404 Not Found response
            if (eventItem == null)
            {
                return NotFound();
            }

            // Return the retrieved event
            return eventItem;
        }
        [HttpGet] // New HTTP GET endpoint to retrieve multiple events
        public async Task<ActionResult<List<EventClass>>> GetEvents()
        {
            var eventsitem2 = await _eventService.GetEventsAsync();

            if (eventsitem2 == null)
            {
                return NotFound();
            }

            return eventsitem2;
        }
       // [Route("InsertEvent")]
        [HttpPost] // HTTP POST endpoint to insert an event
        public async Task<ActionResult<EventClass>> InsertEvent(EventClass eventInsertId)
        {
            var insertedEvent = await _eventService.InsertEventAsync(eventInsertId);

            // Return the inserted event
            return insertedEvent;
        }
        [HttpPut("{id}")] // HTTP PUT endpoint to update an event by ID
        public async Task<ActionResult<EventClass>> UpdateEvent(int id, EventClass updatedEvent)
        {
            var UpdatedEvent = await _eventService.UpdateEventAsync(id, updatedEvent);

            // If the event with the specified ID doesn't exist, return a 404 Not Found response
            if (updatedEvent == null)
            {
                return NotFound();
            }

            // Return the updated event
            return updatedEvent;
        }
        [HttpDelete("{id}")] // HTTP PUT endpoint to update an event by ID
        public async Task<ActionResult<EventClass>> DeleteEvent(int id)
        {
            var deleteEvent = await _eventService.DeleteEventAsync(id);

            if (deleteEvent)
            {
                return Ok(true); // Return true if the event is successfully deleted
            }

            return NotFound(); // Return a 404 Not Found response if the event is not found
        }
        // and deleting an event can be added here
    }
}

