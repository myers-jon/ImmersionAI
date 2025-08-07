using System;
using System.Linq;
using System.Threading.Tasks;
using ImmersionAI.API.api.Models;
using ImmersionAI.API.api.Repositories;

namespace ImmersionAI.API.api.Services
{
    public interface IContextService
    {
        Task<UserProfile> GetLatestContextAsync(Guid userId);
        Task<UserProfile> CalculateAndPersistAsync(Guid userId);
    }

    public class ContextService : IContextService
    {
        //private readonly IUserRepository _repo;

        public async Task<UserProfile> GetLatestContextAsync(Guid userId)
        {
            //var profile = await _repo.GetProfileAsync(userId);
            //profile.ProficiencyLevel = Recalculate(profile);
            //return profile;
            return null;
        }

        public async Task<UserProfile> CalculateAndPersistAsync(Guid userId)
        {
            //    var profile = await GetLatestContextAsync(userId);
            //    // Persist updated proficiency
            //    _repo.GetProfileAsync(userId).Wait();
            //    //await _repo.SaveChangesAsync();
            //    return profile;
            return null;
        }

        private string Recalculate(UserProfile p)
        {
            var mastered = p.MasteredWords.Count;
            if (mastered > 1000) return "B2";
            if (mastered > 500) return "B1";
            if (mastered > 200) return "A2";
            return "A1";
        }
    }
}
