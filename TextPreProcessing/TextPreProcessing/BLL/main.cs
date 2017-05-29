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
using UserAccess;

namespace TextPreProcessing.BLL
{
    class main
    {
        public static double ScheduleTime { get; set; } = ConvertHoursToMilliseconds(Settings1.Default.Time);
        public static void func()
        {
            Console.WriteLine("Hello");
        }
        private static void TimerCallback(Object o)
        {
            var startTime = DateTime.UtcNow;
         
            Console.WriteLine("\nClassifying Trends Started At : " + DateTime.Now);
            var watch = System.Diagnostics.Stopwatch.StartNew();
           

            NaiveBayes.Classify();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
           
            Console.WriteLine("Function finished in " + TimeSpan.FromMilliseconds(elapsedMs).ToString() + " minutes");

            Console.WriteLine("\nGetting influencers for latest Trends Started At : " + DateTime.Now);
            watch = System.Diagnostics.Stopwatch.StartNew();
            Influencer i = new Influencer();
            i.UpdateAllInfluencersScore();
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine("Function finished in " + TimeSpan.FromMilliseconds(elapsedMs).ToString() + " minutes");

            Console.WriteLine("Approx. 5 hours till next iteration");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            while (DateTime.UtcNow - startTime < TimeSpan.FromMinutes(Convert.ToInt64(ConvertMillisecondsToMinutes(ScheduleTime))))
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(stopwatch.Elapsed.TotalSeconds));
                Console.Write(timeSpan.ToString("c"));
                Console.Write('\r');
            }
            Console.Clear();
            GC.Collect();
        }
        public static double ConvertHoursToMinutes(double hours)
        {
            return TimeSpan.FromHours(hours).TotalMinutes;
        }
        public static double ConvertHoursToMilliseconds(double hours)
        {
            return TimeSpan.FromHours(hours).TotalMilliseconds;
        }
        public static double ConvertMillisecondsToMinutes(double milliseconds)
        {
            return TimeSpan.FromMilliseconds(milliseconds).TotalMinutes;
        }
        public static void Main()
        {
//            
                        Timer t = new Timer(TimerCallback, null, 0, Convert.ToInt64(ScheduleTime));
                       
                        Console.ReadLine();





//
//            Influencer inf = new Influencer();
//            inf.FillInfluencers();
  
 
        }
    }
}
