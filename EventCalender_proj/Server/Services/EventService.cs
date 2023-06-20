using EventCalender_proj.Client.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventCalender_proj.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventCalender_proj.Server.Services
{
    public interface IEventService// Define the namespace for the services
    {
        
        Task<EventClass> GetEventClassAsync(int id);// Interface for the event service with a method to retrieve an event by ID asynchronously
        Task<List<EventClass>> GetEventsAsync();// Interface for the event service with a method to retrieve multiple events asynchronously
        Task<EventClass> InsertEventAsync(EventClass eventInsertId); // New method to insert an event

    }

    public class EventService : IEventService
    {
        private List<EventClass> Events; // List to store events

        public EventService()
        {
            // Initialize the Events list with some sample data
            Events = new List<EventClass>()
            {
                 new EventClass() {Id = 1, DateTime = DateTime.Now, Name = "event1", Description = "birthday party"},
                 new EventClass() {Id = 2, DateTime = DateTime.Now, Name = "event2", Description = " party"},
                 new EventClass() {Id = 3, DateTime = DateTime.Now, Name = "event3", Description = "Graduation"},
                 new EventClass() {Id = 4, DateTime = DateTime.Now, Name = "event4", Description = "holiday"},
            };
        }


        // Implementation of the GetEventClassAsync method from the interface
        public Task<EventClass> GetEventClassAsync(int id)
        {
            // Find the event with the specified ID in the Events list
            var Event = Events.Find(x => x.Id == id);

            // For a better simulation of asynchronous behavior, you might want to add a delay with Task.Delay.
            // However, it's not mandatory and can be left out depending on your needs.

            // Return the event asynchronously by wrapping it in a completed Task using Task.FromResult
            return Task.FromResult(Event);
        }

        // New method to retrieve multiple events
        public Task<List<EventClass>> GetEventsAsync()
        {
            // Return all the events from the Events list
            return Task.FromResult(Events);
        }

        // New method to retrieve inserting an event
        public Task<EventClass> InsertEventAsync(EventClass eventInsertId)
        {
            eventInsertId.Id = GetNewEventId(); // Generate a new ID for the event, if needed
            Events.Add(eventInsertId); // Add the event to the Events list

            // Return the inserted event asynchronously
            return Task.FromResult(eventInsertId);
        }
        private int GetNewEventId()
        {
            int maxId = Events.Max(e => e.Id); // Get the maximum ID from the existing events
            int newId = maxId + 1; // Generate a new ID by incrementing the maximum ID

            return newId;
        }

    }
}

