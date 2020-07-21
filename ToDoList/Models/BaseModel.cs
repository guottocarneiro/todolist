using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    
    public abstract class BaseModel
    {
        public int Id { get; protected set; }
    }
}
