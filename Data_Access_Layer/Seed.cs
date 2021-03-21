using System.Linq;
using System.Collections.Generic;
using System;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            var todos = new List<Todo>();
            if (!context.Todos.Any())
            {
                var Id = 1;
                todos.Add(new Todo
                {
                    Id = Id++,
                    Title = "Todo 1",
                    Date = DateTime.Now.AddMonths(1),
                    Description = "Todo 1 months in future",
                    Priority = Enum.Priority.low
                });
                todos.Add(new Todo
                {
                    Id = Id++,
                    Title = "Todo 2",
                    Date = DateTime.Now.AddMonths(2),
                    Description = "Todo 2 months in future",
                    Priority = Enum.Priority.low
                });
                todos.Add(new Todo
                {
                    Id = Id++,
                    Title = "Todo 3",
                    Date = DateTime.Now.AddMonths(3),
                    Description = "Todo 3 month in future",
                    Priority = Enum.Priority.low
                });
                todos.Add(new Todo
                {
                    Id = Id++,
                    Title = "Todo 4",
                    Date = DateTime.Now.AddMonths(4),
                    Description = "Todo 4 months in future",
                    Priority = Enum.Priority.low
                });
                todos.Add(new Todo
                {
                    Id = Id++,
                    Title = "Todo 5",
                    Date = DateTime.Now.AddMonths(5),
                    Description = "Todo 5 months in future",
                    Priority = Enum.Priority.normal
                });
                todos.Add(new Todo
                {
                    Id = Id++,
                    Title = "Todo 6",
                    Date = DateTime.Now.AddMonths(6),
                    Description = "Todo 6 months in future",
                    Priority = Enum.Priority.normal
                });
                todos.Add(new Todo
                {
                    Id = Id++,
                    Title = "Todo 7",
                    Date = DateTime.Now.AddMonths(7),
                    Description = "Todo 7 months in future",
                    Priority = Enum.Priority.normal
                });
                todos.Add(new Todo
                {
                    Id = Id++,
                    Title = "Todo 8",
                    Date = DateTime.Now.AddMonths(8),
                    Description = "Todo 8 months in future",
                    Priority = Enum.Priority.normal
                });
                todos.Add(new Todo
                {
                    Id = Id++,
                    Title = "Todo 9",
                    Date = DateTime.Now.AddMonths(9),
                    Description = "Todo 9 months in future",
                    Priority = Enum.Priority.high
                });
                todos.Add(new Todo
                {
                    Id = Id++,
                    Title = "Todo 10",
                    Date = DateTime.Now.AddMonths(10),
                    Description = "Todo 10 months in future",
                    Priority = Enum.Priority.high
                });

                context.Todos.AddRange(todos);
                context.SaveChanges(); 
            }
            if (!context.Boards.Any())
            {
                var boards = new List<Board>{

                    new Board
                    {
                        Todos=todos,
                        Id=1,
                        Title = "Todo",
                    },
                    new Board
                    {
                        Id=2,
                        Title = "In Progress",
                    },
                    new Board
                    {
                        Id=3,
                        Title = "Complete",
                    }
                };

                context.Boards.AddRange(boards);
                context.SaveChanges();
            }
        }
    }
}