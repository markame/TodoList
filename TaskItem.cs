using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class TaskItem
    {
        public string TaskName { get; set; }
        public string Category { get; set; } // Nova propriedade para categoria
        public DateTime DueDate { get; set; } // Nova propriedade para data de vencimento
    }
}
