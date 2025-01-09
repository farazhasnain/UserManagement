using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Service.Services.Abstract;
using UserManagement.Service.ViewModel.Identity.AppRole;
using UserManagement.Service.ViewModel.Identity.AppUsers;
using UserManagement.Domain.Identity;

namespace UserManagemet.Controllers
{

    public class UserController : Controller
    {


        private readonly IUserService userService;
        private readonly IRoleService roleService;
        public UserController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            TempData["Roles"] = roleService.GetRoleAsync().Result.Where(x => x.is_active).ToList();
            return View(await userService.GetUserAsync());
        }
        public async Task<IActionResult> GetUserRoles(int userId)
        {
            
            var userRoles = await userService.GetUserRoleAsync(userId);
            return Json(new { error = false, message = userRoles.ToArray() });
        }


        [HttpPost]
        public async Task<IActionResult> AssignRoles(int userId, List<int> roleIds)
        {
            try
            {
               
                 await userService.AssignRoleAsync(userId, roleIds);
                 return Json(new { error = false, message = "Roles assigned successfully" });
            }
            catch (Exception ex)
            {
               
                return Json(new { error = true, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await userService.CreateAsync(model);
                if (result.error)
                    return Json(new { error = result.error, message = result.message });

                return Json(new { error = result.error, message = result.message });

            }

            return Json(new
            {
                error = true,
                message = string.Join(", ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToList())
            });



        }

        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {

            if (ModelState.IsValid)
            {
                var result = await userService.DeleteUserAsync(Id);
                if (result.error)
                    return Json(new { error = result.error, message = result.message });

                return Json(new { error = result.error, message = result.message });

            }

            return Json(new
            {
                error = true,
                message = string.Join(", ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToList())
            });

        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateUserViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await userService.UpdateUserAsync(model);
                if (result.error)
                    return Json(new { error = result.error, message = result.message });

                return Json(new { error = result.error, message = result.message });

            }

            return Json(new
            {
                error = true,
                message = string.Join(", ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToList())
            });
        }
    }
}
