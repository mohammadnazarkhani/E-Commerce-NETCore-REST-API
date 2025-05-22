using Microsoft.AspNetCore.Mvc;
using MockSmsProvider.Data;
using MockSmsProvider.Services;

namespace MockSmsProvider.Controllers
{
    public class InboxController : Controller
    {
        private InboxService _inboxServices;

        public InboxController(InboxService inboxServices)
        {
            _inboxServices = inboxServices;
        }

        // GET: InboxController
        public async Task<ActionResult> Index(string userId)
        {
            var messages = await _inboxServices.GetUserInboxMessagesByUserId(userId);

            return View(messages);
        }

    }
}
