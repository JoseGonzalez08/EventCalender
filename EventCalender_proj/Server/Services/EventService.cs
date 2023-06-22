using EventCalender_proj.Client.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventCalender_proj.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;
using System.Xml.Linq;

namespace EventCalender_proj.Server.Services
{
    public interface IEventService
{
    Task<EventClass> GetEventClassAsync(int id); // Interface method to retrieve an event by ID asynchronously
    Task<List<EventClass>> GetEventsAsync(); // Interface method to retrieve multiple events asynchronously
    Task<EventClass> InsertEventAsync(EventClass eventInsertId); // Interface method to insert an event asynchronously
    Task<EventClass> UpdateEventAsync(int id, EventClass updatedEvent); // Interface method to update an event asynchronously
    Task<bool> DeleteEventAsync(int id); // Interface method to delete an event by ID asynchronously
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

    public Task<EventClass> GetEventClassAsync(int id)
    {
        var Event = Events.Find(x => x.Id == id); // Find the event with the specified ID in the Events list
        return Task.FromResult(Event); // Return the event asynchronously
    }

    public Task<List<EventClass>> GetEventsAsync()
    {
        return Task.FromResult(Events); // Return all the events from the Events list asynchronously
    }

    public Task<EventClass> InsertEventAsync(EventClass eventInsertId)
    {
        eventInsertId.Id = GetNewEventId(); // Generate a new ID for the event, if needed
        Events.Add(eventInsertId); // Add the event to the Events list
        return Task.FromResult(eventInsertId); // Return the inserted event asynchronously
    }

    private int GetNewEventId()
    {
        int maxId = Events.Max(e => e.Id); // Get the maximum ID from the existing events
        int newId = maxId + 1; // Generate a new ID by incrementing the maximum ID
        return newId; // Return the new ID
    }

    public async Task<EventClass> UpdateEventAsync(int id, EventClass updatedEvent)
    {
        var existingEvent = await GetEventClassAsync(id); // Find the existing event

        if (existingEvent == null) // If the event with the specified ID doesn't exist, return null
        {
            return null;
        }

        // Update the properties of the existing event
        existingEvent.Name = updatedEvent.Name;
        existingEvent.Description = updatedEvent.Description;
        existingEvent.DateTime = updatedEvent.DateTime; // Update the DateTime property

        return updatedEvent; // Return the updated event
    }

    public async Task<bool> DeleteEventAsync(int id)
    {
        var deleteEvent = await GetEventClassAsync(id); // Find the existing event

        if (deleteEvent != null)
        {
            Events.Remove(deleteEvent); // Remove the event from the Events list
            return true; // Return true if deletion was successful
        }

        return false; // Return false if the event was not found
    }
}


