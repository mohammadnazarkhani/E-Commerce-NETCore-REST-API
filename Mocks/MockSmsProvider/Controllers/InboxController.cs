using Microsoft.AspNetCore.Mvc;
using MockSmsProvider.Data;
using MockSmsProvider.Services;

namespace MockSmsProvider.Controllers
{
    public class InboxController : Controller
    {
        private InboxServices _inboxServices;

        public InboxController(InboxServices inboxServices)
        {
            _inboxServices = inboxServices;
        }

        // GET: InboxController
        public ActionResult Index(string userId)
        {
            return View();
        }

    }
}
