using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.DTOs;
using GigHub.Core.Models;
using GigHub.Persistance;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
	[Authorize]
    public class AttendanceController : ApiController
    {
	    private readonly IUnitOfWork _unitOfWork;

	    public AttendanceController(IUnitOfWork unitOfWork)
	    {
		    _unitOfWork = unitOfWork;
	    }

		[Authorize]
	    [HttpPost]
	    public IHttpActionResult Add(AttendanceDto dto)
	    {
		    var gig = _unitOfWork.Gigs.GetGig(dto.GigId);
		    var userId = User.Identity.GetUserId();

		    if ( dto.GigId == 0 || gig.ArtistId == userId)
		    {
			    return BadRequest("not valid ");
		    }

		    var attendance = new Attendance
			{
				GigId = gig.Id,
				AttendeeId = userId
			};

		    _unitOfWork.Attendances.Add(attendance);
		    _unitOfWork.Complete();

			return Ok();
	    }

		[Authorize]
		[HttpDelete]
	    public IHttpActionResult Delete(int id)
	    {
		    var attendance = _unitOfWork.Attendances.GetUserAttendance(id,User.Identity.GetUserId());

		    if (attendance == null)
			    return BadRequest("not a gig id");

		    _unitOfWork.Attendances.Remove(attendance);
		    _unitOfWork.Complete();
		    return Ok(id);
	    }

	}
}
