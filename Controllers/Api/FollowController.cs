using System;
using System.Linq;
using System.Web.Http;
using GigHub.Core;
using GigHub.Core.DTOs;
using GigHub.Core.Models;
using GigHub.Persistance;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    public class FollowController : ApiController
    {
	    private readonly IUnitOfWork _unitOfWork;

	    public FollowController(IUnitOfWork unitOfWork)
	    {
		    _unitOfWork = unitOfWork;
	    }

		[Authorize]
		[HttpPost]
	    public IHttpActionResult Add(FollowDto dto)
	    {
		    var userId = User.Identity.GetUserId();
			
		    if (dto.FolloweeId.IsNullOrWhiteSpace() || dto.FolloweeId == userId)
		    {
			    return BadRequest("null artist id or you following you");
		    }


		    if (_unitOfWork.Follows.IsExist(userId,dto.FolloweeId))
			    return BadRequest("already Following");

			var follow = new  Follow
			{
			   FolloweeId = dto.FolloweeId,
			   FollowerId = userId
			};

			_unitOfWork.Follows.Add(follow);
			_unitOfWork.Complete();
			return Ok("created");

	    }

	    [Authorize]
	    [HttpDelete]
	    public IHttpActionResult Delete(string id)
	    {
		    var userId = User.Identity.GetUserId();
		    var follow = _unitOfWork.Follows.GetUserFolow(userId,id);

		    if (follow == null)
		    {
			    return BadRequest("null follow");
		    }

		    _unitOfWork.Follows.Remove(follow);
		    _unitOfWork.Complete();

		    return Ok(id);
	    }


    }
}
