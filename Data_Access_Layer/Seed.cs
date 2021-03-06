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
            if (!context.Todos.Any())
            {
                var todos = new List<Todo>{

                    new Todo
                    {
                        Title = "Past Todo 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Todo 2 months ago",
                        Priority=Enum.Priority.low
                    },
                    new Todo
                    {
                        Title = "Past Activity 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Activity 1 month ago",
                         Priority=Enum.Priority.low
                    },
                    new Todo
                    {
                        Title = "Future Todo 1",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Todo 1 month in future",
                         Priority=Enum.Priority.low
                    },
                    new Todo
                    {
                        Title = "Future Todo 2",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Todo 2 months in future",
                         Priority=Enum.Priority.low
                    },
                    new Todo
                    {
                        Title = "Future Todo 3",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "Todo 3 months in future",
                         Priority=Enum.Priority.normal
                    },
                    new Todo
                    {
                        Title = "Future Todo 4",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "Todo 4 months in future",
                         Priority=Enum.Priority.normal
                    },
                    new Todo
                    {
                        Title = "Future Todo 5",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Todo 5 months in future",
                         Priority=Enum.Priority.normal
                    },
                    new Todo
                    {
                        Title = "Future Todo 6",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "Todo 6 months in future",
                         Priority=Enum.Priority.normal
                    },
                    new Todo
                    {
                        Title = "Future Todo 7",
                        Date = DateTime.Now.AddMonths(7),
                        Description = "Todo 2 months ago",
                         Priority=Enum.Priority.high
                    },
                    new Todo
                    {
                        Title = "Future Todo 8",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Todo 8 months in future",
                        Priority=Enum.Priority.high
                    }
                };
                context.Todos.AddRange(todos);
                context.SaveChanges(); 
            }
        }
    }
}