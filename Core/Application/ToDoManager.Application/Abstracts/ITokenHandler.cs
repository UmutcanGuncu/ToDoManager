using System;
using ToDoManager.Application.Dtos.JwtDtos;

namespace ToDoManager.Application.Abstracts
{
	public interface ITokenHandler
	{
		public Token CreateAccessToken(int minute);
	}
}

