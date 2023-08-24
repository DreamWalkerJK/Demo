namespace ConsoleAppDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var stuList = new List<Student>()
            {
                new Student{ Id = 1, Name = "tom"},
                new Student{ Id = 2, Name = "Jerry"},
                new Student{ Id = 3, Name = "Jack", age = 18},
                new Student{ Id = 4, Name = "Rose", age=25},
                new Student{ Id = 5, Name = "lanyangyang", address = "青青草原"}
            };

            var dt = CommonHelper.ListToDataTable(stuList);

            Console.WriteLine(dt);
        }
    }
}