using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Common
{
    public class ToDoRepositoryInMemory : IToDoRepositoryInMemory
    {
        //collection for sharing
        private static List<ToDo> _todos = new List<ToDo>();

        //Constructor
        public ToDoRepositoryInMemory()
        {
            //_todos = new List<ToDo>();// Collection Initializer 

            //Collection Initializer + Object Initializer
            _todos = new List<ToDo> 
            { 
                new ToDo { Id = 1, Title = "C#", IsDone = true },
                new ToDo { Id = 2, Title = "WPF", IsDone = true },
                new ToDo { Id = 3, Title = ".NET", IsDone = false }
            };
        }

        public void Add(ToDo model)
        {
            model.Id = _todos.Max(t => t.Id) + 1;
            _todos.Add(model);
        }

        public List<ToDo> GetAll()
        {
            return _todos.ToList();
        }
    }
}
