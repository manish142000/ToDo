using Newtonsoft.Json;
using ToDoManager;

namespace ToDoTest
{
    [TestClass]
    public class UnitTest1
    {

        static Boolean CheckIfEqual(ToDoManager.Task task1, ToDoManager.Task task2)
        {
            if(JsonConvert.SerializeObject(task1) == JsonConvert.SerializeObject(task2))
            {
                return true;
            }
            return false;
        }

        [TestMethod]
        public void TestAddItem()
        {
            ToDoManager.Task task = new ToDoManager.Task( 
                11, "Singing", "Singing Tomorrow", false
                );
            ToDoManager.Manager.Add(task);

            ToDoManager.Task task2 = ToDoManager.Manager.tasks.Find(d => d.TaskId == 2);

            Assert.IsTrue(CheckIfEqual(task, task2));
            
        }

        [TestMethod]

        public void SaveTaskTest()
        {
            ToDoManager.Task task = new ToDoManager.Task(
                11, "Singing", "Singing Tomorrow", false
                );

            ToDoManager.Manager.Add(task);

            ToDoManager.Manager.SaveTasks();

            var jsondata = File.ReadAllText(UpdateJson.path);

            var TaskList = JsonConvert.DeserializeObject<List<ToDoManager.Task>>(jsondata);

            ToDoManager.Task task2 = TaskList.Find( d => d.TaskId == 1 );

            Assert.IsTrue(CheckIfEqual(task, task2));
        }


    }
}