using System;
using System.Collections.Generic;
using ToDoList.Common;

namespace ToDoList.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IToDoRepositoryInMemory _repository = new ToDoRepositoryInMemory();
            List<ToDo> toDos = new List<ToDo>();

            //CRUD(Read)
            toDos = _repository.GetAll();
            foreach (var t in toDos)
            {
                Console.WriteLine($"ID: {t.Id}, Title: {t.Title}, is done: {t.IsDone}");
            }
            Console.WriteLine("Default Database");

            //CRUD(Create)
            ToDo todo = new ToDo {Title = "SQL", IsDone = true };
            _repository.Add(todo);

            //CRUD(Read)
            toDos = _repository.GetAll();
            foreach (var t in toDos)
            {
                Console.WriteLine($"ID: {t.Id}, Title: {t.Title}, is done: {t.IsDone}");
            }
        }
    }
}
