using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.EF.Models
{
   public class Todo
    {
        public int id { get; set; }
        public string task { get; set; }

        public string status { get; set; }
    }
}
