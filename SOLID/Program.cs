using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static IKernel IOC { get; set; }

        static void Main(string[] args)
        {
            IOC = new StandardKernel();
            IOC.Bind<IReportGenerator>().To<MyHtmlReportGenerator>().InSingletonScope();

            DoStuff();
            Console.ReadKey();
            IOC.Unbind<IReportGenerator>();
            IOC.Bind<IReportGenerator>().To<MyTestReportGenerator>().InSingletonScope();

            DoStuff();
            Console.ReadKey();

            IOC.Unbind<IReportGenerator>();
            IOC.Bind<IReportGenerator>().To<MyReportGenerator>().InSingletonScope();

            DoStuff();
            Console.ReadKey();
        }

        static void DoStuff()
        {
            var myProgram = new MyProgram(IOC.Get<IReportGenerator>());
            myProgram.Foo();
        }
    }

    class MyProgram
    {
        IReportGenerator reportGenerator;

        public MyProgram(IReportGenerator reportGenerator)
        {
            this.reportGenerator = reportGenerator;
        }

        public void Foo()
        {
            reportGenerator.Generate();
        }
    }

    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
    }

    class Employee : Person
    {
        public DateTime HireDate { get; set; }
    }

    interface IMessage
    {
        string Reciever { get; set; }
        string Sender { get; set; }
    }

    class MailMessage : IMessage
    {
        public string Sender { get; set; }
        public string Reciever { get; set; }
    }
    
    class MailSender
    {
        public string SmtpAdress { get; set; }
        public void Send(IMessage message)
        {

        }
    }

    interface IReportGenerator
    {
        void Generate();
    }

    class MyReportGenerator : IReportGenerator
    {
        public void Generate()
        {
            Console.WriteLine("Generating from MyReportGenerator");
        }
    }

    class MyHtmlReportGenerator : IReportGenerator
    {
        public void Generate()
        {
            Console.WriteLine("Generating from MyHtmlReportGenerator");
        }
    }

    class MyTestReportGenerator : IReportGenerator
    {
        public void Generate()
        {
            Console.WriteLine("Generating from MyTestReportGenerator");
        }
    }
}
