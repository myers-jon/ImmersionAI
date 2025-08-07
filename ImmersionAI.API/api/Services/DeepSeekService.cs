using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ImmersionAI.API.api.Services
{
    public interface IDeepSeekService
    {
        Task<string> QueryModelAsync(string prompt);
    }

    public class DeepSeekService : IDeepSeekService
    {
        private readonly HttpClient _httpClient;
        public DeepSeekService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<string> QueryModelAsync(string prompt)
        {
            var request = new
            {
                model = "gpt-oss:20b", //"deepseek-r1",//"deepseek-r1:1.5b",//"gemma3:1b", phi4-mini
                /*"llama3-chatqa:8b" - very good, asks what can help me with though
                 * command-r slow but good conversation, long. 
                 solar - takes too long, leaves notes at the end
                 */
                prompt = prompt,
                stream = false,
                think = false
            };

            var content = new StringContent(
                JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

            _httpClient.Timeout = new TimeSpan(0, 5, 0);
            var response = await _httpClient.PostAsync("", content);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            // Example: handle the actual response structure
            dynamic result = JsonConvert.DeserializeObject(body);
            return result.response ?? "";
        }
    }
}
