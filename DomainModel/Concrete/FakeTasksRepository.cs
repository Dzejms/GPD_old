using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Abstract;
using DomainModel.Entities;

namespace DomainModel.Concrete
{
    public class FakeTasksRepository : ITasksRepository
    {
        static List<Task> tasks;

        public FakeTasksRepository()
        {
            tasks = tasks ?? new List<Task>();
        }

        public bool Save(Task task)
        {
            bool result = false;
            if (task.ID == 0)
            {
                task.ID = NextId();
                tasks.Add(task);
            } 
            else
            {
                tasks.First(x => x.ID == task.ID).Description = task.Description;
            }
            result = true;
            return result;
        }

        private static int NextId()
        {
            if (tasks.Count == 0)
                return 1;
            return tasks.Max(x => x.ID) + 1;
        }

        public IQueryable<Task> Tasks
        {
            get
            {
                return tasks.AsQueryable();
            }
            set
            {
                tasks = value.ToList();
            }
        }
    }
}
