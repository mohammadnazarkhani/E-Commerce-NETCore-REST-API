using Microsoft.AspNetCore.Mvc;
using MockSmsProvider.Data;
using MockSmsProvider.Services;
using MockSmsProvider.Services.Interfaces;

namespace MockSmsProvider.Controllers
{
    /// <summary>
    /// MVC controller for retrival and presentation of messages in user inbox
    /// </summary>
    public class InboxController : Controller
    {
        private IInboxService _inboxServices;
        private IUserService _userService;

        public InboxController(IInboxService inboxServices, IUserService userService)
        {
            _inboxServices = inboxServices;
            _userService = userService;
        }

        // GET: /inbox?userId={id}
        /// <summary>
        /// User inbox page action method
        /// </summary>
        /// <param name="userId">Id of the user whom to get his/her inbox messages</param>
        /// <returns>List of messages(i.e. List<Sms>) of user's inbox</returns>
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
