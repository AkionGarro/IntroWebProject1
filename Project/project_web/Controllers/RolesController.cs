using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_web.Models;
using project_web.Models.DbModels;

namespace project_web.Controllers
{
    [AllowAnonymous]
    public class RolesController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ProjectTicketContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public RolesController(RoleManager<IdentityRole> roleManager, ProjectTicketContext context,
                                UserManager<IdentityUser> _userManager)
        {
            this.roleManager = roleManager;
            _context = context;
            this._userManager = _userManager;
            
        }

        // GET: RolesController
        [HttpGet]
        public IActionResult Index()
        {

            var roles = roleManager.Roles;
            return View(roles);
        }

        // GET: RolesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RolesController/Create
        public async Task<IActionResult> NewRole(RolesModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
    
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("Index");
            }

            var model = new EditRoles
            {
                Id = role.Id,
                RoleName = role.Name
            };

            // Retrieve all the Users
            foreach (var user in _userManager.Users.ToList())
            {
                // If the user is in this role, add the username to
                // Users property of EditRoleViewModel. This model
                // object is then passed to the view for display
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditRoles model)
        {
          
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                // Update the Role using UpdateAsync
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }
        }


        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var result = await roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(role);
            }

            return RedirectToAction("Index");
        }




    }
}
