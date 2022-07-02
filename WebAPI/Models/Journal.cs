using System;

namespace WebApi.Models
{
    public class Journal
    {
        public Journal()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Today;
        }
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime Date { get; set; }
        public bool Attedance { get; set; }
    }
}
