using System;
using ToDoManager.Application.Abstracts;
using ToDoManager.Application.Dtos.LogViewDtos;
using ToDoManager.Persistence.Context;

namespace ToDoManager.Persistence.Concretes
{
    public class LogViewService : ILogViewRepository
    {
        private readonly ToDoManagerDbContext _dbContext;

        public LogViewService(ToDoManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ResultLogViewDto> GetLogView()
        {
            var values = _dbContext.LogView.ToList();
            return values.Select(x => new ResultLogViewDto
            {
                CheckpointId = x.checkpoint_id,
                CheckpointName = x.checkpoint_name,
                ServerId = x.server_id,
                ServerName = x.server_name,
                ServerIp = x.server_ip,
                UserId = x.user_id,
                UserName = x.user_name,
                UserSurname = x.user_surname

            }).ToList();
        }
    }
}

