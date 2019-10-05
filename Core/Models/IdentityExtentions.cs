using System;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNet.Identity;

namespace GigHub.Core.Models
{
	public static class IdentityExtentions
	{
		public static string GetName(this IIdentity identity)
		{
			if(identity == null)
				throw new ArgumentNullException();

			if (identity is ClaimsIdentity user)
				return user.FindFirstValue("Name");

			return null;
		}
	}
}