using Microsoft.AspNetCore.Mvc;
using MockSmsProvider.Data;
using MockSmsProvider.Services;

namespace MockSmsProvider.Controllers
{
    public class InboxController : Controller
    {
        // GET: InboxController
        public ActionResult Index(string userId)
        {
            return View();
        }

    }
}
