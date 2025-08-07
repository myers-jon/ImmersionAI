using System;


namespace ImmersionAI.API.api.Models
{
    public class VocabWord
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Word { get; set; }
        public bool IsMastered { get; set; }
        public string GrammarPattern { get; set; }
    }
    

}
