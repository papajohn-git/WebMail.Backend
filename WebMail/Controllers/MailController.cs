using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebMail.Application.DTOs.MailDTO;
using WebMail.Application.Exceptions;
using WebMail.Application.Services.Interfaces;

namespace WebMail.Controllers
{
	public class MailController : BaseController
	{
		private readonly IConfiguration _configuration;

		public MailController(IApplicationService applicationService, IConfiguration configuration) : base(applicationService)
		{
			_configuration = configuration;
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> SendMail([FromBody] MailCreateDTO mailDTO)
		{
			var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");

			var validationResults = new List<ValidationResult>();
			var validationContext = new ValidationContext(mailDTO);
			bool isValid = Validator.TryValidateObject(mailDTO, validationContext, validationResults, true);

			if (!isValid)
			{
				var errorMessages = string.Join(", ", validationResults.Select(vr => vr.ErrorMessage));
				throw new InvalidArgumentException("", $"Mail with subject: {mailDTO.Subject}, failed to be sent. Validation failed: {errorMessages}");
			}

			var result = await _applicationService.MailService.SendMail(userId, mailDTO);

			return Ok(result);
		}
		 
		[HttpGet("{folderName}")]
		[Authorize]
		public async Task<IActionResult> GetMails(string folderName)
		{
			var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");

			var result = await _applicationService.FolderService.GetMailsFromFolderAsync(userId, folderName);

			return Ok(result);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetMailByGuid(Guid mailGuid)
		{
			var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");

			var result = await _applicationService.MailService.GetMailByGuid(mailGuid);

			return result is not null ? Ok(result) : throw new EntityNotFoundException("", "Mail not found");
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetMailById(int mailID)
		{
			var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");

			var result = await _applicationService.MailService.GetMailById(mailID);

			return result is not null ? Ok(result) : throw new EntityNotFoundException("", "Mail not found");
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> MoveEmailToFolder([FromBody] MailMoveFolderDTO mailFolder)
		{
			var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");

			var result = await _applicationService.MailService.MoveEmailToFolder
				(userId, mailFolder.GuidMail, mailFolder.FolderName, mailFolder.NewFolderName);

			return result.Success ? Ok(result) : BadRequest(result);
		}

		//[HttpDelete]
		//[Authorize]
		//public async Task<IActionResult> DeleteEmailFromFolder(MailMoveFolderDTO mailFolder)
		//{
		//	var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");

		//	var result = await _applicationService.MailService.DeleteEmailFromFolder(userId, mailFolder.GuidMail, mailFolder.FolderId);

		//	return result.Success ? Ok(result) : BadRequest(result);
		//}
	}
}
