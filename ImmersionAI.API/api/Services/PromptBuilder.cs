//using ImmersionAI.API.api.Data;
using ImmersionAI.API.api.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImmersionAI.API.api.Services
{
    public class PromptBuilder
    {
        //private readonly ImmersionDbContext _db;
        private readonly string _staticEnglishPrompt;
        private readonly string _staticSpanishPrompt;
        private readonly string _personalityPrompt;

        public PromptBuilder()
        {
            //_db = db;
            _staticEnglishPrompt = File.ReadAllText("api/SystemPromptEnglish.txt");
            _staticSpanishPrompt = File.ReadAllText("api/SystemPromptSpanish.txt");
            _personalityPrompt = File.ReadAllText("api/Personality.txt");
        }

        public async Task<string> BuildAsync(Guid userId, string userMessage, string[] chatHistory)
        {
            //// 1. Load latest InstructionPayload JSON (adapt this to your actual context storage)
            //var payloadEntity = await _db.InstructionPayloads
            //    .Where(c => c.UserId == userId && c.SessionId == sessionId)
            //    .OrderByDescending(c => c.CreatedAt)
            //    .FirstOrDefaultAsync();

            //var payloadJson = payloadEntity?.PayloadJson
            //    ?? JsonConvert.SerializeObject(new InstructionPayload());

            //// 2. Load last 10 chat turns
            //var turns = await _db.ChatTurns
            //    .Where(c => c.UserId == userId && c.SessionId == sessionId)
            //    .OrderBy(c => c.Timestamp)
            //    .Take(10)
            //    .ToListAsync();

            // 3. Assemble the prompt
            string prompt =  $@"{_staticSpanishPrompt}
User's Current Spanish Comprehension (CEFR) is A2.

Your Personality/Identity: {_personalityPrompt}

Previous Conversation Messages:
{JsonConvert.SerializeObject(chatHistory, Formatting.Indented)}

User's Current Message: {userMessage}

Generate a 1 sentence reply in natural conversation tone according to the above instructions. 

";
            return prompt;
        }
    }
}
