using System.Collections.Generic;

namespace ToDoList.Common
{
    public interface IToDoRepository
    {
        //Method Signature
        void Add(ToDo model);//Create
        List<ToDo> GetAll(); //Read

        //Update
        //Delete
    }
}
