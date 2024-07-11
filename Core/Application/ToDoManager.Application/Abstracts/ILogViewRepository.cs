using System;
using ToDoManager.Application.Dtos.LogViewDtos;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Abstracts
{
	public interface ILogViewRepository
	{
		public List<ResultLogViewDto> GetLogView();
	}
}

