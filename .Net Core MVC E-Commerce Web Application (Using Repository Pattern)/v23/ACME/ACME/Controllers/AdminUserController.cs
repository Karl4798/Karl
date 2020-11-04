using System.Collections.Generic;
using System.Threading.Tasks;
using ACME.Data.Models;
using ACME.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Controllers
{

    public class AdminUserController : Controller
    {

        // Create variables to hold the RoleManager and UserManager
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AccountUser> _userManager;

        public AdminUserController(RoleManager<IdentityRole> roleManager,
            UserManager<AccountUser> userManager)
        {

            // Assign managers
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        // Method used to list roles in the web application (Customer and Admin)
        // Only users in the Admin role may access this resource
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ListRoles()
        {

            // Gets the roles
            var roles = _roleManager.Roles;

            // Returns the view with all roles in the web application
            return View(roles);
        }

        // Method used to edit roles in the web application (Customer and Admin)
        // Only users in the Admin role may access this resource
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditRole(string id)
        {
            // Find the role by id
            var role = await _roleManager.FindByIdAsync(id);

            // If the role is null then display an error message
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";

                // Return the view
                return View("NotFound");
            }

            // Initializes a model to store the role id, and role name
            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            // Retrieve all the users from the database
            foreach (var user in _userManager.Users)
            {
                // If the user is in the role supplied in the parameters, then add the user to the model
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {

                    // Adds the username to the model, so the user can view which users are in the role
                    model.Users.Add(user.UserName);
                }
            }

            // Returns the view with the model, containing role information, and the users in the role
            return View(model);

        }

        // Method used to edit roles in the web application (Customer and Admin)
        // Only users in the Admin role may access this resource
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {

            // Sets ViewBag role id to that of the passed role id parameter
            ViewBag.roleId = roleId;

            // Find the role by id
            var role = await _roleManager.FindByIdAsync(roleId);

            // Sets ViewBag role name
            ViewBag.RoleName = role.Name.ToLower();

            // If the role is null then display an error message
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";

                // Return the view
                return View("NotFound");
            }

            // Initializes a model of type List<UserRoleViewModel>()
            var model = new List<UserRoleViewModel>();

            // Retrieve all the users from the database
            foreach (var user in _userManager.Users)
            {

                // Adds user details to the UserRoleViewModel object
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    Email = user.Email
                };

                // Determine if the user is in the role, and if so check the userRoleViewModel.IsSelected value
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                    
                }

                // If the user is not in the role, then do not check the userRoleViewModel.IsSelected value
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                // Adds the user to the model
                model.Add(userRoleViewModel);

            }

            // Returns the view with model information (roles, and users in the roles)
            return View(model);

        }

        // Method used to edit users in roles in the web application (Customer and Admin)
        // Only users in the Admin role may access this resource
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {

            // Variable used to hold role information for passed in roleId
            var role = await _roleManager.FindByIdAsync(roleId);

            // If the role is null then display an error message
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";

                // Return the view
                return View("NotFound");
            }

            // Save the role for the user
            for (int i = 0; i < model.Count; i++)
            {

                // Gets the user information
                var user = await _userManager.FindByIdAsync(model[i].UserId);

                // Variable used when determining if the role has been saved successfully in the database
                IdentityResult result = null;

                // Add or remove the user from the role, based on if the user has or has not checked the user in the roles page
                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                // If the role has been saved successfully, return the user to the roles list page
                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }
            }

            // Return the user to the roles list page
            return RedirectToAction("EditRole", new { Id = roleId });
        }

    }

}