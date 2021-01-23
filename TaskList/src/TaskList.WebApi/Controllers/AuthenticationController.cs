using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList.Infrastructure.Authentication.Interfaces;
using TaskList.Services.Interfaces;
using TaskList.SharedKernel;

namespace TaskList.Application.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUsuarioService _userService;

        public AuthenticationController(IUsuarioService userService,
            ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<dynamic>> Authenticate(AuthenticationInput authenticationInput)
        {
            var usuario = await _userService.Authenticate(authenticationInput.Username, authenticationInput.Password);

            if (usuario == default)
                return Unauthorized(new { message = "Usuário inválido" });

            var token = _tokenService.GenerateToken(usuario);
            return new { usuario, token };
        }
    }
}