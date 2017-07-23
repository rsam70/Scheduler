# Scheduler
Wrapper around the Task primitive with correct capturing of variables.

Basic usage:

var scheduler = Scheduler.CreateExclusiveScheduler();

var i = 42;
scheduler.Schedule((k) => Console.WriteLine(k), i);

// or in async context
var y = await scheduler.Schedule(() => { return 42; });

// blocking on
var y = scheduler.Schedule(() => { return 42; }).Result;
