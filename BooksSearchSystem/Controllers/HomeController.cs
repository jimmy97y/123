using BooksSearchSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationTest;
using Microsoft.EntityFrameworkCore; // �ޥ� Entity Framework Core
using BooksSearchSystem.Data; // �ޥθ�Ʈw�W�U��R�W�Ŷ�

namespace BooksSearchSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly BooksCrawler _booksInfo = new BooksCrawler();
        private readonly ApplicationDbContext _context; // ��Ʈw�W�U��
        private readonly ILogger<HomeController> _logger;

        string id = "0010764130"; // ���y���ѧO�X�]�Ҧp ISBN�^

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context; // �`�J��Ʈw�W�U��
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                // �������y��ơA��^ JSON �榡
                string jsonData = await _booksInfo.booksInfo(id);
                ViewBag.JsonData = jsonData;

                // ���ճs���A�d�� Users �����Ҧ����
                var users = await _context.Users.ToListAsync(); // ����Ҧ��ϥΪ̸��

                // �p�G�Q�n�T�{��_���T�s���A�N���G��^�����
                ViewBag.Users = users; // �N�d�ߵ��G�ǻ������

                return View();
            }
            catch (Exception ex)
            {
                // �O�����~�H��
                _logger.LogError($"Database connection error: {ex.Message}");
                return View("Error"); // ��^���~����
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
