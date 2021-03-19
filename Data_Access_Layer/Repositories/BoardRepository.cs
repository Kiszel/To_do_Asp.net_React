using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class BoardRepository :IBoardRepository
    {
        private readonly DataContext _dataContext;
        public BoardRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Board> AddBoardAsync(Board board)
        {
            _dataContext.Boards.Add(board);
            await _dataContext.SaveChangesAsync();
            return board;
        }

        public async Task<Board> DeleteAsync(int id)
        {
            var board = await _dataContext.Boards.FindAsync(id);
            if (board != null)
            {
                _dataContext.Boards.Remove(board);
                await _dataContext.SaveChangesAsync();
            }
            return board;
        }

        public async Task<IEnumerable<Board>> GetAllBoardAsync()
        {
            var boards = await _dataContext.Boards.Include(b => b.Todos).ToListAsync();
            return boards;
        }

        public async Task<Board> GetBoardAsync(int id)
        {
            var board = await _dataContext.Boards.Include(b => b.Todos).Where(b => b.Id == id).FirstOrDefaultAsync();
            return board;
        }

        public async Task<Board> UpdateAsync(Board boardChanges)
        {
            var board = await _dataContext.Boards.FindAsync(boardChanges.Id);
            board.Title = boardChanges.Title;
            board.Todos = boardChanges.Todos;
            await _dataContext.SaveChangesAsync();
            return boardChanges;
        }
    }
}

