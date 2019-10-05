using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Castle.Core.Internal;
using GigHub.Core;
using GigHub.Core.DTOs;
using GigHub.Core.Models;
using GigHub.Persistance;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
	[Authorize]
    public class NotificationController : ApiController
    {
		private readonly IUnitOfWork _unitOfWork;

		public NotificationController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		[Route("api/notification/getNotifications")]
		public IEnumerable<NotificationDto> GetNotifications()
		{
			var notifications =  _unitOfWork.Notifications.GetUserNotifications(User.Identity.GetUserId());
		
			return notifications.Select(Mapper.Map<Notification,NotificationDto>);
		}

		[HttpPost]
		public IHttpActionResult NotificationRead()
		{
			var notification =_unitOfWork.UserNotification.GetUserNotifications(User.Identity.GetUserId()) ;
			
			notification.ForEach(n => n.Read());

			_unitOfWork.Complete();
			return Ok("read");

		}

		[HttpGet]
		[Route("api/notification/getReadNotifications")]
		public IEnumerable<NotificationDto> GetReadNotifications()
		{
			var notifications = _unitOfWork.Notifications.GetUserReadNotifications(User.Identity.GetUserId());

			return notifications.Select(Mapper.Map<Notification, NotificationDto>);
		}

	}
}
