using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Quartz;
using Quartz.Impl;

using ConsoleApp.Quartz;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();

            stock.priceUpdateEventHandler += stock_priceUpdateEventHandler;
            //stock.PriceChange();
            stock.Price = 10;
            stock.Price = 20;

            Console.ReadLine();

            //DemoDBContext dbContext = new DemoDBContext();
            //var person = new Person()
            //{
            //    ID = Guid.NewGuid().ToString(),
            //    UserName = "测试"
            //};
            //dbContext.Person.Add(person);
            //dbContext.SaveChanges();

            ISchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler();

            DateTimeOffset runTime = DateBuilder.EvenMinuteDate(DateTimeOffset.UtcNow);
            runTime = new DateTimeOffset(DateTime.Now.AddSeconds(60));

            IJobDetail job = JobBuilder.Create<JobDemo>()
                .WithIdentity("job1", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("job1", "group1")
                .StartAt(runTime)
                .Build();

            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();

            System.Threading.Thread.Sleep(1000);

            scheduler.Shutdown();

            Console.WriteLine("end");
            Console.ReadLine();


        }

        static void stock_priceUpdateEventHandler(double price)
        {
            Console.WriteLine("股票价格变动:{0}", price);
        }
    }

    public delegate void UpdateDelegate(double price);

    public class Stock{

        public event UpdateDelegate priceUpdateEventHandler;

        public String Name { get; set; }
        private double _price;
        public double Price {
            set {
                Console.WriteLine(_price);
                _price = value;
                if (priceUpdateEventHandler != null)
                    priceUpdateEventHandler(_price);
            }
        }

        public void AddNotice(UpdateDelegate upDel) {
            priceUpdateEventHandler += upDel;
        }

        public void RemoveNotice(UpdateDelegate upDel) {
            priceUpdateEventHandler -= upDel;
        }

        public void PriceChange() {
            if (priceUpdateEventHandler != null) priceUpdateEventHandler(_price);
        }

    }

}
