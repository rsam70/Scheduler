
using System;
using System.Threading.Tasks;

namespace Rsam70.Concurrency.Schedulers
{
    /// <summary>
    /// Wrapper of task schedules. All parameters
    /// provided are captured when called.
    /// </summary> 
    public class Scheduler:IScheduler
    {     
        /// <summary>
        /// Defines the default scheduler for this particular implementation. All tasks are scheduled
        /// on a single thread of execution.
        /// </summary>
        private readonly TaskScheduler scheduler;

        /// <summary>
        /// Returns the current task scheduler
        /// </summary>
        public TaskScheduler TaskScheduler => scheduler;

        #region c'tor
        /// <summary>
        /// Define a custom scheduler for these tasks. This will serve as the default schedular instance
        /// </summary>
        public Scheduler(TaskScheduler s)
        {   
            scheduler = s;
        }

        /// <summary>
        /// Creates an exclusive scheduler. All action scheduled on this instance will execute synchronously.
        /// </summary>
        public static IScheduler CreateExclusiveScheduler() => new Scheduler(new ConcurrentExclusiveSchedulerPair().ExclusiveScheduler);

        /// <summary>
        /// Creates a concurrent scheduler. All action scheduled on this instance will execute in parallel.
        /// </summary>
        public static IScheduler CreateConcurrentScheduler() => new Scheduler(new ConcurrentExclusiveSchedulerPair().ConcurrentScheduler);

        #endregion

        #region Scheduled action generation returning result Task
        public Task Schedule(Action action)
        {
            var tsk = new Task(action);
            tsk.Start(scheduler);
            return tsk;
        }

        public Task Schedule<R>(Action<R> action,R r)
        {
            var tsk = new Task((p)=>action((R)p),r);
            tsk.Start(scheduler);
            return tsk;
        }
        public Task Schedule<R,S>(Action<R,S> action,R r,S s)
        {
            var tpl = Tuple.Create(r,s);
            var tsk = new Task((p)=>
            {
                var tmp =(Tuple<R,S>)p; 
                action(tmp.Item1,tmp.Item2);
            },tpl);
            tsk.Start(scheduler);
            return tsk;
        }

        public Task Schedule<R,S,T>(Action<R,S,T> action,R r,S s,T t)
        {
            var tpl = Tuple.Create(r,s,t);
            var tsk = new Task((p)=>
            {
                var tmp =(Tuple<R,S,T>)p; 
                action(tmp.Item1,tmp.Item2,tmp.Item3);
            },tpl);
            tsk.Start(scheduler);
            return tsk;
        }

        public Task Schedule<R,S,T,U>(Action<R,S,T,U> action,R r,S s,T t,U u)
        {
            var tpl = Tuple.Create(r,s,t,u);
            var tsk = new Task((p)=>
            {
                var tmp =(Tuple<R,S,T,U>)p; 
                action(tmp.Item1,tmp.Item2,tmp.Item3,tmp.Item4);
            },tpl);
            tsk.Start(scheduler);
            return tsk;
        }

        public Task Schedule<R,S,T,U,V>(Action<R,S,T,U,V> action,R r,S s,T t,U u,V v)
        {
            var tpl = Tuple.Create(r,s,t,u,v);
            var tsk = new Task((p)=>
            {
                var tmp =(Tuple<R,S,T,U,V>)p; 
                action(tmp.Item1,tmp.Item2,tmp.Item3,tmp.Item4,tmp.Item5);
            },tpl);
            tsk.Start(scheduler);
            return tsk;
        }

        #endregion Scheduled action generation returning result Task

