using System.Collections.Generic;

namespace ToDoList.Common
{
    public interface IToDoRepository
    {
        //Method Signature
        //    Add
        void Add(ToDo model);

        //Read
        List<ToDo> GetAll();

        //Browse
        //ToDo Browse(int id);
        List<ToDo> Browse(int id);

        //    Edit
        //    Delete
        //    Search
        //    Has
        //    Ordering
        //    paging





    }
}
