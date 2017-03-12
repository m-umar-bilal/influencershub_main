using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TextClassification;
using TweetsAndTrends;

namespace TextPreProcessing.BLL
{
    class main
    {
        public static void func()
        {
            Console.WriteLine("Hello");
        }
        private static void TimerCallback(Object o)
        {
            var startTime = DateTime.UtcNow;
            // Display the date/time when this method got called.
            Console.WriteLine("\nClassifying Trends Started At : " + DateTime.Now);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here
            
            NaiveBayes.Classify();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            //var time = elapsedMs / 1000;
            Console.WriteLine("Function finished in "+ TimeSpan.FromMilliseconds(elapsedMs).ToString() + " minutes");
            // Force a garbage collection to occur for this demo.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            

            while (DateTime.UtcNow - startTime < TimeSpan.FromMinutes(5))
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(stopwatch.Elapsed.TotalSeconds));
                Console.Write(timeSpan.ToString("c"));
                Console.Write('\r');
            }
            Console.Clear();
            GC.Collect();
        }
        public static void Main()
        {
            // Create a Timer object that knows to call our TimerCallback
            // method once every 2000 milliseconds.
            Timer t = new Timer(TimerCallback, null, 0, 300000);
            // Wait for the user to hit <Enter>
            //Console.WriteLine(DateTime.Today.AddDays(-7));
            //Trends.GetTrendsOfCurrentWeekThatAreClassified();
            Console.ReadLine();
            //NaiveBayes.Classify();
            // while (true)
            // {
            // func();
            //  Thread.Sleep(5000);
            // }
        }
    }
}
