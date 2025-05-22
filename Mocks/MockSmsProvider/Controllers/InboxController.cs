using Microsoft.AspNetCore.Mvc;
using MockSmsProvider.Data;

namespace MockSmsProvider.Controllers
{
    public class InboxController : Controller
    {
        private ApplicationDbContext _context;

        public InboxController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InboxController
        public ActionResult Index(string userId)
        {
            return View();
        }

    }
}
