using System.Collections.Generic;

namespace ToDoList.Common
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    public interface IToDoRepository
    {
        //Method Signatures

        //Browse
        List<ToDo> Browse(string title);
        
        //Read
        List<ToDo> GetAll();

        //Edit
        bool Edit(ToDo model);

        //Add
        void Add(ToDo model);

        //Delete
        bool Delete(int id);

        //Search
        List<ToDo> Search(string query);

        //Has

        //Ordering

        //paging





    }
}
