using MongoDB.Bson;
using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBHandler;

namespace TextClassification
{
    public class Category
    {
        string name;
        static HashSet<string> categories = new HashSet<string>();
        public static string[] categorylist = { "Politics", "TvMovies", "ScienceTechnlogy", "SportsGaming", "ArtDesign", "Fashion", "Health", "Music", "Religion" };
        public static HashSet<string> Categories
        {
            get
            {
                return categories;
            }

            set
            {
                //SetAllCategories();
                categories = value;
            }
        }

        public async Task InsertCategory(string category)
        {   if (!String.IsNullOrWhiteSpace(category))
            {
                var collection = DBConnector.Database.GetCollection<BsonDocument>("Categories");
                var keys = Builders<BsonDocument>.IndexKeys.Ascending("name");
                var options = new CreateIndexOptions();
                options.Unique = true;
                await collection.Indexes.CreateOneAsync(keys, options);
                var document = new BsonDocument
            {
                { "name", category }
            };

                await collection.InsertOneAsync(document);
            }
        else
            {
                throw new System.ArgumentException("Parameter cannot be null", "category");
            }
        }
        public static async Task<HashSet<string>> GetAllCategories()
        {
            Categories.Clear();
            categories = new HashSet<string>();
            var collection = DBConnector.Database.GetCollection<BsonDocument>("Categories");
            //var filter = new BsonDocument();

           // var sort = Builders<BsonDocument>.Sort.Ascending("name");
            //var result = await collection.Find(filter).ToListAsync();
            var list = await collection.Find(new BsonDocument()).Project(Builders<BsonDocument>.Projection.Include("name").Exclude("_id")).ToListAsync();
            //
            /*using (var cursor = await collection.FindAsync(filter))
              {

                  while (await cursor.MoveNextAsync())
                  {
                      var batch = cursor.Current;
                      foreach (var document in batch)
                      {
                          Console.WriteLine(document[1]);
                      }
                  }
;
              }*/
            foreach (var document in list)
            {
                categories.Add(Convert.ToString(document[0]));
            }
            return Categories;
        }
        
    }
}
