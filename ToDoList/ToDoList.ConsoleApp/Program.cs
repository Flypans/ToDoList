using System;
using System.Collections.Generic;
using ToDoList.Common;

namespace ToDoList.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test
            IToDoRepositoryInMemory _repository = new ToDoRepositoryInMemory();
            List<ToDo> toDos = new List<ToDo>();
            toDos = _repository.GetAll();
            foreach (var todo in toDos)
            {
                Console.WriteLine($"ID: {todo.Id}, Title: {todo.Title}, is done: {todo.IsDone}");
            }
             
        }
    }
}
