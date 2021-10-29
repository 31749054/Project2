using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PROJEK2.Models
{
    public class usermodel
    {   [Display(Name = "User ID")]
        [Range(100000, 999999, ErrorMessage = "You need to  enter a valid User ID")]
        public int USER_ID { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage ="You need to enter a valid User Name")]
        public string USER_NAME { get; set; }

        [Display(Name = "User Password")]
        [Required(ErrorMessage = "You need to enter a valid User Password")]
        [DataType(DataType.Password)]
       [StringLength(100, MinimumLength = 5, ErrorMessage = "You need to enter a longer Password")]
        public string USER_PASSWORD { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Email")]
        [Required(ErrorMessage = "You need to enter a valid User Email")]
        
        public string USER_EMAIL { get; set; }

    }
}