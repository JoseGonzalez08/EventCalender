using EventCalender_proj.Client.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventCalender_proj.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;

namespace EventCalender_proj.Server.Services
{
    public interface IEventService// Define the namespace for the services
    {
        
        Task<EventClass> GetEventClassAsync(int id);// Interface for the event service with a method to retrieve an event by ID asynchronously
        Task<List<EventClass>> GetEventsAsync();// Interface for the event service with a method to retrieve multiple events asynchronously
        Task<EventClass> InsertEventAsync(EventClass eventInsertId); // New method to insert an event
        Task<EventClass> UpdateEventAsync(int id, EventClass updatedEvent); // Method to update an event asynchronously
        Task<bool> DeleteEventAsync(int id); // Method to delete an event by ID asynchronously

    }


}

    public class EventService : IEventService
    {
        private List<EventClass> Events; // List to store events

        public EventService()
        {
            // Initialize the Events list with some sample data
            Events = new List<EventClass>()
            {
                new EventClass() {Id = 1, DateTime = new DateTime(DateTime.Now.Year, 6, 1), Name = "event1", Description = "birthday party"},
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
        public async Task<EventClass> UpdateEventAsync(int id, EventClass updatedEvent)
        {
            var existingEvent = await GetEventClassAsync(id);// Find the existing event

            // If the event with the specified ID doesn't exist, return null
            if (existingEvent == null)
            {
                return null;
            }

            // Update the properties of the existing event
            existingEvent.Name = updatedEvent.Name;
            existingEvent.Description = updatedEvent.Description;

            // Add this line to update the DateTime property
            existingEvent.DateTime = updatedEvent.DateTime;

            // Return the updated event
            return updatedEvent;
        }
        public async Task<bool> DeleteEventAsync(int id)
        {
        var deleteEvent = await GetEventClassAsync(id); ; //Find the Existing event

            // If the event with the specified ID doesn't exist, return null
            if (deleteEvent != null)
            {
                Events.Remove(deleteEvent);//remove the events from the Events list 
                return true; //return true if deletion was successful
            }   
            return false; //return false if the even was not found
            

        }
}


