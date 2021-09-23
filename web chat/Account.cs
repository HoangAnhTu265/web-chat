using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web_chat
{
    public class Account
    {
        [Key]
        [StringLength(32,MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(32,MinimumLength =3)]
        public string Password{ get; set; }
    }
}