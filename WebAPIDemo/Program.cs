using Autofac;
using Autofac.Extensions.DependencyInjection;
using Demo.Implement;
using Demo.Inteface;

namespace WebAPIDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // 使用 Autofac
            // 1.PMC 里安装：
            // install-package Autofac
            // install-package Autofac.Extensions.DependencyInjection

            // 2.替换内置的DI
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            // 3.注入
            // 注入的声明周期
            // a.瞬时 InstancePerDependency：每次获取的服务都不一样
            // b.单例 SingleInstance：在整个容器中获取的服务实例都是同一个
            // c.作用域 InstancePerLifetimeScope：相同作用域下获取的服务实例相同
            // d.指定作用域InstancePerMatchingLifttimeScope("作用域名称")：可以指定到某个具体作用域
            // e.每次请求InstancePerRequest：不同的请求获取的服务实例不一样
            // f.隐式关系类型的嵌套作用域InstancePerOwned：可以使用每一个拥有实例的注册来依赖关系限定到拥有的实例
            builder.Host.ConfigureContainer<ContainerBuilder>(container =>
            {
                container.RegisterType<TestIOC>().As<ITestIOC>().SingleInstance();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}