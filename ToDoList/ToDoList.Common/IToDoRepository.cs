using System.Collections.Generic;

namespace ToDoList.Common
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    public interface IToDoRepository
    {
        //Method Signature
        //    Add
        void Add(ToDo model);

        //Read
        List<ToDo> GetAll();

        //Browse
        List<ToDo> Browse(string title);


        //    Edit
        //    Delete
        //    Search
        //    Has
        //    Ordering
        //    paging





    }
}
