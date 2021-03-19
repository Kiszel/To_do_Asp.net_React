using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public interface IBoardRepository
    {
        Task<Board> GetBoardAsync(int id);
        Task<IEnumerable<Board>> GetAllBoardAsync();
        Task<Board> AddBoardAsync(Board board);
        Task<Board> UpdateAsync(Board boardChanges);
        Task<Board> UpdateRangeAsync(List<Board> boardChangesRange);
        Task<Board> DeleteAsync(int id);
    }
}
