using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ACME.Data.Interfaces;
using ACME.Data.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using ACME.Data.ViewModels;

namespace ACME.Controllers
{
    public class HomeController : Controller
    {

        // Creates repository variables used to access database information
        private readonly IProductRepository _productRepository;
        private readonly IEmailSender _emailSender;

        // GUID used for contact page
        private static Guid guid;

        public HomeController(IProductRepository productRepository, IEmailSender emailSender)
        {

            // Initializes the Repository classes, so that we can use them to perform CRUD operations on the database
            _productRepository = productRepository;
            _emailSender = emailSender;
        }

        // Method used to display the Index page
        public ViewResult Index()
        {

            // Gets the preferred products from the productRepository
            var homeViewModel = new HomeViewModel
            {
                PreferredProducts = _productRepository.PreferredProducts
            };

            // Return the view with the homeViewModel (contains preferred products)
            return View(homeViewModel);
        }

        // Method used to display the Contact page
        [HttpGet]
        public ViewResult Contact()
        {

            // Return the contact page
            return View();
        }


        // Method used to post the Contact page
        [HttpPost]
        public async Task<IActionResult> Contact(ContactForm model)
        {

            // If the model state is valid (all fields have passed validation), then send a message to admin@testsetup.net
            if (ModelState.IsValid)
            {

                // Gets a new GUID for the contact form
                guid = Guid.NewGuid();

                // Sends the email with all required information
                await _emailSender.SendEmailAsync("admin@testsetup.net", "ACME ID: " 
                    + guid, "<h2>Email: " + model.Email + "</h2>"
                    + "<br>" + "<h2>Message</h2>" +
                    "<p>" + model.Message.Replace("\n", "<br>") + "</p>");

                // Return confirmation page
                return RedirectToAction("MessageSubmitted");
            }

            // Returns the contact page
            return Contact();
        }

        // Once the message has been submitted, provide the GUID to the user in a confirmation page
        [HttpGet]
        public ViewResult MessageSubmitted()
        {

            // Sets the ViewBag id equal to the sent GUID
            ViewBag.id = guid;

            // Returns the view
            return View();
        }

    }
}
