
using System;
using System.Threading.Tasks;

namespace Rsam70.Concurrency.Schedulers
{
    /// <summary>
    /// Defines the schedule interface for functions that return a Task
    /// or a Task<Task>
    /// </summary
    public interface ISchedulerVoid
    {     
        #region Scheduled action generation returning result Task
        Task Schedule(Action action);
        Task Schedule<R>(Action<R> action,R r);
        Task Schedule<R,S>(Action<R,S> action,R r,S s);
        Task Schedule<R,S,T>(Action<R,S,T> action,R r,S s,T t);
        Task Schedule<R,S,T,U>(Action<R,S,T,U> action,R r,S s,T t,U u);
        #endregion Scheduled action generation returning result Task

        #region Scheduled function generation returning result Task<Task>
        /// Function returning a Task
        Task Schedule(Func<Task> func);
        Task Schedule<R>(Func<R,Task> func,R r);
        Task Schedule<R,S>(Func<R,S,Task> func,R r,S s);
        Task Schedule<R,S,T>(Func<R,S,T,Task> func,R r,S s,T t);
        Task Schedule<R,S,T,U>(Func<R,S,T,U,Task> func,R r,S s,T t,U u);
        #endregion /// Scheduled function generation returning result Task
    }
}
