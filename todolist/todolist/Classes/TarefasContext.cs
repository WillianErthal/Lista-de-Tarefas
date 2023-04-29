using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todolist.Classes
{
    public class TarefasContext : DbContext
    {
        public DbSet<Tarefas> Tarefas { get; set; }
    }
}
