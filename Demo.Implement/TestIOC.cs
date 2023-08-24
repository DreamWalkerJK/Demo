using Demo.Inteface;

namespace Demo.Implement
{
    // 实现ITestIOC接口
    public class TestIOC : ITestIOC
    {
        public string GetIOCType(string typeName)
        {
            return typeName;
        }
    }
}
