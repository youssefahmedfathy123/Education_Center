using Education_Center_Contract.Interfaces.Identity;
using Education_Center_Domain.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Education_Center.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cont_IdentityController : ControllerBase
    {

        private readonly Iidentity _identity;
        public Cont_IdentityController(Iidentity identity)
        {
            _identity = identity;
        }



        // Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromForm] Register register)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid!");

            var result = await _identity.Register(register);

            if (result.Message != null)
                return BadRequest(
                    new
                    {
                        ur_Message = result.Message
                    }
                    );


                return Ok(
                 new
                 {
                     Name = result.Name,
                     Role = result.Role,
                     Branch_id = result.Branch_id,
                     Token = result.Token,
                 }

             );
        }

        // Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model is not valid!");

            var result = await _identity.Login(login);

            if (result.Message != null)
                return BadRequest(
                    new
                    {
                        ur_Message = result.Message
                    }
                    );


            return Ok(
             new
             {
                 Email = result.Email,
                 Role = result.Role,
                 Branch_name = result.Branch_name,
                 Token = result.Token,
             }

         );
        }



    }
}


