using System;
namespace ToDoManager.Application.Dtos.LogViewDtos
{
	public class ResultLogViewDto
	{
		public int CheckpointId { get; set; }
		public string? CheckpointName { get; set; }
		public int ServerId { get; set; }
		public string? ServerName { get; set; }
		public string? ServerIp { get; set; }
		public int UserId { get; set; }
		public string? UserName { get; set; }
		public string? UserSurname { get; set; }
	}
}

