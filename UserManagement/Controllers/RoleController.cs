using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Service.Services.Abstract;
using UserManagement.Service.ViewModel.Identity.AppRole;

namespace UserManagemet.Controllers
{
    
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await roleService.GetRoleAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await roleService.CreateRoleAsync(model);
                if (result.error)
                    return Json(new { error = result.error, message = result.message });
            
                return Json(new { error = result.error, message = result.message });

            }

            return Json(new {error = true, message = string.Join(", ", ModelState.Values
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
                var result = await roleService.DeleteRoleAsync(Id);
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
        public async Task<IActionResult> Edit(UpdateRoleViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await roleService.UpdateRoleAsync(model);
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
