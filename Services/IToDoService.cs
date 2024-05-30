using System.Collections.Generic;
using ToDoList_GERNALE.Models;

namespace ToDoList_GERNALE.Services
{
    public interface IToDoService
    {
        IEnumerable<ToDoItem> GetAll();
        ToDoItem GetById(int id);
        void Add(ToDoItem item);
        void Update(ToDoItem item);
        void Delete(int id);
    }
}
