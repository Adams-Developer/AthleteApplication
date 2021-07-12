using AthleteApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AthleteApplication.ViewModels
{
    public class AthleteViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "School")]
        public string SchoolName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Sport")]
        public string Sport { get; set; }

        [Required]
        [Display(Name = "Instagram Name")]
        public string InstagramHandle { get; set; }

        [Required]
        [Display(Name = "Twitter Name")]
        public string TwitterHandle { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        [Required]
        [Display(Name = "Address 2")]
        public string ApartmentNumber { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zipcode")]
        public int ZipCode { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Merch Size")]
        public string MerchSize { get; set; }


        // For DDL
        public SelectList SizeSelectList { get; set; }

        public Sizes Sizes { get; set; }
      
    }
}
