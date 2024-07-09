using System;
namespace ToDoManager.WebAPI.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string type, object id)
           : base($"{type} türündeki {id} id değerine sahip olan obje bulunamadı! ") { }
    }
}

