using Microsoft.AspNetCore.Mvc;
using MockSmsProvider.Data;
using MockSmsProvider.Services;
using MockSmsProvider.Services.Interfaces;

namespace MockSmsProvider.Controllers
{
    public class InboxController : Controller
    {
        private IInboxService _inboxServices;
        private IUserService _userService;

        public InboxController(IInboxService inboxServices, IUserService userService)
        {
            _inboxServices = inboxServices;
            _userService = userService;
        }        // GET: InboxController
        public async Task<ActionResult> Index(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return RedirectToAction("Index", "Home");
            }

            await _userService.SingInUser(userId);
            var messages = await _inboxServices.GetUserInboxMessagesByUserId(userId);

            return View(messages);
        }

    }
}
