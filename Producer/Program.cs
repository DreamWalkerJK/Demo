using RabbitMQ.Client;
using System.Text;

namespace Producer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 创建连接工厂
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "guest", // 用户名
                Password = "guest", // 密码
                HostName = "localhost", // ip
                VirtualHost = "/",
            };

            // 创建RabbitMQ的TCP长连接
            var connection = factory.CreateConnection();

            // 创建通道
            var channel = connection.CreateModel();

            /* 声明队列
             * 参数：
             * queue：被绑定的消息队列名，当该消息队列不存在时，将新建该消息队列
             * durable：是否使用持久化
             * exclusive：该通道是否独占该队列
             * autoDelete：消息完成时是否删除队列
             * args：其他配置参数
            */
            channel.QueueDeclare("hello", false, false, false, null);

            Console.WriteLine("\nRabbitMQ连接成功，生产者已启动，请输入消息，输入exit退出！");

            string input = string.Empty;

            do
            {
                input = Console.ReadLine();

                var sendBytes = Encoding.UTF8.GetBytes(input);

                // 发布消息
                channel.BasicPublish("", "hello", null, sendBytes);
            }
            while(input.Trim().ToLower() != "exit");

            channel.Close();
            connection.Close();
        }
    }
}