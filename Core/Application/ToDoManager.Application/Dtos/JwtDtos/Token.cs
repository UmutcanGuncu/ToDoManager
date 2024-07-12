using System;
namespace ToDoManager.Application.Dtos.JwtDtos
{
	public class Token
	{
		public string AccessToken { get; set; }
		public DateTime Expiration { get; set; }
	}
}

