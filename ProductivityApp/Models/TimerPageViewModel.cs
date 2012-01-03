using System.Collections.Generic;
using DomainModel.Entities;

namespace ProductivityApp.Models
{
    public class TimerPageViewModel
    {
        public string PageTitle { get; set; }
        public List<Task> Tasks { get; set; }
        public string TimerMinutes { get; set; }
    }
}