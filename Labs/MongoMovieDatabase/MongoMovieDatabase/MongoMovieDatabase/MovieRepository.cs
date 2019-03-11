using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoMovieDatabase
{
    public class MovieRepository
    {
        private readonly IMongoCollection<Movie> _movieRepository;

        public MovieRepository(string connectionString)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("oitcst324");
            _movieRepository = database.GetCollection<Movie>("movies");
        }

        public IList<Movie> GetAllMovies() => _movieRepository.Find(new BsonDocument()).ToList();
        
    }
}
