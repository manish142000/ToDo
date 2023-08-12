using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace ToDoManager
{
    public static class Manager
    {
        public static List<Task> tasks = new List<Task> ();

        public static void Add(Task item)
        {
            int last = 0;
            foreach( var task in tasks )
            {
                last = Math.Max(task.TaskId, last);
            }
            last ++;
            item.TaskId = last;

            tasks.Add(item);
        }

        public static void SaveTasks()
        {
            UpdateJson.Update(tasks);
        }

        public static void ViewTasks()
        {
            Console.WriteLine("Tasks");

            int i = 0;
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task ----> {i}"); 
                Console.WriteLine($"Task Id ----> {task.TaskId}");
                Console.WriteLine($"Task Title ----> {task.Title}");
                Console.WriteLine($"Task Description ----> {task.Description} ");
                if (task.IsCompleted)
                {
                    Console.WriteLine("Task Status ----> Task completed");
                }
                else
                {
                    Console.WriteLine("Task Status ----> Not Completed");
                }
                Console.WriteLine();
                i++;
            }
        }

        public static void View()
        {
            Console.WriteLine("Tasks");

            var jsondata = File.ReadAllText(UpdateJson.path);

            var TaskList = JsonConvert.DeserializeObject<List<Task>>(jsondata)
                      ?? new List<Task>();

            foreach (var task in TaskList)
            {
                Console.WriteLine($"Task Id ----> {task.TaskId}");
                Console.WriteLine($"Task Title ----> {task.Title}");
                Console.WriteLine($"Task Description ----> { task.Description} ");
                if (task.IsCompleted)
                {
                    Console.WriteLine("Task Status ----> Task completed");
                }
                else
                {
                    Console.WriteLine("Task Status ----> Not Completed");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void ViewTaskById(int id)
        {
            List<Task> TaskList = tasks;
           
            try
            {
                Task item = TaskList.First(d => d.TaskId == id);

                Console.WriteLine($"Task Id ----> {item.TaskId}");
                Console.WriteLine($"Task Title ----> {item.Title}");
                Console.WriteLine($"Task Description ----> {item.Description}");
                if (item.IsCompleted)
                {
                    Console.WriteLine("Task Status ----> Completed");
                }
                else
                {
                    Console.WriteLine("Task Status ----> Not Completed");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.GetType());
            }
            Console.WriteLine();
        }

        public static void Update()
        {

            Console.WriteLine("Enter the id of task");
            int _id = Convert.ToInt32(Console.ReadLine());
            bool flag2 = false;
            do
            {
                Console.WriteLine("Enter The value to update");
                Console.Write(' ');
                Console.Write("Title");
                Console.Write(' ');
                Console.Write("Description");
                Console.Write(' ');
                Console.Write("Status");
                Console.WriteLine();
                string val = Console.ReadLine();
                
                try
                {
                    switch (val)
                    {
                        case "Title":
                            Console.WriteLine("Enter the new Title");
                            string title = Console.ReadLine();
                            tasks.First(d => d.TaskId == _id).Title = title; break;
                        case "Description":
                            Console.WriteLine("Enter the new Description");
                            string description = Console.ReadLine();
                            tasks.First(d => d.TaskId == _id).Description = description; break;
                        case "Status":
                            Console.WriteLine("Enter the status : Completed/Not Completed");
                            string status = Console.ReadLine();
                            var flag = false;
                            if (status == "Completed")
                            {
                                flag = true;
                            }
                            else
                            {
                                flag = false;
                            }
                            tasks.First(d => d.TaskId == _id).IsCompleted = flag;
                            break;
                        default:
                            Console.WriteLine("Wrong Option Chosen");
                            break;
                    }
                }
                catch( Exception ex)
                {
                    Console.WriteLine(ex.GetType);
                }

                Console.WriteLine("Press 1 to continue Updating the task and 0 to exit");
                int cont = Convert.ToInt32(Console.ReadLine());
                if (cont == 0) flag2 = true;

            } while(!flag2);

            Console.WriteLine("Do you want to save the changes to file? Enter 1 to save and 0 otherwise");

            int choice = Convert.ToInt32(Console.ReadLine());

            if( choice == 1)
            {
                UpdateJson.Update(tasks);
            }

        }

        public static void Delete()
        {
            Console.WriteLine("Enter the id of the task to delete");

            int id = Convert.ToInt32(Console.ReadLine());

            Task task = tasks.First(d => d.TaskId == id);

            tasks.Remove(task);

            Console.WriteLine("Task successfully Removed");

            Console.WriteLine("Do you want to update the file? Enter 1 for saving changes otherwise 0.");

            int choice = Convert.ToInt32(Console.ReadLine());

            if( choice == 1)
            {
                UpdateJson.Update(tasks);
            }
        }

        public static void UpdateTaskStatus(int id, Boolean flag)
        {
            tasks.First( d => d.TaskId == id ).IsCompleted = flag;

            Console.WriteLine("Do you want to update the file? Enter 1 for saving changes otherwise 0.");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                UpdateJson.Update(tasks);
            }
        }
    }
}

