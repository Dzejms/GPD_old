using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace DomainModel.Abstract
{
    public interface ITasksRepository
    {
        IQueryable<Task> Tasks { get; set; }
        void Save(Task task);
    }
}
