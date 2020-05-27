using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMACH_MK_I.Models
{
    public class User_LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Pass { get; set; }
    }
}
