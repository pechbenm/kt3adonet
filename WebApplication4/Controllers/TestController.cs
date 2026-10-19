using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task Text()
        {
            Response.ContentType = "text/plain";

            await Response.WriteAsync("Hello, world!");
        }
        public async Task Html()
        {
            Response.ContentType = "text/html";

            var html = """
        <!DOCTYPE html>
        <html>
        <head><title>Test Html</title></head>
        <body>
            <h1>Заголовок страницы</h1>
            <p>Это параграф, сформированный в TestController.</p>
        </body>
        </html>
        """;

            await Response.WriteAsync(html);
        }
        public async Task Json()
        {
            Response.ContentType = "application/json";

            var data = new { Name = "Alice", Age = 30 };

            await Response.WriteAsJsonAsync(data);
        }
        private readonly IWebHostEnvironment _env;

        public TestController(IWebHostEnvironment env)
            => _env = env;

        public async Task File()
        {
            Response.ContentType = "text/plain";

            Response.Headers["Content-Disposition"] =
                "attachment; filename=\"test.txt\"";

            var filePath = Path.Combine(_env.WebRootPath, "test.txt");

            await Response.SendFileAsync(filePath);
        }
        public async Task Status()
        {
            Response.StatusCode = 404;


            Response.ContentType = "text/plain";

            await Response.WriteAsync("404 — Страница не найдена");
        }
        public async Task Cookie()
        {
            Response.Cookies.Append("user", "Answer", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7),
                HttpOnly = true,   
                Secure = true,    
                SameSite = SameSiteMode.Strict
            });

            Response.ContentType = "text/plain";
            await Response.WriteAsync("Cookie 'user' установлена со значением 'Answer'");
        }
    }
}
