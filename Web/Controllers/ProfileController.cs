using AutoMapper;
using Core.DTOs;
using Core.Entities.Application;
using Core.Entities.UserIdentity;
using Core.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers
{
    public class ProfileController : Controller
    {
        #region Dependency Injection
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            return View(await _profileService.GetProfile(User));
        }
    }
}
