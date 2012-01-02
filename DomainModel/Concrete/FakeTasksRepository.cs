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

        public void Save(Task task)
        {
            tasks.Add(task);
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
