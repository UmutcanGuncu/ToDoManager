namespace ToDoManager.Application.Dtos.ServerDtos;

public class UpdateServerDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Ip { get; set; }
}