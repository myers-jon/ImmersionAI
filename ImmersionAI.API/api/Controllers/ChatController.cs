using ImmersionAI.API.api.Helpers;
using ImmersionAI.API.api.Models;
using ImmersionAI.API.api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ImmersionAI.API.api.Controllers
{
    [ApiController]
    [Route("api")]
    public class ChatController : ControllerBase
    {
        private readonly PromptBuilder _pb;
        private readonly IDeepSeekService _ds;
        
        public ChatController(
            PromptBuilder pb,
            IDeepSeekService ds)
        {
            _pb = pb;
            _ds = ds;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChatRequest req)
        {
            if (req == null || string.IsNullOrWhiteSpace(req.Message))
                return BadRequest("Message is required.");

            var prompt = await _pb.BuildAsync(
                Guid.Empty, req.Message, MessageHolderTempSwitchToDB._messages.ToArray());

            var aiReply = await _ds.QueryModelAsync(prompt);

            MessageHolderTempSwitchToDB._messages.Add($"User: {req.Message}");
            MessageHolderTempSwitchToDB._messages.Add($"You: {aiReply}");

            return Ok(new ChatResponse
            {
                Reply = aiReply
            });
        }
    }

    public class ChatRequest
    {
        public string Message { get; set; }
    }

    public class ChatResponse
    {
        public string Reply { get; set; }
    }
}
