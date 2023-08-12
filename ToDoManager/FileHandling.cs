using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ToDoManager
{
    public static class FileHandling
    {
        public static void SaveTasksToFile(List<Task> taskList){
            UpdateJson.Update(taskList);
        }

        public static void LoadTasksFromFile()
        {
            string fileText = File.ReadAllText(UpdateJson.path);

            var TaskList = JsonConvert.DeserializeObject<List<Task>>(fileText)
                      ?? new List<Task>();

            Console.Write("Task Id");
            Console.Write(" ");
            Console.Write(" ");
            Console.Write("Task Title");
            Console.Write(" ");
            Console.Write(" ");
            Console.Write("Task Description");
            Console.Write(" ");
            Console.Write(" ");
            Console.Write("Task Status");

            foreach( Task task in TaskList)
            {
                Console.Write(task.TaskId);
                Console.Write(" ");
                Console.Write(" ");
                Console.Write(task.Title);
                Console.Write(" ");
                Console.Write(" ");
                Console.Write(task.Description);
                Console.Write(" ");
                Console.Write(" ");
                if( task.IsCompleted)
                {
                    Console.Write("Completed");
                }
                else
                {
                    Console.Write("Not Completed");
                }
            }
        }


    }
}
