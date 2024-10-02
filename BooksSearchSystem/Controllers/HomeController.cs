using BooksSearchSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationTest;
using Microsoft.EntityFrameworkCore; // 引用 Entity Framework Core
using BooksSearchSystem.Data; // 引用資料庫上下文命名空間

namespace BooksSearchSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksCrawler _booksInfo = new BooksCrawler();
        private readonly ApplicationDbContext _context; // 資料庫上下文
        private readonly ILogger<HomeController> _logger;

        string id = "0010764130"; // 書籍的識別碼（例如 ISBN）

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context; // 注入資料庫上下文
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // 爬取書籍資料，返回 JSON 格式
                string jsonData = await _booksInfo.booksInfo(id);
                ViewBag.JsonData = jsonData;

                // 測試連接，查詢 Users 表中的所有資料
                var users = await _context.Users.ToListAsync(); // 獲取所有使用者資料

                // 如果想要確認能否正確連接，將結果返回到視圖
                ViewBag.Users = users; // 將查詢結果傳遞到視圖

                return View();
            }
            catch (Exception ex)
            {
                // 記錄錯誤信息
                _logger.LogError($"Database connection error: {ex.Message}");
                return View("Error"); // 返回錯誤視圖
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
