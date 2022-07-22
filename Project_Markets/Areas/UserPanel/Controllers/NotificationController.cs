using Data.Contracts;
using Entities.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace Project_Markets.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        [HttpGet]
        public IActionResult Index(bool bIsGetOnlyUnread = false)
        {
            string nToUserId = ClaimUtility.GetUserId(User);
            var model = _notificationRepository.GetNotifications(nToUserId, bIsGetOnlyUnread);
            if (model==null)
            {
                ModelState.AddModelError("Message", "Null");
                return null;
            }
            return View(model);
        }

        public JsonResult GetNotification(bool bIsGetOnlyUnread = false)
        {
            string nToUserId = ClaimUtility.GetUserId(User);
            var model= _notificationRepository.GetNotifications(nToUserId, bIsGetOnlyUnread);
            return Json(model);
        }
    }
}
