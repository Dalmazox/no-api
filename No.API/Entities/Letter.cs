using System;

namespace No.API.Entities
{
    public class Letter
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; }
        public DateTime WritedAt { get; set; } = DateTime.Now;
    }
}