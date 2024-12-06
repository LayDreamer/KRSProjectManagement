using MMS.DataManager.Jobs;

namespace MMS.DataManager.Extensions.Hangfire
{
    public static class RecurringJobsExtensions
    {
        public static void CreateRecurringJob(this ApplicationInitializationContext context)
        {
            RecurringJob.AddOrUpdate<TestJob>("测试Job", e => e.ExecuteAsync(), CronType.Minute(1), new RecurringJobOptions()
            {
                TimeZone = TimeZoneInfo.Local
            });
        }
    }
}