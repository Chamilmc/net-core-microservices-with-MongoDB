using System;
using MongoDB.Bson;

namespace Actio.Common.Events
{
    public class ActivityCreated : IAuthenticatedEvent
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public ActivityCreated()
        {
            // No Implementation
        }

        public ActivityCreated(Guid id, Guid userId, string category, string name,string description,DateTime createdAt)
        {
            Id = id;
            UserId = userId;
            Category = category;
            Name = name;
            Description = description;
            CreatedAt=createdAt;
        }
    }
}
