using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace ToDoManager
{
    public static class UpdateJson
    {
        public static string path = @"C:\Users\ManishBawkar\OneDrive - Kongsberg Digital AS\Desktop\ToDoApp\ToDo\ToDo\Tasks.json"; 
        
        
        public static void load()
        {
            if( File.Exists(path) )
            {
                var jsondata = File.ReadAllText(path);

                var TaskList = JsonConvert.DeserializeObject<List<Task>>(jsondata)
                      ?? new List<Task>();

                foreach( Task item in TaskList )
                {
                    ToDoManager.Manager.tasks.Add(item);
                }
            }
        }
        
        public static void Update(List<Task> tasks)
        {
            var jsonData = JsonConvert.SerializeObject(tasks);

            File.WriteAllText(path, jsonData);

        }
    }
}
