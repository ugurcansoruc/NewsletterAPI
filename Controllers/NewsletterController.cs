using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsletterAPI.Modals;
using NewsletterAPI.Services;
using System.Threading.Tasks;

namespace NewsletterAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsletterController : ControllerBase
    {

        IFirestoreService _IFirestoreService;

        public NewsletterController(IFirestoreService firestoreService)
        {
            _IFirestoreService = firestoreService;
        }

        [Route("AddEmail")]
        [HttpPost]
        public async Task<IActionResult> AddEmail(EmailDocument email)
        {
            await _IFirestoreService.AddAsync(email);

            return Ok();
        }


        [Route("DeleteEmail")]
        [HttpPost]
        public async Task<IActionResult> DeleteEmail(EmailDocument email)
        {
            await _IFirestoreService.DeleteAsync(email);

            return Ok();
        }

        [Route("GetAllEmails")]
        [HttpGet]
        public async Task<List<EmailDocument>> GetAllEmails()
        {
            return await _IFirestoreService.GetAll();
        }
    }
}
