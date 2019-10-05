using AutoMapper;
using GigHub.Core.DTOs;
using GigHub.Core.Models;

namespace GigHub
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ApplicationUser, UserDto>();
			CreateMap<UserDto, ApplicationUser>();
			CreateMap<Gig, GigDto>();
			CreateMap<GigDto, Gig>();
			CreateMap<Notification, NotificationDto>();
			CreateMap<NotificationDto, Notification>();
		}
	}
}