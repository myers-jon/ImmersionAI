//using ImmersionAI.API.api.Models;
//using ImmersionAI.API.api.Data;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ImmersionAI.API.api.Repositories
//{
//    public class UserRepository : IUserRepository
//    {
//        private readonly ImmersionDbContext _db;
//        public UserRepository(ImmersionDbContext db) => _db = db;

//        public async Task<UserProfile> GetProfileAsync(Guid userId)
//        {
//            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userId);
//            if (user == null) return null;

//            var profile = new UserProfile
//            {
//                Id = user.Id,
//                Username = user.Username,
//                ProficiencyLevel = user.ProficiencyLevel,
//                MasteredWords = await _db.Set<VocabWord>().Where(v => v.UserId == userId && v.IsMastered).ToListAsync(),
//                ChatHistory = await _db.ChatTurns.Where(c => c.UserId == userId).OrderBy(c => c.Timestamp).ToListAsync(),
//                CreatedAt = user.CreatedAt
//            };
//            return profile;
//        }

//        public async Task<IEnumerable<UserProfile>> GetActiveUsersAsync()
//        {
//            var oneHourAgo = DateTime.UtcNow.AddHours(-1);
//            var activeUserIds = await _db.ChatTurns
//                .Where(c => c.Timestamp > oneHourAgo)
//                .Select(c => c.UserId)
//                .Distinct()
//                .ToListAsync();

//            var users = await _db.Users.Where(u => activeUserIds.Contains(u.Id)).ToListAsync();
//            return users.Select(u => new UserProfile
//            {
//                Id = u.Id,
//                Username = u.Username,
//                ProficiencyLevel = u.ProficiencyLevel,
//                CreatedAt = u.CreatedAt
//            });
//        }

//        public async Task AddVocabWordAsync(VocabWord word)
//        {
//            _db.Set<VocabWord>().Add(word);
//            await _db.SaveChangesAsync();
//        }

//        public async Task AddChatTurnAsync(ChatTurn turn)
//        {
//            _db.ChatTurns.Add(turn);
//            await _db.SaveChangesAsync();
//        }
//    }
//}
//// This code defines a UserRepository class that implements IUserRepository interface.