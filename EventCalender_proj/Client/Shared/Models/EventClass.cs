namespace EventCalender_proj.Client.Shared.Models
{
    public class EventClass
    {
        public int Id { get; set; }
        public DateTime? DateTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Year => DateTime?.Year ??0;
        public int Month => DateTime?.Month??0;


    }

}
