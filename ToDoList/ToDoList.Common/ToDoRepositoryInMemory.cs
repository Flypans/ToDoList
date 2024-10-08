﻿using System.Collections.Generic;
using System.Linq;
using static ToDoList.Common.OrderTypes;

namespace ToDoList.Common
{
    /// <summary>
    /// Repository Implementation
    /// </summary>
    public class ToDoRepositoryInMemory : IToDoRepository
    {
        //collection for sharing
        //_todos Variables are reset by the garbage collector when the program ends.
        private static List<ToDo> _todos = new List<ToDo>();

        //Constructor
        public ToDoRepositoryInMemory()
        {
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
        public List<ToDo> Browse(string title)
        {
            return _todos.Where(t => t.Title.Equals(title)).ToList();
        }

        public bool Delete(int id)
        {
            int removedCount = _todos.RemoveAll(c => c.Id == id);

            if (removedCount > 0)
            {
                return true;
            }
            return false;
        }

        public bool Edit(ToDo model)
        {
            /*
                        var result = _todos.Where(c => c.Id == model.Id)
                            .Select(c => { c.Title = model.Title; return c; })
                            .SingleOrDefault();
            */
            var result = _todos.FirstOrDefault(c => c.Id == model.Id);

            if (result != null)
            {
                result.Title = model.Title;
                result.IsDone = model.IsDone;
                return true;
            }
            return false;
        }
        public List<ToDo> Search(string query)
        {
            return _todos.Where(c => c.Title.Contains(query)).ToList();
        }

        public int Has()
        {
            return _todos.Count();
        }

        public IEnumerable<ToDo> Ordering(OrderOption orderOption)
        {
            IEnumerable<ToDo> toDo;
            switch (orderOption)
            {
                case OrderOption.Ascending:
                    toDo = _todos.OrderBy(c => c.Title);
                    break;

                case OrderOption.Descending:
                    toDo = _todos.OrderByDescending(c => c.Title);
/*
                    toDo = from todo in _todos
                           orderby todo.Title descending
                           select todo;
*/
                    break;

                default:
                    toDo = _todos;
                    break;
            }
            return toDo;
        }

        public List<ToDo> Paging(int pageNumber = 1,  int pageSize = 10)
        {
            return _todos.Skip((pageNumber -1) * pageSize).Take(pageSize).ToList();
        }

    }
}
