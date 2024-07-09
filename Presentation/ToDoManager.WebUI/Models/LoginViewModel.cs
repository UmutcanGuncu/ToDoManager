using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoManager.WebUI.Models
{
	public class LoginViewModel
	{
        [Required(ErrorMessage = "Lütfen E Posta Adresinizi Giriniz")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Lütfen E Posta Adresinizi Uygun Formatta Giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        [MinLength(6, ErrorMessage = "Şifreniz Minimum 6 Karakter Olmalıdır")]
        public string Password { get; set; }
	}
}

