using System;
using System.Threading;
using System.Threading.Tasks;
using ImmersionAI.API.api.Repositories;
using Microsoft.Extensions.Hosting;

namespace ImmersionAI.API.api.Services
{
    public class ContextRefreshWorker : BackgroundService
    {
        private readonly IContextService _contextService;
        private readonly IUserRepository _repo;

        public ContextRefreshWorker(
            IContextService contextService,
            IUserRepository repo)
        {
            _contextService = contextService;
            _repo = repo;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var users = await _repo.GetActiveUsersAsync();
                foreach (var u in users)
                {
                    await _contextService.CalculateAndPersistAsync(u.Id);
                }
                await Task.Delay(TimeSpan.FromMinutes(1),
                                stoppingToken);
            }
        }
    }
}
