﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel.Entities;

namespace ProductivityApp.Models
{
    public class EditTaskViewModel
    {
        public Task Task { get; set; }

        public EditTaskViewModel(Task newTask)
        {
            this.Task = newTask;
        }
    }
}