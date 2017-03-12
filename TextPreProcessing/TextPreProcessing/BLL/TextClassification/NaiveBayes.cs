using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LinqToTwitter;
using UserAccess;
using TweetsAndTrends;
using TwitterHandler;
using UserAccess;

namespace TextClassification
{
    class NaiveBayes
    {

        Dictionary<string, double> FoodDrinkWScore = new Dictionary<string, double>();
        Dictionary<string, double> SportsGamingWScore = new Dictionary<string, double>();
        Dictionary<string, double> PoliticsWScore = new Dictionary<string, double>();
        Dictionary<string, double> TvMoviesWScore = new Dictionary<string, double>();
        Dictionary<string, double> ScienceTechnologyWScore = new Dictionary<string, double>();
        Dictionary<string, double> ArtDesignWScore = new Dictionary<string, double>();
        Dictionary<string, double> FashionWScore = new Dictionary<string, double>();
        Dictionary<string, double> HealthWScore = new Dictionary<string, double>();
        Dictionary<string, double> MusicWScore = new Dictionary<string, double>();
        Dictionary<string, double> ReligionWScore = new Dictionary<string, double>();
        TrainingData FoodDrink = new TrainingData("FoodDrink");//0
        double probofClass = 0.1;
        double score = Math.Log(0.1);

       
        TrainingData Politics = new TrainingData("Politic");//1
        TrainingData TvMovies = new TrainingData("TvMovies");//2
        TrainingData ScienceTechnology = new TrainingData("ScienceTechnlogy");//3
        TrainingData SportsGaming = new TrainingData("SportsGaming");//4
        TrainingData ArtDesign = new TrainingData("ArtDesign");//5
        TrainingData Fashion = new TrainingData("Fashion");//6
        TrainingData Health = new TrainingData("Health");//7
        TrainingData Music = new TrainingData("Music");//8
        TrainingData Religion = new TrainingData("Religion");//9

      
        public NaiveBayes()
        {
            PrepareTrainingData();
        }
        private void PrepareTrainingData()
        {

            HashSet<string> vocab = new HashSet<string>(FoodDrink.Vocabulary);

            vocab.UnionWith(SportsGaming.Vocabulary);
            vocab.UnionWith(Politics.Vocabulary);
            vocab.UnionWith(TvMovies.Vocabulary);
            vocab.UnionWith(ScienceTechnology.Vocabulary);
            vocab.UnionWith(ArtDesign.Vocabulary);
            vocab.UnionWith(Fashion.Vocabulary);
            vocab.UnionWith(Health.Vocabulary);
            vocab.UnionWith(Music.Vocabulary);
            vocab.UnionWith(Religion.Vocabulary);
            FoodDrink.WordCount["rt"] = 1;
            SportsGaming.WordCount["rt"] = 1;
            Politics.WordCount["rt"] = 1;
            TvMovies.WordCount["rt"] = 1;
            ScienceTechnology.WordCount["rt"] = 1;
            ArtDesign.WordCount["rt"] = 1;
            Fashion.WordCount["rt"] = 1;
            Health.WordCount["rt"] = 1;
            Music.WordCount["rt"] = 1;
            Religion.WordCount["rt"] = 1;
            foreach (var word in vocab)
            {
                if (FoodDrink.WordCount.ContainsKey(word))
                {
                    FoodDrinkWScore.Add(word, (FoodDrink.WordCount[word] + 1) / (FoodDrink.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    FoodDrinkWScore.Add(word, 0);
                }


                if (Politics.WordCount.ContainsKey(word))
                {
                    PoliticsWScore.Add(word, (Politics.WordCount[word] + 1) / (Politics.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    PoliticsWScore.Add(word, 0);
                }


                if (TvMovies.WordCount.ContainsKey(word))
                {
                    TvMoviesWScore.Add(word, (TvMovies.WordCount[word] + 1) / (TvMovies.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    TvMoviesWScore.Add(word, 0);
                }


                if (ScienceTechnology.WordCount.ContainsKey(word))
                {
                    ScienceTechnologyWScore.Add(word, (ScienceTechnology.WordCount[word] + 1) / (ScienceTechnology.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    ScienceTechnologyWScore.Add(word, 0);
                }


                if (SportsGaming.WordCount.ContainsKey(word))
                {
                    SportsGamingWScore.Add(word, (SportsGaming.WordCount[word] + 1) / (SportsGaming.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    SportsGamingWScore.Add(word, 0);
                }

                if (ArtDesign.WordCount.ContainsKey(word))
                {
                    ArtDesignWScore.Add(word, (ArtDesign.WordCount[word] + 1) / (ArtDesign.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    ArtDesignWScore.Add(word, 0);
                }

                if (Fashion.WordCount.ContainsKey(word))
                {
                    FashionWScore.Add(word, (Fashion.WordCount[word] + 1) / (Fashion.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    FashionWScore.Add(word, 0);
                }

                if (Health.WordCount.ContainsKey(word))
                {
                    HealthWScore.Add(word, (Health.WordCount[word] + 1) / (Health.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    HealthWScore.Add(word, 0);
                }

                if (Music.WordCount.ContainsKey(word))
                {
                    MusicWScore.Add(word, (Music.WordCount[word] + 1) / (Music.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    MusicWScore.Add(word, 0);
                }

                if (Religion.WordCount.ContainsKey(word))
                {
                    ReligionWScore.Add(word, (Religion.WordCount[word] + 1) / (Religion.Vocabulary.Count + vocab.Count));
                }
                else
                {
                    ReligionWScore.Add(word, 0);
                }

            }
        }
        private string CalculateScore(string [] tweetarr)
        {
            double[] Score = { score, score, score, score, score, score, score, score, score, score };
            string [] PoliticsLexicon = { "breaking","news","pti","maryum",
                                        "morality","politic","politics","political","establishment","humanity","strike",
                                        "conscience","ik",
                                        "law","lawmakers","lawmaker","republican","republic",
                                        "right","pmln","land","chinese","firms","nawaz",
                                        "justice",
                                        "fairness",
                                        "equity",
                                        "judges","judgment",
                                        "nation",
                                        "state","states","Kingdom",
                                        "government","jalsa","charged",
                                        "decree","president",
                                        "rule","court",
                                        "constitution",
                                        "monarchy",
                                        "aristocracy","power","powers","divided","fall","trust",
                                        "republic","Congress","Congress",
                                        "citizen","peace","victims",
                                        "subject",
                                        "sovereign","stronghold",
                                        "sovereignty", "workers","supporters","workers&supporters",
                                        "government","corner",
                                        "parliament","isis",
                                        "liberalism", "affiliation","mqm","mqms","pak","mqmpak","crowd",
                                        "life","istanbul","solidarity",
                                        "liberty ", "equality", "egalitarianism", "press","conferences","ns","ss","dherna",
                                        "force","defend","chaudry","judiciary","ov","maligning","panama","leaks",
                                        "violence","successful","threatens","administrative","stand","rss",
                                        "possession","martial","lieutenant","reporters","turkey",
                                        "property","convener","judicial","casualities","united",
                                        "inheritance","sindh","punjab","balochistan","qatar","general","consul",
                                        "alienable","cm","issue","census","minister","comittee","ijlas",
                                        "libertarianism","crime","raheel","shareef","presides","meeting","osama",
                                        "oppression","javed","hashmi","won","imran","khan","gen","cjp","nawaz","sharif",
                                        "totalitarianism","reyounger", "peacefulpakistanahead","bcci","crimes",
                                        "revolution",
                                        "socialism"};
            string [] FoodDrinkLexicon = { "litres", "soup", "pud", "pannettone", "smoked", "salmon", "food","toast","bacon","maple","peanut","butter","cheetos","nutella","cookies","bake","cookie","dough","fries","lobster","kfc","foodporn","caramel","cheesecake","macroni", "noodles","chocolate","parfaits","cupcake", "cupcakes","chocolates","frosting", "cream" ,"brownie","brownies","truffle","oreo","cake","yum","yummy","milkshake"};
            string [] ScienceTechnologyLexicon = {"technology" };
            string [] SportsGamingLexicon = { "vs","psl","bouncer","boom","peshawarzalmi", "zalmi","Liverpool", "Afridi", "KeepingScore","umpire", "games","manchester","2ndtest", "ovs", "edgar", "kumara", "United","amla", "duminy", "hits", "test", "ov", "overs", "over", "league", "match", "won","strikers","bowl","football","sixes","fours","strikerate","six","record","mcg","xbox","playbold","played","plays","playing","boxing","fast","bowler", "aleem", "dar", "achievements","batsman","ps4","install","ea","sports","sport","game","gaming","defeat","draw","losers","scored","score","lose","match","innings","training","allrounder","cricket","bowlers","victory"};
            string [] TvMoviesLexicon = { "watch","sherlock","share","movies","movie","stephen","currys", "walk", "remember", "brknews" };

            string [] ArtDesignLexicon = { "arts", "artwork" };
            string [] FashionLexicon = { "fashion","styles","pattern","earrings" };
            string [] HealthLexicon = {"sick", "health" , "gurantee","care","afford", "guaranteeing" ,"body"};
            string [] MusicLexicon = { "music"};
            string[] ReligionLexicon = { "islamic", "secular","god", "bless", "religions", "religion", "islam", "muslim", "muslims", "jews", "hindus" };

            string [] winner = { "FoodDrink", "Politics", "TvMovies", "ScienceTechnology", "SportsGaming" , "ArtDesign", "Fashion", "Health", "Music", "Religion" };
         
          
            double featureScore = 0.2;
           // var FoodDrinkscore = probofClass);
           // var bscore = probofClass);
            foreach (var token in tweetarr)
            {

  
                    if (FoodDrinkLexicon.Contains(token))
                    {
                        Score[0] += featureScore;
                    }

                    if (FoodDrinkWScore.ContainsKey(token))
                    { 
                            Score[0] += FoodDrinkWScore[token];
                    }

                    if(PoliticsLexicon.Contains(token))
                    {
                        Score[1] += featureScore;
                    }
                    if (PoliticsWScore.ContainsKey(token))
                    {
                        Score[1] += PoliticsWScore[token];
                    }
                
                    if (TvMoviesLexicon.Contains(token))
                    {
                        Score[2] += featureScore;
                    }
                    if (TvMoviesWScore.ContainsKey(token))
                    {
                        Score[2] += TvMoviesWScore[token];
                    }

                    if (ScienceTechnologyLexicon.Contains(token))
                    {
                        Score[3] += featureScore;
                    }
                    if (ScienceTechnologyWScore.ContainsKey(token))
                    {
                        Score[3] += ScienceTechnologyWScore[token];
                    }


                    if (SportsGamingLexicon.Contains(token))
                    {
                        
                        Score[4] += featureScore;
                    }
                    if(SportsGamingWScore.ContainsKey(token))
                    {
                        Score[4] += SportsGamingWScore[token];
                    }


                    if (ArtDesignLexicon.Contains(token))
                    {

                        Score[5] += featureScore;
                    }
                    if (ArtDesignWScore.ContainsKey(token))
                    {
                        Score[5] += ArtDesignWScore[token];
                    }

                    if (FashionLexicon.Contains(token))
                    {
                        Score[6] += featureScore;
                    }
                    if(FashionWScore.ContainsKey(token))
                    {
                        Score[6] += FashionWScore[token];
                    }

                    if (HealthLexicon.Contains(token))
                    {

                        Score[7] += featureScore;
                    }
                    if (HealthWScore.ContainsKey(token))
                    {
                        Score[7] += HealthWScore[token];
                    }


                    if (MusicLexicon.Contains(token))
                    {
                        Score[8] += featureScore;
                    }
                    if (MusicWScore.ContainsKey(token))
                    {
                        Score[8] += MusicWScore[token];
                    }
 
                    if (ReligionLexicon.Contains(token))
                    {
                        Score[9] += featureScore;
                    }
                    if (ReligionWScore.ContainsKey(token))
                    {
                        Score[9] += ReligionWScore[token];
                    }
                

            }
            double m = Score.Max();
            int p = Array.IndexOf(Score, m);
           
            Console.WriteLine("Tweet is categorized as "+winner[p]);
            Console.WriteLine();
            Console.WriteLine();
            /*  Console.WriteLine("food: "+Score[0]);
               Console.WriteLine("Politic: " + Score[1]);
               Console.WriteLine("TvMovie: " + Score[2]);
               Console.WriteLine("Technolgy: " + Score[3]);
               Console.WriteLine("sports: " + Score[4]);
               Console.WriteLine("Art & Design: " + Score[5]);
               Console.WriteLine("Fashion: " + Score[6]);
               Console.WriteLine("Health: " + Score[7]);
               Console.WriteLine("Music: " + Score[8]);
               Console.WriteLine("Religion: " + Score[9]);*/
            //Console.WriteLine(Politics.WordCount.Values.Max());
            //  Console.WriteLine(bestMove1);
            if (Score.All(o => o != Score[0]))
            {
                return "none";
            }
            return winner[p];

        }

        public static void StartProcess()
        {
            var timer = new System.Threading.Timer(
     e => Classify(),
     null,
     TimeSpan.Zero,
     TimeSpan.FromMinutes(5));
        }
        public static void Classify()
        {

            /* NaiveBayes t = new NaiveBayes();
             var tweet = "jadjusjewelry sterling silver lamp work earrings roses ivory beautiful";
             t.classifyTweet(tweet);


             tweet = "Sherlock has the faint whiff of hammy crap about it so far";
             t.classifyTweet(tweet);
             Console.ReadLine();
              */

            FileStream ostrm;
             StreamWriter writer;
             TextWriter oldOut = Console.Out;
             try
             {
                string dateAndTime = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
                dateAndTime = dateAndTime.Replace('/', '-');
                dateAndTime = dateAndTime.Replace(':', '-');
                ostrm = new FileStream("./"+ dateAndTime + "_LogFile.txt", FileMode.OpenOrCreate, FileAccess.Write);
                 writer = new StreamWriter(ostrm);
             }
             catch (Exception e)
             {
                 Console.WriteLine("Cannot open logfile.txt for writing");
                 Console.WriteLine(e.Message);
                 return;
             }
             Console.SetOut(writer);
             Task.Run(async () =>
             {
                 try
                 {
                     Trends newtrend = new Trends();
                     await newtrend.ClassifyTrends();
                 }
                 catch (Exception eee)
                 {
                     //Console.WriteLine(e.Message);
                     // Perform cleanup here.
                 }

             }).Wait();
             Console.SetOut(oldOut);
             writer.Close();
             ostrm.Close();
             Console.WriteLine("Done LogFile Generated");
             
            /*  using (StreamWriter outputFile = new StreamWriter(@"c:\WriteLines.txt"))
              {

                  outputFile.WriteLine(StringCipher.Encrypt("123", UserAccess.Admin.PassSalt));
                  Console.WriteLine();
                  Console.ReadLine();
              }*/

            // Influencer.AddInfluencerToDb("Dawn_TvNews", "Politics");
            /* List<Influencer> u=new List<Influencer>();


                     u = Influencer.GetInfluencersByCategory("Politics");




             Console.WriteLine(u[1].ScreenName);
             Console.ReadLine();*/
            /* List<Influencer> Influencers = new List<Influencer>();
             foreach(var item in Influencer.GetInfluencersByCategory("Politics"))
            Task.Run(async () =>
            {
                var userResponse =
                    await
                        (from user in TwitterContext.User
                         where user.Type == UserType.Lookup &&
                                   user.ScreenNameList == item.ScreenName
                         select user)
                            .ToListAsync();

                ;
                if (userResponse != null)
                    userResponse.ForEach(user =>
                            Influencers.Add(new Influencer()
                            {
                                
                                Category = item.Category,
                                ScreenName = user.Name
                            })
                    );
            }).Wait();
            foreach (var VARIABLE in Influencers)
            {
                Console.WriteLine(VARIABLE.ScreenName);
            }
            Console.ReadLine();*/
        }
      //  static readonly SingleUserAuthorizer Authorizer = TwitterDeveloper.authorizeTwitter();
      //  static readonly TwitterContext TwitterContext = new TwitterContext(Authorizer);
        private string classifyTweet(string tweet)
        {
            try
            {
                Console.WriteLine("Classifying \"" + tweet + "\"");
                if (!String.IsNullOrWhiteSpace(tweet))
                {
                    // var tweet = "jadjusjewelry sterling silver lamp work earrings roses ivory beautiful";
                    tweet = TextCleaner.cleanText(tweet);
                    string[] tweetarr = TrainingData.SplitWords(tweet);
                    Dictionary<string, string> arr = new Dictionary<string, string>();
                    foreach (var wd in tweetarr)
                    {
                        arr.Add(wd, wd);
                    }
                    return CalculateScore(arr.Keys.ToArray());
                }
                else
                {
                    throw new System.ArgumentException("Parameters cannot be null");
                }
            }
            catch
            {
                return "none";
            }

        }
        public string ClassifyTrend(string trend, List<string> temptweet)
        {
            string x = "";
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("********************  Classifying Trend \""+trend+ "\" Wait  ********************");
            Console.WriteLine(); Console.WriteLine();
            string[] winner = { "FoodDrink", "Politics", "TvMovies", "ScienceTechnology", "SportsGaming", "ArtDesign", "Fashion", "Health", "Music", "Religion" };
            int[] score = {0,0,0,0,0,0,0,0,0,0};
            foreach (var tweet in temptweet)
            {
                
                try
                {
                    x = classifyTweet(tweet);
                }
                catch
                {
                    Console.WriteLine("Classification skipped due to use of invalid characters");
                    continue;
                }
                if (x == "none")
                {
                    Console.WriteLine("Classification skipped due to use of invalid characters");
                    continue;
                }
                else
                {
                    var index = Array.IndexOf(winner, x);
                    score[index] += 1;
                }
            }
            int m = score.Max();
            int p = Array.IndexOf(score, m);
            if (score.All(o => o != score[0]))
            {
                Console.WriteLine(trend + " is categorized as other");
                Console.WriteLine();
                Console.WriteLine("####################################################################");
                Console.WriteLine("####################################################################");
                Console.WriteLine();
                return "other";
            }
            else
            {
                Console.WriteLine(trend + " is categorized as " + winner[p]);
                Console.WriteLine();
                Console.WriteLine("####################################################################");
                Console.WriteLine("####################################################################");
                Console.WriteLine();
                return winner[p];
            }
          
            

        }
    }
    }
  
/* for Categories
         static void Main(string[] args)
         {

             var Category = new Category();
             // Catching exceptions for async tasks
            Task.Run(async () =>
             {
                 try
                 {
                     // Start the task.
                      await Category.InsertCategory("TV & Movies");

                     // Await the task.

                 }
                 catch (Exception e)
                 {
                     Console.WriteLine(e.Message);
                     // Perform cleanup here.
                 }

             }).Wait();

             var getListTask = Category.GetAllCategories(); // returns the Task<List<TvChannel>>

             Task.WaitAll(getListTask); // block while the task completes

             var list = getListTask.Result;
            // Console.WriteLine(list);


             foreach (var document in list)
             {
                 Console.WriteLine(document);
             }


             //  DataRetrieval d = new DataRetrieval();
             //  d.proc();
             //  Console.ReadLine();
             // String myString;
             // Console.WriteLine("Enter a string having '&' or '\"'  in it, ");
             // myString = Console.ReadLine();
             // myString = "I luv my &lt;3 iphone &amp; @ @umar you’re awsm apple. DisplayIsAwesome, sooo happppppy 🙂 http://www.apple.com”";
             // Console.WriteLine(myString);
             //MessageBox.Show(myString);
             //String myEncodedString = TextCleaner.cleanText(myString);
             // Console.WriteLine("\n\n" + myEncodedString);
             // MessageBox.Show(myEncodedString);
             Console.ReadLine();
         }*/


/* TrainingData c = new TrainingData("FoodDrink");

          foreach (var s in c.WordCount.Keys)
         {
              Console.WriteLine(s+": "+c.WordCount[s]); 
         }

        Console.WriteLine("Vocabulary: " + c.Vocabulary.Count.ToString());
        Console.ReadLine(); */



// FOR ENTERING CLEAN TWEETS TO DATABASE
/* Tweets t = new Tweets();
  Task.Run(async () =>
  {
      try
      {
          // Start the task.
          await t.StoreCleanedTweetsOfCategory("ReligionTweets", "ReligionCTweets");

          // Await the task.

      }
      catch (Exception e)
      {
          Console.WriteLine(e.Message);
          // Perform cleanup here.
      }

  }).Wait();
  Console.WriteLine();
*/



//   KeyValuePair<string, double> bestMove1 = Politics.WordCount.First();
//  foreach (KeyValuePair<string, double> move in Politics.WordCount)
//  {
//       if (move.Value > bestMove1.Value) bestMove1 = move;
//   }
//For Getiting Top N Words WRT Count
/*  var sortedDict = (from entry in SportsGaming.WordCount orderby entry.Value descending select entry)
            .Take(10)
            .ToDictionary(pair => pair.Key, pair => pair.Value);

   foreach (var w in sortedDict)
   {
       Console.WriteLine(w);
   }*/
