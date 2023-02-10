using System;

namespace SimpleCRUD_NET_6.Api.Domains
{
   
    public class User
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public int? PhoneNumber { get; set; }
        public string? CountryCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime BirthDate { get; set; }
        public int? Age { get; set; }
    }


}