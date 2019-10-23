using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class Provider
    {
        public string photo { get; set; }
        public string providerid { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string category { get; set; }
        [Required]
        [Display(Name = "City")]
        public string city { get; set; }
        [Required]
        [Display(Name = "State")]
        public string state { get; set; }
        [Required]
        [Display(Name = "Country")]
        public string country { get; set; }
        //[Required]
        //[Display(Name = "Category")]
        public string photoid { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string UserNAme { get; set; }
        public string aboutme { get; set; }
        public string workingday { get; set; }
        [Required]
        [Display(Name = "ZipCode")]
        public int zipcode { get; set; }
        [Required]
        [Display(Name = "Mobile Number Is Mandotory")]
        public int mobilenumber { get; set; }
        [Required]
        [Display(Name = "Alternate Number Is Mandotory")]
        public int alternatenumber { get; set; }
        [Required]
        [Display(Name = "AdharNumber Is Mandatory")]
        public int adharnumber { get; set; }
        //[Required]
        //[Display(Name = "Dat Start")]
        public DateTime daystart { get; set; }
        //[Required]
        //[Display(Name = "End day")]
        public DateTime dayend { get; set; }

    }
}