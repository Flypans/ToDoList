using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Common;

namespace ToDoList.ConsoleApp
{
    class Program
    {
        static IToDoRepository _repository = new ToDoRepositoryInMemory();
        static List<ToDo> toDos = new List<ToDo>();
   
        //Read
        private static void ReadTodoList()
        {
            toDos = _repository.GetAll();

            foreach (var t in toDos)
            {
                Console.WriteLine($"ID: {t.Id}, Title: {t.Title}, is done: {t.IsDone}");
            }
        }

        private static void ToDoPrint(List<ToDo> todos)
        {
            foreach (var todo in todos)
            {
                Console.WriteLine($"ID:{todo.Id}, TiTle: {todo.Title}, is done: {todo.IsDone}");
            }
        }

        static void Main(string[] args)
        {
            //IToDoRepository _repository = new ToDoRepositoryInMemory();
            //List<ToDo> toDos = new List<ToDo>();
            int count = _repository.Has();
            
            //Count
            if (_repository.Has() > 0)
            {
                Console.WriteLine("[Has]");
                Console.WriteLine($"It has {count} default Data.");
            }
            else
            {
                Console.WriteLine("No default Data");

            }
        ReadTodoList();
            Console.WriteLine("Default Data Base");

            //Add
            Console.WriteLine("[Add]");
            ToDo todo = new ToDo { Title = "SQL", IsDone = true };
            _repository.Add(todo);

            ReadTodoList();

            //Browse
            string toDoTitle = "";
            Console.WriteLine("[Browse]");
            Console.Write("Please enter the title of the ToDo item you are looking for: ");

            toDoTitle = Console.ReadLine();

            var matchingToDos = _repository.Browse(toDoTitle);

            if (matchingToDos != null && matchingToDos.Any())
            {
                foreach (var t in matchingToDos)
                {
                    Console.WriteLine($" Title: {t.Title}, Id: {t.Id}, is Done: {t.IsDone}");
                }
            }
            else
            {
                Console.WriteLine($"Title { toDoTitle} is no category.");
            }

            //Delete
            Console.WriteLine("[Delete]");
            Console.Write("Enter the ID you want to delete: ");

            string DeleteId = Console.ReadLine();
            int IdNumber = Convert.ToInt32(DeleteId);

            _repository.Delete(IdNumber);
            Console.WriteLine($"Delete Id: {IdNumber}");

            ReadTodoList();

            //Edit
            //_repository.Edit(new ToDo { Id = 4, Title = "MAUI", IsDone = false });
            Console.WriteLine("[Edit]");
            Console.Write("Please enter the ID  of the task to edit: ");
            int editId = int.Parse(Console.ReadLine());

            Console.Write("Please enter the new title:");
            string editTitle = Console.ReadLine();

            Console.WriteLine("Mark as done ? (y/n)");
            string editIsDone = Console.ReadLine().ToLower();
            bool editIsDoneResulet = editIsDone == "y";

            if (editIsDone == "y" || editIsDone == "n")
            {
                _repository.Edit(new ToDo { Id = editId, Title = editTitle, IsDone = editIsDoneResulet });
            }
            else
            {
                Console.WriteLine("In put Error.");
            }
            ReadTodoList();

            //Search
            Console.WriteLine("[Search]");
            Console.Write($"Please enter the title of the ToDo item you are looking for:");
            //var query = "C#";
            var query = Console.ReadLine();
            var toDo = _repository.Search(query);
            ToDoPrint(toDo);
        }
            
    }
}