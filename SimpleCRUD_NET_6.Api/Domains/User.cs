using System;

namespace SimpleCRUD_NET_6.Api.Domains
{
    public enum UserType
    {
        Admin,
        Others,
        Mobile
    }

    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        // public UserType UserType { get; set; }
        // public string Password { get; set; }
        // public bool IsBlockFromLogin { get; set; }
        // public DateTime CreateDate { get; set; }
        // public int InvalidLoginCount { get; set; }
        // public string PhoneNumber { get; set; }
        // public string CountryCode { get; set; }
        // public string TwoFactorSecretKey { get; set; }
        // public DateTime? TwoFactorSetupDate { get; set; }
        // public bool IsActive { get; set; }

    }


}