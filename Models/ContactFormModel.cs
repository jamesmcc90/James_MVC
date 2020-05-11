using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace James_MVC.Models
{
    public class ContactFormModel
    {
   
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }


        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter a valid email address.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

       
        [Required(ErrorMessage = "Please enter a message.")]
        public string Message { get; set; }
    }
}
