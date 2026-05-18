using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace ToDoListSystem.Domain.Entities
{
    public enum ToDoStatus
    {
        Todo,
        InProgress,
        Done
    }
}
