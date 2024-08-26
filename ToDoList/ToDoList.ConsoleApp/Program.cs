using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Common;

namespace ToDoList.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IToDoRepository _repository = new ToDoRepositoryInMemory();
            List<ToDo> toDos = new List<ToDo>();

            //Read
            toDos = _repository.GetAll();

            foreach (var t in toDos)
            {
                Console.WriteLine($"ID: {t.Id}, Title: {t.Title}, is done: {t.IsDone}");
            }
            Console.WriteLine("Default Database");

            //Add
            ToDo todo = new ToDo { Title = "SQL", IsDone = true };
            _repository.Add(todo);

            //Read
            toDos = _repository.GetAll();

            foreach (var t in toDos)
            {
                Console.WriteLine($"ID: {t.Id}, Title: {t.Title}, is done: {t.IsDone}");
            }

            //Browse
            string toDoTitle = "";
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
                Console.WriteLine($"Title { toDoTitle} 카테고리가 없다.");
            }
        }
    }
}
