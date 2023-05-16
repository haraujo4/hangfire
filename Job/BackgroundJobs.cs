using FluentResults;
using hagnfireJob.Interface.Services;
using Hangfire;
using Microsoft.AspNetCore.Http.HttpResults;

namespace hagnfireJob.Job
{
    public class BackgroundJobs
    {
        private readonly IUserServices _services;
        public BackgroundJobs(IUserServices services)
        {
            _services = services;
        }
        [Queue("jobs")]
        public void MeuMetodoEmSegundoPlano()
        {
            RecurringJob.AddOrUpdate<BackgroundJobs>(x => x.DeleteUsuarios(), Cron.MinuteInterval(1));
        }
        public async Task<Result> DeleteUsuarios()
        {
            return await _services.DeleteAll();
        }

    }
}
