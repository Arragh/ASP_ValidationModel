using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_ValidationModel.ViewModels
{
    public class PersonViewModel
    {
        [Required(ErrorMessage = "Необходимо ввести имя")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо ввести адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Необходимо ввести пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Необходимо указать возраст")]
        public int Age { get; set; }
    }
}
