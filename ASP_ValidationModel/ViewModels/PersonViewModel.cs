using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_ValidationModel.ViewModels
{
    public class PersonViewModel
    {
        [Required(ErrorMessage = "Введите своё имя")]
        [StringLength(100, ErrorMessage = "Имя должно содержать от {2} до {1} символов.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите адрес электронной почты")]
        [EmailAddress(ErrorMessage = "Укажите корректный адрес")]
        [Display(Name = "Адрес Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Задайте пароль")]
        [StringLength(100, ErrorMessage = "Пароль должен содержать от {2} до {1} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Необходимо указать возраст")]
        [Display(Name = "Укажите свой возраст")]
        public int Age { get; set; }
    }
}
