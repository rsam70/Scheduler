
using System;
using System.Threading.Tasks;

namespace Rsam70.Concurrency.Schedulers
{
    /// <summary>
    /// Defines the schedule interface for functions that return a Task<TResult>
    /// or a Task<Task<TResult>>
    /// </summary
    public interface ISchedulerResult
    {
        #region Scheduled function generation returning result Task<TResult>
        /// Function generation returning result Task<TResult>
        Task<TResult> Schedule<TResult>(Func<TResult> func);
        Task<TResult> Schedule<R,TResult>(Func<R,TResult> func,R r);
        Task<TResult> Schedule<R,S,TResult>(Func<R,S,TResult> func,R r,S s);
        Task<TResult> Schedule<R,S,T,TResult>(Func<R,S,T,TResult> func,R r,S s,T t);
        Task<TResult> Schedule<R,S,T,U,TResult>(Func<R,S,T,U,TResult> func,R r,S s,T t,U u);
        #endregion Scheduled function generation returning result Task<TResult>
        
        #region Scheduled function generation returning result Task<Task<TResult>>
        /// Function generation returning result Task<TResult>
        Task<TResult> Schedule<TResult>(Func<Task<TResult>> func);
        Task<TResult> Schedule<R,TResult>(Func<R,Task<TResult>> func,R r);
        Task<TResult> Schedule<R,S,TResult>(Func<R,S,Task<TResult>> func,R r,S s);
        Task<TResult> Schedule<R,S,T,TResult>(Func<R,S,T,Task<TResult>> func,R r,S s,T t);
        Task<TResult> Schedule<R,S,T,U,TResult>(Func<R,S,T,U,Task<TResult>> func,R r,S s,T t,U u);
        #endregion Scheduled function generation returning result Task<Task<TResult>>
    }
}
