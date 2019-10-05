using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using GigHub.Controllers;
using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
	public class GigFormView
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Venue { get; set; }

		[Required]
		public byte GenreId { get; set; }

		[Required]
		[FutureDate]
		public string Date { get; set; }

		[Required]
		[ValidTime]
		public string Time { get; set; }

		public IEnumerable<Genre> Genres { get; set; }

		public string Action {
			get
			{
				Expression<Func<GigsController, ActionResult>> update = g => g.Update(this);
			    Expression<Func<GigsController, ActionResult>> create = g => g.Create(this);

			    var action = (Id == 0) ? create : update;

			    return (action.Body as MethodCallExpression)?.Method.Name;
			}
       	}

		public string Header => (Id == 0) ? "Add a gig" : "Updating gig";
		
		public DateTime GetDateTime()
		{
			return DateTime.Parse($"{Date} {Time}");
		}
	}

}
