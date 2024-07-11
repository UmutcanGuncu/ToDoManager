using System;
namespace ToDoManager.Domain.Entities
{

	public class LogView
	{
		public int checkpoint_id { get; set; }
		public string? checkpoint_name { get; set; }
		public int server_id { get; set; }
		public string? server_name { get; set; }
		public string? server_ip { get; set; }
		public int user_id { get; set; }
		public string? user_name { get; set; }
		public string? user_surname { get; set; }
	}
}

