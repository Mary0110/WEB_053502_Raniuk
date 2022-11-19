using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WEB_053502_Raniuk.Entities;


    public class ApplicationUser : IdentityUser
    { 
        public byte[]? Avatar { get; set; }
    }
