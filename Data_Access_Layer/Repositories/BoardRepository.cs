﻿using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class BoardRepository : Repository<Board>, IBoardRepository
    {
        private readonly DataContext _dataContext;
        public BoardRepository(DataContext dataContext)
            :base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<IEnumerable<Board>> GetAllEntityAsync()
        {
            var boards = await _dataContext.Boards.Include(b => b.Todos).ToListAsync();
            return boards;
        }
    }
}

