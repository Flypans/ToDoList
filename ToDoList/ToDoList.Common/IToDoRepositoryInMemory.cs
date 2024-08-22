using System.Collections.Generic;

namespace ToDoList.Common
{
    public interface IToDoRepositoryInMemory
    {
        //Method Signature
        void Add(ToDo model);//Create
        List<ToDo> GetAll(); //Read

        //Update
        //Delete
    }
}
