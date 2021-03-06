using Data_Access_Layer.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime Date { get; set; }
    }
}
