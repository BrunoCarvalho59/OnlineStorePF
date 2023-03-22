using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Core.Models.Utilizador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Dtos;
using OnlineStore.API.Erros;
using OnlineStore.API.Extensions;

namespace OnlineStore.API.Controllers
{
    public class AccountController : BaseApiController

    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUserAtual()
        {
            var user = await _userManager.FindByEmailFromClaimsPrincipal(User);

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayNome = user.DisplayNome
            };
        }

        [HttpGet("emailexiste")]
        public async Task<ActionResult<bool>> CheckEmailExistenteAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [Authorize]
        [HttpGet("morada")]
        public async Task<ActionResult<MoradaDto>> GetUserMorada()
        {
            var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(User);

            return _mapper.Map<Morada, MoradaDto>(user.Morada);
        }

        [Authorize]
        [HttpPut("morada")]
        public async Task<ActionResult<MoradaDto>> UpdateUserMorada(MoradaDto morada)
        {
            var user = await _userManager.FindUserByClaimsPrincipleWithAddressAsync(HttpContext.User);

            user.Morada = _mapper.Map<MoradaDto, Morada>(morada);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return Ok(_mapper.Map<Morada, MoradaDto>(user.Morada));
            
            return BadRequest("Problema ao atualizar o utilizador");
        }  

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayNome = user.DisplayNome
            };
        }

        [HttpPost("registo")]
        public async Task<ActionResult<UserDto>> Registo(RegistoDto registoDto)
        {
            /*
            if (CheckEmailExistenteAsync(registoDto.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse{errors = new []{"Endereço de email em utilização"}});
            }
            */
            var user = new AppUser
            {
                DisplayNome = registoDto.DisplayNome,
                Email = registoDto.Email,
                UserName = registoDto.Email
            };

            var result = await _userManager.CreateAsync(user, registoDto.Password);

            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            return new UserDto
            {
                DisplayNome = user.DisplayNome,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }
    }
}