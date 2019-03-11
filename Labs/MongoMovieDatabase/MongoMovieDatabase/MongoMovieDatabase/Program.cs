using System;
using System.Linq;

namespace MongoMovieDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            var movieRepository = new MovieRepository(@"mongodb://capehart:oitcst324@ds259305.mlab.com:59305/oitcst324");

            var movies = movieRepository.GetAllMovies();

            var one = movies.Where(m => m.Country != null && m.Country.Equals("Canada")).Count();

            var two = movies.Where(m => m.ImdbScore > 9).Count();

            var three = movies.Where(movie =>
            movie.Actor1Name != null && movie.Actor1Name.Equals("Natalie Portman") ||
            movie.Actor2Name != null && movie.Actor2Name.Equals("Natalie Portman") ||
            movie.Actor3Name != null && movie.Actor3Name.Equals("Natalie Portman")).Count();

            var four = movies.Where(movie =>
            movie.Actor1Name != null && movie.Actor1Name.Equals("Clint Eastwood") ||
            movie.Actor2Name != null && movie.Actor2Name.Equals("Clint Eastwood") ||
            movie.Actor3Name != null && movie.Actor3Name.Equals("Clint Eastwood") ||
            movie.DirectorName != null && movie.DirectorName.Equals("Clint Eastwood")).Count();

            var five = movies.Where(movie => movie.Genres != null && movie.Genres.Contains("Drama")).Count();

            Console.WriteLine(one);
            Console.WriteLine(two);
            Console.WriteLine(three);
            Console.WriteLine(four);
            Console.WriteLine(five);
            
            Console.ReadKey();
        }
    }
}
