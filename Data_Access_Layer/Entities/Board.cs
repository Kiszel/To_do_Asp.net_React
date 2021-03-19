using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual List<Todo> Todos { get; set; }
    }
}
