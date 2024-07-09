
using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoManager.WebUI.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage ="Lütfen Adınızı Giriniz")]
		public string? Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Lütfen E Posta Adresinizi Giriniz")]
        //[RegularExpression("@\"^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$\")")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",ErrorMessage ="Lütfen E Posta Adresinizi Uygun Formatta Giriniz")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Lütfen Telefon Numaranızı Giriniz")]
        [RegularExpression(@"^(?:\+90.?5|0090.?5|905|0?5)(?:[01345][0-9])\s?(?:[0-9]{3})\s?(?:[0-9]{2})\s?(?:[0-9]{2})$", ErrorMessage = "Lütfen Telefon Numaranızı Formata Uygun Giriniz")]
         public string? Phone { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        [MinLength(6, ErrorMessage = "Şifreniz Minimum 6 Karakter Olmalıdır")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
        [MinLength(6, ErrorMessage = "Şifreniz Minimum 6 Karakter Olmalıdır")]
        public string? ConfirmPassword { get; set; }
	}
}

