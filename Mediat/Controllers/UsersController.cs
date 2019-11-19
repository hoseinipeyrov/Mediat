namespace Mediat.Controllers
{
    using Mediat.Services.PersonService;
    using Mediat.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        private readonly IUserApplicationService _userAppService;
        public UsersController(IUserApplicationService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost]
        // [Authorize(Policy = "CanWriteCustomerData")]
        [Route("user-management")]
        public async Task<IActionResult> PostAsync([FromBody]UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                // NotifyModelStateErrors();
                return Response(false, userDto);
            }

          var u= await  _userAppService.CreateAsync(userDto);

            return Response(true, u);
        }
    }
}