        #region Scheduled function generation returning result Task<Task>
        /// Function returning a Task
        public Task Schedule(Func<Task> func)
        {
            var tsk = new Task<Task>(func);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        public Task Schedule<R>(Func<R,Task> func,R r)
        {
   
            var tsk = new Task<Task>((p)=>func((R)p),r);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        public Task Schedule<R,S>(Func<R,S,Task> func,R r,S s)
        {
            var tpl = Tuple.Create(r,s);
            var tsk = new Task<Task>((p)=>
            {
                var tmp =(Tuple<R,S>)p; 
                return func(tmp.Item1,tmp.Item2);
            },tpl);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        public Task Schedule<R,S,T>(Func<R,S,T,Task> func,R r,S s,T t)
        {
            var tpl = Tuple.Create(r,s,t);
            var tsk = new Task<Task>((p)=>
            {
                var tmp =(Tuple<R,S,T>)p; 
                return func(tmp.Item1,tmp.Item2,tmp.Item3);
            },tpl);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        public Task Schedule<R,S,T,U>(Func<R,S,T,U,Task> func,R r,S s,T t,U u)
        {
            var tpl = Tuple.Create(r,s,t,u);
            var tsk = new Task<Task>((p)=>
            {
                var tmp =(Tuple<R,S,T,U>)p; 
                return func(tmp.Item1,tmp.Item2,tmp.Item3,tmp.Item4);
            },tpl);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        public Task Schedule<R,S,T,U,V>(Func<R,S,T,U,V,Task> func,R r,S s,T t,U u,V v)
        {
            var tpl = Tuple.Create(r,s,t,u,v);
            var tsk = new Task<Task>((p)=>
            {
                var tmp =(Tuple<R,S,T,U,V>)p; 
                return func(tmp.Item1,tmp.Item2,tmp.Item3,tmp.Item4,tmp.Item5);
            },tpl);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        #endregion /// Scheduled function generation returning result Task

        #region Scheduled function generation returning result Task<TResult>
        /// Function generation returning result Task<TResult>
        public Task<TResult> Schedule<TResult>(Func<TResult> func)
        {
            var tsk = new Task<TResult>(func);
            tsk.Start(scheduler);
            return tsk;
        }

        public Task<TResult> Schedule<R,TResult>(Func<R,TResult> func,R r)
        {
   
            var tsk = new Task<TResult>((p)=>func((R)p),r);
            tsk.Start(scheduler);
            return tsk;
        }

        public Task<TResult> Schedule<R,S,TResult>(Func<R,S,TResult> func,R r,S s)
        {
            var tpl = Tuple.Create(r,s);
            var tsk = new Task<TResult>((p)=>
            {
                var tmp =(Tuple<R,S>)p; 
                return func(tmp.Item1,tmp.Item2);
            },tpl);
            tsk.Start(scheduler);
            return tsk;
        }

        public Task<TResult> Schedule<R,S,T,TResult>(Func<R,S,T,TResult> func,R r,S s,T t)
        {
            var tpl = Tuple.Create(r,s,t);
            var tsk = new Task<TResult>((p)=>
            {
                var tmp =(Tuple<R,S,T>)p; 
                return func(tmp.Item1,tmp.Item2,tmp.Item3);
            },tpl);
            tsk.Start(scheduler);
            return tsk;
        }

        public Task<TResult> Schedule<R,S,T,U,TResult>(Func<R,S,T,U,TResult> func,R r,S s,T t,U u)
        {
            var tpl = Tuple.Create(r,s,t,u);
            var tsk = new Task<TResult>((p)=>
            {
                var tmp =(Tuple<R,S,T,U>)p; 
                return func(tmp.Item1,tmp.Item2,tmp.Item3,tmp.Item4);
            },tpl);
            tsk.Start(scheduler);
            return tsk;
        }

        public Task<TResult> Schedule<R,S,T,U,V,TResult>(Func<R,S,T,U,V,TResult> func,R r,S s,T t,U u,V v)
        {
            var tpl = Tuple.Create(r,s,t,u,v);
            var tsk = new Task<TResult>((p)=>
            {
                var tmp =(Tuple<R,S,T,U,V>)p; 
                return func(tmp.Item1,tmp.Item2,tmp.Item3,tmp.Item4,tmp.Item5);
            },tpl);
            tsk.Start(scheduler);
            return tsk;
        }

        #endregion Scheduled function generation returning result Task<TResult>
        
        #region Scheduled function generation returning result Task<Task<TResult>>
        /// Function generation returning result Task<TResult>
        public Task<TResult> Schedule<TResult>(Func<Task<TResult>> func)
        {
            var tsk = new Task<Task<TResult>>(func);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        public Task<TResult> Schedule<R,TResult>(Func<R,Task<TResult>> func,R r)
        {
          var tsk = new Task<Task<TResult>>((p)=>func((R)p),r);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        public Task<TResult> Schedule<R,S,TResult>(Func<R,S,Task<TResult>> func,R r,S s)
        {
            var tpl = Tuple.Create(r,s);
            var tsk = new Task<Task<TResult>>((p)=>
            {
                var tmp =(Tuple<R,S>)p; 
                return func(tmp.Item1,tmp.Item2);
            },tpl);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        public Task<TResult> Schedule<R,S,T,TResult>(Func<R,S,T,Task<TResult>> func,R r,S s,T t)
        {
            var tpl = Tuple.Create(r,s,t);
            var tsk = new Task<Task<TResult>>((p)=>
            {
                var tmp =(Tuple<R,S,T>)p; 
                return func(tmp.Item1,tmp.Item2,tmp.Item3);
            },tpl);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        public Task<TResult> Schedule<R,S,T,U,TResult>(Func<R,S,T,U,Task<TResult>> func,R r,S s,T t,U u)
        {
            var tpl = Tuple.Create(r,s,t,u);
            var tsk = new Task<Task<TResult>>((p)=>
            {
                var tmp =(Tuple<R,S,T,U>)p; 
                return func(tmp.Item1,tmp.Item2,tmp.Item3,tmp.Item4);
            },tpl);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        public Task<TResult> Schedule<R,S,T,U,V,TResult>(Func<R,S,T,U,V,Task<TResult>> func,R r,S s,T t,U u,V v)
        {
            var tpl = Tuple.Create(r,s,t,u,v);
            var tsk = new Task<Task<TResult>>((p)=>
            {
                var tmp =(Tuple<R,S,T,U,V>)p; 
                return func(tmp.Item1,tmp.Item2,tmp.Item3,tmp.Item4,tmp.Item5);
            },tpl);
            tsk.Start(scheduler);
            return tsk.Unwrap();
        }

        #endregion Scheduled function generation returning result Task<Task<TResult>>
    }
}
