namespace IntroCancellationToken;

public static class Demo
{
    public static void QuickMethod()
    {
        Console.WriteLine("Method Started");
        
        for (var i = 1; i < 6; i++)
        {
            Console.WriteLine($"Step {i}...");
        }
        
        Console.WriteLine("Method Completed");
    }
    
    public static async Task SlowMethodAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Method Started");
        
        for (var i = 1; i < 6; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await Task.Delay(1000,cancellationToken);
            Console.WriteLine($"Step {i}...");
        }
        
        Console.WriteLine("Method Completed");
    }
}