using System;
using MongoDB.Bson;
using MongoDB.Driver;
using TextClassification;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using System.Linq.Expressions;
using System.Diagnostics;
using DBHandler;

public class TrainingData
{
    string content ="";
    HashSet<string> vocabulary = new HashSet<string>();
    Dictionary<string, double> wordCount = new Dictionary<string, double>();
  //  IDictionary<string, IDictionary<string, double>> wordCounts = new Dictionary<string, IDictionary<string, double>>().WithDefaultValue(new Dictionary<string, double>().WithDefaultValue(0));
    
    string category;
    int limitOfDocsPerCategory = 21000;

    public Dictionary<string, double> WordCount
    {
        get
        {
            return wordCount;
        }
    }

    public HashSet<string> Vocabulary
    {
        get
        {
            return vocabulary;
        }

        set
        {
            vocabulary = value;
        }
    }

    public TrainingData()
    {
       // wordCounts["FoodDrink"] = new Dictionary<string, double>().WithDefaultValue(0);
       // wordCounts["Politics"] = new Dictionary<string, double>().WithDefaultValue(0);
       // wordCounts["ScienceTechnlogy"] = new Dictionary<string, double>().WithDefaultValue(0);
       // wordCounts["SportsGaming"] = new Dictionary<string, double>().WithDefaultValue(0);
    }

        public TrainingData(string category)
        {
            this.category = category;
            Task.Run(async () =>
            {
                try
                {
                    // Start the task.
                    await MakeTrainingData();

                    // Await the task.

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    // Perform cleanup here.
                }

            }).Wait();
        }
        
    private void InitializeDictionary()
    {
     /*   
        content.Clear();
        content = new Dictionary<string, string>();
        var getListTask = Category.GetAllCategories(); // returns the Task<List<TvChannel>>

        Task.WaitAll(getListTask); // block while the task completes

        var list = getListTask.Result;
        // Console.WriteLine(list);


        foreach (var document in list)
        {
            content.Add(document, "");
        }
      
    */

    }
   public static string[] SplitWords(string myStr)
    {
        //return myStr.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        return Regex.Split(myStr, @"\W+");
     
    }
    static string GetName<T>(T item) where T : class
    {
        return typeof(T).GetProperties()[0].Name;
    }
    public static string GetParameterName3<T>(Expression<Func<T>> expr)
    {
        if (expr == null)
            return string.Empty;

        return ((MemberExpression)expr.Body).Member.Name;
    }
    public void ExampleFunction(Expression<Func<string, string>> f)
    {
        Console.WriteLine((f.Body as MemberExpression).Member.Name);
    }


    async Task MakeTrainingData()
    {
        
        wordCount.Clear();
        wordCount = new Dictionary<string, double>();
     //   InitializeDictionary();
        var collection = DBConnector.Database.GetCollection<BsonDocument>(this.category+"CTweets");
        var projection = Builders<BsonDocument>.Projection.Include("tweet").Exclude("_id");
        var builder = Builders<BsonDocument>.Filter;
        // var filter = builder.Eq("trend_category", category);
        var filter = new BsonDocument();
        var options = new FindOptions<BsonDocument> { Projection = projection };
        var count = 0;
        Dictionary<string, double> tempCount=new Dictionary<string, double>();
        using (var cursor = await collection.FindAsync(filter,options))
        {

            while (await cursor.MoveNextAsync())
            {
                var batch = cursor.Current;
                foreach (var document in batch)
                {
                    // process document
                    //content+=TextCleaner.cleanText(document[0].ToString());
                    count++;
           
       
                    content = document[0].ToString();
                    string[] a = SplitWords(content);

                    foreach (var s in a)
                    {
                        tempCount.Clear();
                        try
                        {
                            Vocabulary.Add(s);
                            if (!tempCount.ContainsKey(s))
                            {
                                tempCount[s] = 1;
                            }
                           
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);

                        }
                    }
                    foreach (var v in tempCount)
                    {
                        if (WordCount.ContainsKey(v.Key))
                        {
                            WordCount[v.Key] += 1;
                        }
                        else
                        {
                            wordCount.Add(v.Key, v.Value);
                        }
                    }

                    // Console.WriteLine(count);
                    if (count== limitOfDocsPerCategory)
                    {
                        break;
                    }

                }
                if (count == limitOfDocsPerCategory)
                {
                    break;
                }
            }
            

        }
        
    }
   public void Print()
    {
        //Console.WriteLine(wordCounts["FoodDrink"][""]);
        Task.Run(async () =>
        {
            try
            {
                // Start the task.
                await MakeTrainingData();

                // Await the task.

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Perform cleanup here.
            }

        }).Wait();
        Console.WriteLine("Length of Vocabulary: "+ Vocabulary.Count);
        foreach (var s in WordCount.Keys)
        {//+": "+ wordCounts["FoodDrink"][s]
            Console.WriteLine(s + ": " + WordCount[s]); 
              }
             Console.ReadLine();
    }
}
