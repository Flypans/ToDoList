using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Common
{
    public class ToDoRepositoryInMemory : IToDoRepository
    {
        //collection for sharing
        //_todos Variables are reset by the garbage collector when the program ends.
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
/*
        public ToDo Browse(int id)
        {
            return _todos.Where(t => t.Id == id).SingleOrDefault();
        }
*/
        public List<ToDo> Browse(int id)
        {
         return _todos.Where(t => t.Id == id).ToList();
        }
}
}
