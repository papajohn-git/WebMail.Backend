using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMail.Application.DTOs.User;
using WebMail.Application.Services.Interfaces;

namespace WebMail.Controllers
{
	[Route("api/[controller]/[action]")]
	//[ApiController]
	public class BaseController : ControllerBase
	{
		public readonly IApplicationService _applicationService;

		public BaseController(IApplicationService applicationService)
		{
			_applicationService = applicationService;
		}

		private ApplicationUser? _appUser;

		protected ApplicationUser? AppUser
		{
			get
			{
				if (User != null && User.Claims != null && User.Claims.Any())
				{
					var clamesTypes = User.Claims.Select(c => c.Type);
					if (!clamesTypes.Contains(ClaimTypes.NameIdentifier))
					{
						return null!;
					}

					var userClaimsId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
					_ = int.TryParse(userClaimsId, out int id);

					_appUser = new ApplicationUser
					{
						Id = id
					};

					var userClaimsName = User.FindFirst(ClaimTypes.Name)?.Value;

					_appUser.Email = User.FindFirst(ClaimTypes.Email)?.Value;
					return _appUser;
				}

				return null!;
			}
		}
	}
}

