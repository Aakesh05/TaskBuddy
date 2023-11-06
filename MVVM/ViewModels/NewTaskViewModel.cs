using TaskApp.MVVM.Models;
using System;
using System.Collections.ObjectModel;

namespace TaskApp.MVVM.ViewModels
{
    public class NewTaskViewModel
    {
        //Intializes the Views to show in the UI
        public string Task { get; set; }
        public DateTime DueDate { get; set; } // Property for due date
        public TimeSpan ReminderTime { get; set; } // Property for reminder time
        public ObservableCollection<MyTask> Tasks { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        //These are the functions that will show in the Main view UI
        public NewTaskViewModel()
        {
            // Initialize collections and default values
            Tasks = new ObservableCollection<MyTask>();
            Categories = new ObservableCollection<Category>();
            DueDate = DateTime.Now.AddDays(1); // Default due date (tomorrow)
            ReminderTime = TimeSpan.FromHours(9); // Default reminder time (9:00 AM)
        }


    }
}
