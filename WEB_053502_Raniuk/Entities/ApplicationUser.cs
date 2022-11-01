using Microsoft.AspNetCore.Identity;

namespace WEB_053502_Raniuk.Entities;


    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
        public string ImageMimeType { get; set; }
        
    }
