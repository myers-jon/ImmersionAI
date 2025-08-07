using System;
using System.Collections.Generic;

namespace ImmersionAI.API.api.Models
{
    public class UserProfile
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string ProficiencyLevel { get; set; }
        public List<VocabWord> MasteredWords { get; set; } = new();
        public List<string> Interests { get; set; } = new();
        public List<ChatTurn> ChatHistory { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
