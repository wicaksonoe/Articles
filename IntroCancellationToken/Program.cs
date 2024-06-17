using IntroCancellationToken;

// Case 1 -- synchronous vs asynchronous method
// Demo.QuickMethod();

// Demo.SlowMethodAsync();

// await Demo.SlowMethodAsync();


// Case 2 -- asynchronous method with racing condition
// var methodAsync = Demo.SlowMethodAsync();
// await Task.Delay(6000);
// Console.WriteLine("Instruction called out of nowhere");
// methodAsync.Wait();

// await Demo.SlowMethodAsync();
// Console.WriteLine("Instruction called out of nowhere");


// Case 3 -- asynchronous method with canceling Task
var cancellationToken = new CancellationTokenSource();
var methodAsync = Demo.SlowMethodAsync(cancellationToken.Token);
await Task.Delay(3000);
Console.WriteLine("Instruction called out of nowhere");
cancellationToken.Cancel();
methodAsync.Wait();