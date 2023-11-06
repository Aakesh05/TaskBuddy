using TaskApp.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        //Catches the Mdoels
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }

        //Stores different Tasks and Catergories
        public MainViewModel()
        {
            FileData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        //Updates Tasks and Catorgies if added
        private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }
        //All the already added Data
        private void FileData()
        {
            Categories = new ObservableCollection<Category>()
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Customer Reminder",
                    Color = "#7f1d06"
                },

                new Category
                {
                    Id = 2,
                    CategoryName = "Foods/Baking",
                    Color = "#552309"
                },

                new Category
                {
                    Id = 3,
                    CategoryName = "To buy?",
                    Color = "#743911"
                },

                new Category
                {
                    Id = 4,
                    CategoryName = "Cleaning",
                    Color = "#dea874"
                }

            };

            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Call Cassie for her Sunday Bread",
                    Completed = false,
                    CategoryId = 1,
                },

                new MyTask
                {
                    TaskName = "Call Joe for his Wife's Muffin",
                    Completed = false,
                    CategoryId = 1,
                },

                new MyTask
                {
                    TaskName = "Birthday Cake (Carrot Shaped)",
                    Completed = false,
                    CategoryId = 2,
                },

                new MyTask
                {
                    TaskName = "Sourdough Bread",
                    Completed = false,
                    CategoryId = 2,
                },

                new MyTask
                {
                    TaskName = "3 Trays Eggs (24 Row)",
                    Completed = false,
                    CategoryId = 3,
                },

                new MyTask
                {
                    TaskName = "New Oven (Check Stoke Interiors)",
                    Completed = false,
                    CategoryId = 3,
                },

                new MyTask
                {
                    TaskName = "Dough Mixer Hard Clean",
                    Completed = false,
                    CategoryId = 4,
                },

                  new MyTask
                {
                    TaskName = "Shelves Dusting",
                    Completed = false,
                    CategoryId = 4,
                    
                }
            };

            UpdateData();
        }

        //Update Data Method
        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                           where t.CategoryId == c.Id
                           select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var noComleted = from t in tasks
                                 where t.Completed == false
                                 select t;

                c.PendingTasks = noComleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }

            //This uses the ColorConverter.cs to match the Task and Catergory together
            foreach (var t in Tasks)
            {
                var catColor = 
                    (
                        from c in Categories
                        where c.Id == t.CategoryId
                        select c.Color
                     ).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    }
}
