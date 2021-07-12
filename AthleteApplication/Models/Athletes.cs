using System;
using System.Collections.Generic;

namespace AthleteApplication.Models
{
    public partial class Athletes
    {
        public int AthleteId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string SchoolName { get; set; }
        public string Sport { get; set; }
        public string InstagramHandle { get; set; }
        public string TwitterHandle { get; set; }
        public string StreetAddress { get; set; }
        public string ApartmentNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? ZipCode { get; set; }
        public string MerchSize { get; set; }
    }
}
