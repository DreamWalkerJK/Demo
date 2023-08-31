using Demo.Model;
using Demo.CommonHelper;

namespace ConvertConsoleDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dataReplica = new DataReplica
            {
                Id = 1,
                Name = "Name",
                CutName = "CutName",
                SimpleName = "SimpleName",
                Category = "Category",
                Displacement = "Displacement",
                Years = "Years",
                IsDel = 0,
                Status = 2,
                IsSendToLocal = true,
                AddDate = DateTime.Now,
                UpdateDate = DateTime.Now
            };

            var data = ConvertHelper.ConvertClass<DataReplica, Data>(dataReplica);

            Console.WriteLine(data);
        }
    }
}