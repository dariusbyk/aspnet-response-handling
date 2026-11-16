using Microsoft.AspNetCore.Mvc;
using ResponseTasks.Models;

namespace ResponseTasks.Controllers
{
    public class TestController : Controller
    {
        public async Task Text()
        {
            Response.ContentType = "text/plain";
            await Response.WriteAsync("Hello, world!");
        }

        public async Task Html()
        {
            Response.ContentType = "text/html";
            await Response.WriteAsync("<h1>Hello!</h1><p>This is an HTML response.</p>");
        }

        public async Task Json()
        {
            Person person = new Person();
            person.Name = "Darius";
            person.Age = 20;

            Response.ContentType = "application/json";
            await Response.WriteAsJsonAsync(person);
        }

        public async Task File()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "test.txt");

            Response.ContentType = "text/plain";
            Response.Headers["Content-Disposition"] = "attachment; filename=test.txt";
            await Response.SendFileAsync(filePath);
        }

        public async Task Status()
        {
            Response.StatusCode = 404;
            Response.ContentType = "text/plain";
            await Response.WriteAsync("Error 404: Not Found");
        }

        public async Task Cookie()
        {
            Response.Cookies.Append("user", "Answer");
            Response.ContentType = "text/plain";
            await Response.WriteAsync("Cookie user=Answer has been set.");
        }
    }
}
