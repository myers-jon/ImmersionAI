using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ImmersionAI.API.api.Models;

namespace ImmersionAI.API.api.Repositories
{
    public interface IUserRepository
    {
        Task<UserProfile> GetProfileAsync(Guid userId);
        Task<IEnumerable<UserProfile>> GetActiveUsersAsync();
        Task AddVocabWordAsync(VocabWord word);
        Task AddChatTurnAsync(ChatTurn turn);
    }
    

}
