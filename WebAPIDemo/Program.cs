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

            // ʹ�� Autofac
            // 1.PMC �ﰲװ��
            // install-package Autofac
            // install-package Autofac.Extensions.DependencyInjection

            // 2.�滻���õ�DI
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            // 3.ע��
            // ע�����������
            // a.˲ʱ InstancePerDependency��ÿ�λ�ȡ�ķ��񶼲�һ��
            // b.���� SingleInstance�������������л�ȡ�ķ���ʵ������ͬһ��
            // c.������ InstancePerLifetimeScope����ͬ�������»�ȡ�ķ���ʵ����ͬ
            // d.ָ��������InstancePerMatchingLifttimeScope("����������")������ָ����ĳ������������
            // e.ÿ������InstancePerRequest����ͬ�������ȡ�ķ���ʵ����һ��
            // f.��ʽ��ϵ���͵�Ƕ��������InstancePerOwned������ʹ��ÿһ��ӵ��ʵ����ע����������ϵ�޶���ӵ�е�ʵ��
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