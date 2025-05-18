using Microsoft.AspNetCore.Mvc;

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
