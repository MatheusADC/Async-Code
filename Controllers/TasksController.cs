using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionTest.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Tasks()
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");

        var task = await MyAsyncMethod();

        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine($"Thread Thread: {Thread.CurrentThread.ManagedThreadId}");

        return Ok(Guid.NewGuid());
    }

    private async Task<int> MyAsyncMethod()
    {
        Console.WriteLine($"ThreadId inside MyAsyncMethod before await: {Thread.CurrentThread.ManagedThreadId}");

        await Task.Delay(20000);

        Console.WriteLine($"ThreadId inside MyAsyncMethod after await: {Thread.CurrentThread.ManagedThreadId}");

        return 7;
    }
}
