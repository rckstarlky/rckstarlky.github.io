using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Service.Models
{
    public class Country1
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        //public string Country { get; set; }
        public string Country { get; set; }
    }

    public class nregister
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsProvider{ get; set; }
    }
}