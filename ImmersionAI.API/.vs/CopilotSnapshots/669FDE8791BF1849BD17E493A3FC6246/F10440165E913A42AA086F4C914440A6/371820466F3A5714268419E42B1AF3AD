namespace ImmersionAI.API.api.Models
{
    public class VocabComprehension
    {
        public List<string> Mastered { get; set; } = new();
        public List<string> InProgress { get; set; } = new();
        public List<string> NewlyIntroduced { get; set; } = new();
    }

    public class GrammarPatterns
    {
        public List<string> ReinforcedPatterns { get; set; } = new();
        public List<string> NewPatternsIntroduced { get; set; } = new();
    }

    public class UserFacts
    {
        public List<string> Interests { get; set; } = new();
        public string LanguageGoals { get; set; } = "";
        public string CurrentProficiency { get; set; } = "";
    }

    public class ComprehensionFeedback
    {
        public List<string> VocabReuseDetected { get; set; } = new();
        public List<string> GrammaticalErrorsDetected { get; set; } = new();
        public string SuggestedFocusArea { get; set; } = "";
    }

    public class InstructionPayload
    {
        public VocabComprehension VocabComprehension { get; set; } = new();
        public GrammarPatterns GrammarPatterns { get; set; } = new();
        public UserFacts UserFacts { get; set; } = new();
        public List<string> RequestedVocabAdditions { get; set; } = new();
        public ComprehensionFeedback ComprehensionFeedback { get; set; } = new();
    }
}
