using ToDoManager;
namespace ToDo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UpdateJson.load();

            Boolean flag = false;

            do
            {
                Console.WriteLine("****************************************************************************************");
                Console.WriteLine("Choose from Below by Entering their corresponding number");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("1. Add a new task with a title and description.");
                Console.WriteLine("2. View all tasks.");
                Console.WriteLine("3. View a specific task by its ID.");
                Console.WriteLine("4. Mark a task as completed.");
                Console.WriteLine("5. Update task details (title, description, completion status)");
                Console.WriteLine("6. Delete a task by its ID");
                Console.WriteLine("7. Save tasks to a file");
                Console.WriteLine("8. Load tasks from the file");

                Console.WriteLine("Enter your Option");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the title and description of the task");
                        Console.WriteLine("Enter the title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter the description");
                        string description = Console.ReadLine();
                        ToDoManager.Task item = new ToDoManager.Task(-1, title, description, false);
                        ToDoManager.Manager.Add(item);
                        Console.WriteLine("Do you want to Save the Task? Enter option 1 to save, 0 otherwise");
                        int cho = Convert.ToInt32(Console.ReadLine());
                        if( cho == 1)
                        {
                            ToDoManager.Manager.SaveTasks();
                        }
                        break;
                    case 2:
                        ToDoManager.Manager.ViewTasks();
                        break;
                    case 3:
                        Console.WriteLine("Enter the id of the task");
                        int id = Convert.ToInt32(Console.ReadLine());
                        ToDoManager.Manager.ViewTaskById(id);
                        break;
                    case 4:
                        Console.WriteLine("Enter the id of the task");
                        int _id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Status of the task --> Choose between --> Completed or NotCompleted");
                        string status = Console.ReadLine();
                        if( status == "Completed")
                        {
                            ToDoManager.Manager.UpdateTaskStatus(_id, true);
                        }
                        else
                        {
                            ToDoManager.Manager.UpdateTaskStatus(_id, false);
                        }
                        break;
                    case 5:
                        ToDoManager.Manager.Update();
                        break;
                    case 6:
                        ToDoManager.Manager.Delete();
                        break;
                    case 7:
                        ToDoManager.Manager.SaveTasks();
                        break;
                    case 8:
                        ToDoManager.Manager.View();
                        break;
                    default:
                        Console.WriteLine("Enter the Right option");
                        break;

                }

                Console.WriteLine("Do you want to Continue Operations? Enter 1 to continue and 0 to exit");
                int dec = Convert.ToInt16(Console.ReadLine());
                if (dec == 0) flag = true;
            }
            while (!flag);

        }
    }
}