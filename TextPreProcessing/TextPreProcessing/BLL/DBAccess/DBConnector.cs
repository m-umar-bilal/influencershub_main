using MongoDB.Driver;


namespace DBHandler
{
    class DBConnector
    {
        private static IMongoClient client = new MongoClient();
        private static IMongoDatabase database = Client.GetDatabase("InfluencersHub");

        private static IMongoClient Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }

        public static IMongoDatabase Database
        {
            get
            {
                return database;
            }

            set
            {
                database = value;
            }
        }
    }
}
