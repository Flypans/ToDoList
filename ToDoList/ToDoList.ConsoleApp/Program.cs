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
            int toDoId = 1;
            Console.Write("Insert Id: " );
            string x = Console.ReadLine();

            if (int.TryParse(x, out toDoId))
            {
                Console.Write($"To browse the list in detail, the list ID : {x}  - ");
            }
            else
            {
                Console.WriteLine("유효한 정수 입력하세요.");
            }

            var toDoBrowse = _repository.Browse(toDoId);
/*            
            if (toDoBrowse != null)
            {
                Console.WriteLine($"Browse Id: {toDoBrowse.Id}, Title {toDoBrowse.Title}");
            }
*/
            if (toDoBrowse != null && toDoBrowse.Any())
            {
                foreach (var t in toDoBrowse)
                {
                    Console.WriteLine($"Title: {t.Title}");
                }
            }
            else
            {
                Console.WriteLine($"{ toDoId }번 카테고리가 없다.");
            }
        }
    }
}
