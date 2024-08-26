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

        //Add
        void Add(ToDo model);

        //Delete
        bool Delete(int id);

        //Search

        //Has

        //Ordering

        //paging





    }
}
