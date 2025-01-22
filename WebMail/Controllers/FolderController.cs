using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebMail.Application.DTOs.MailDTO;
using WebMail.Application.Exceptions;
using WebMail.Application.Services.Interfaces;

namespace WebMail.Controllers
{
	public class FolderController : BaseController
	{
		private readonly IConfiguration _configuration;

		public FolderController(IApplicationService applicationService, IConfiguration configuration) : base(applicationService)
		{
			_configuration = configuration;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetUserFolders()
		{
			var userId = AppUser!.Id;
			if (userId == null)
			{
				throw new EntityForbiddenException("", "User is not authenticated.");
			}

			var result = await _applicationService.FolderService.GetAllUserFolder((int)userId);

			return result is not null ? Ok(result) : throw new EntityNotFoundException("", "User not found");
		}

		[HttpPost("{folderName}")]
		[Authorize]
		public async Task<IActionResult> CreateFolder(string folderName)
		{

			var userId = AppUser!.Id;
			if (userId == null)
			{
				throw new EntityForbiddenException("", "User is not authenticated.");
			}

			var result = await _applicationService.FolderService.CreateFolder((int)userId, folderName);

			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{folderId}")]
		[Authorize]
		public async Task<IActionResult> DeleteFolder(int folderId)
		{ 
			var userId = AppUser!.Id;
			if (userId == null)
			{
				throw new EntityForbiddenException("", "User is not authenticated.");
			}

			var result = await _applicationService.FolderService.DeleteFolder((int)userId, folderId);

			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
