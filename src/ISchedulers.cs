using System.Threading.Tasks;

namespace Rsam70.Concurrency.Schedulers
{
    /// <summary>
    /// Defines the schedule interface for functions that return a Task<TResult>
    /// or a Task<Task<TResult>> and type void
    /// </summary
    public interface IScheduler : ISchedulerResult, ISchedulerVoid
    {
        /// <summary>
        /// Returns the taskscheduler currently in use.
        /// </summary>
        TaskScheduler TaskScheduler { get; }
    }
}
