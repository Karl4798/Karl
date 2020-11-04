using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACME.Data.Models
{

    // Model used to store order fields
    public class Order
    {
        [BindNever]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]*$", ErrorMessage = "Please enter a first name made up of letters only")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]*$", ErrorMessage = "Please enter a last name made up of letters only")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s\:\-\.\#\&\!\@\$\?\%\*\(\)\/\|\""\+\-\~\{\}\”\’\<\>]*$", ErrorMessage = "Please enter an address line 1 made up of letters and numbers only")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s\:\-\.\#\&\!\@\$\?\%\*\(\)\/\|\""\+\-\~\{\}\”\’\<\>]*$", ErrorMessage = "Please enter an address line 2 made up of letters and numbers only")]
        public string AddressLine2 { get; set; }

        [Required]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s\:\-\.\#\&\!\@\$\?\%\*\(\)\/\|\""\+\-\~\{\}\”\’\<\>]*$", ErrorMessage = "Please enter a city made up of letters and numbers only")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^[,;a-zA-Z0-9'-'\s\:\-\.\#\&\!\@\$\?\%\*\(\)\/\|\""\+\-\~\{\}\”\’\<\>]*$", ErrorMessage = "Please enter a province made up of letters and numbers only")]
        public string Province { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter a postcode made up of numbers only")]
        public int Postcode { get; set; }

        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        [RegularExpression(@"^[0-9'-'\s\+]*$", ErrorMessage = "Please enter a phone number made up of numbers and + only")]
        public string PhoneNumber { get; set; }

        public List<OrderDetail> OrderLines { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [Display(Name = "Order Total")]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        [Display(Name = "Order Placed Date / Time")]
        public DateTime OrderPlaced { get; set; }
    }
}
