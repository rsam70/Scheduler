# Scheduler
Wrapper around the Task primitive using task state object for passing parameter data. 

Basic usage:

``` c#
var scheduler = Scheduler.CreateExclusiveScheduler();

/// captured on call.
var i = 42;
scheduler.Schedule((k) => Console.WriteLine(k), i);

/// or in async context
var y = await scheduler.Schedule(() => { return 42; });

/// blocking
var y = scheduler.Schedule(() => { return 42; }).Result;
