using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSheduler.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Passowrd { get; set; }

        [Required]
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
