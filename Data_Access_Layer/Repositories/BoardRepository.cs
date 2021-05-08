using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        private readonly IDataContext _dataContext;
        public BoardRepository(IDataContext dataContext)
            :base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<IEnumerable<Board>> GetAllEntityAsync()
        {
            var boards = await _dataContext.Boards.Include(b => b.Todos).ToListAsync();
            return boards;
        }
        public  async Task AddTodoToBoard(Todo todo)
        {
            var board = _dataContext.Boards.Include(b => b.Todos).FirstOrDefault();
            if (board == null)
                return;
            board.Todos.Add(todo);
           await _dataContext.SaveChangesAsync();
        }
    }
}

