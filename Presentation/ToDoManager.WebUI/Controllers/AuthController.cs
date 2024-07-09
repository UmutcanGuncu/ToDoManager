using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDoManager.Domain.Entities;
using ToDoManager.WebUI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoManager.WebUI.Controllers
{
    public class AuthController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonSerializer.Serialize(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://localhost:7293/auth/login", stringContent);
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/Home/Index");
                // e posta ve şifre yanlışsa api'dan gelen mesaja göre hata gösterimi yap
                // kullanıcı bilgilerini cookie ye kaydetmeyi ve ön yüzde de buradaki bilgileri kullanmamızı sağlamalıyız
               
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonSerializer.Serialize(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var result = await client.PostAsync("https://localhost:7293/auth/register", stringContent);
            if (result.IsSuccessStatusCode)
            {
                return Redirect("/Auth/Login");
                
                // kullanıcı kayıt olamadıysa api'dan gelecek olan 401 koduna göre mesaj göster
            }
            return View();
        }
    }
}

