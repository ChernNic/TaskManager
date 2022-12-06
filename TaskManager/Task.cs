using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    class Task
    {
        public string Name;
        public long Memory;
        public int Id;

        public Task(string name, int id, long memory)
        {
            Name = name;
            Memory = memory;
            Id = id;
        }
    }
}
