using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoMovieDatabase
{
    public class Movie
    {
        [BsonId]
        public BsonObjectId Id { get; set; }

        [BsonElement("color")]
        public string Color { get; set; }

        [BsonElement("director_name")]
        public string DirectorName { get; set; }

        [BsonElement("num_critic_for_reviews")]
        public int? NumCriticsForReviews { get; set; }

        [BsonElement("duration")]
        public double? DurationInMinutes { get; set; }

        [BsonElement("director_facebook_likes")]
        public int? DirectorFacebookLikes { get; set; }

        [BsonElement("actor_3_facebook_likes")]
        public int? Actor3FacebookLikes { get; set; }

        [BsonElement("actor_2_name")]
        public string Actor2Name { get; set; }

        [BsonElement("actor_1_facebook_likes")]
        public int? Actor1FacebookLikes { get; set; }

        [BsonElement("gross")]
        public decimal? Gross { get; set; }

        [BsonElement("genres")]
        public string Genres { get; set; }

        [BsonElement("actor_1_name")]
        public string Actor1Name { get; set; }

        [BsonElement("movie_title")]
        public string MovieTitle { get; set; }

        [BsonElement("num_voted_users")]
        public int? NumVotedUsers { get; set; }

        [BsonElement("cast_total_facebook_likes")]
        public int? CastTotalFacebookLikes { get; set; }

        [BsonElement("actor_3_name")]
        public string Actor3Name { get; set; }

        [BsonElement("facenumber_in_poster")]
        public int? FaceumberInPoster { get; set; }

        [BsonElement("plot_keywords")]
        public string PlotKeywords { get; set; }

        [BsonElement("movie_imdb_link")]
        public string MovieImdbLink { get; set; }

        [BsonElement("num_user_for_reviews")]
        public int? NumUserForReviews { get; set; }

        [BsonElement("language")]
        public string Language { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("content_rating")]
        public string ContentRating { get; set; }

        [BsonElement("budget")]
        public decimal? Budget { get; set; }

        [BsonElement("title_year")]
        public int? TitleYear { get; set; }

        [BsonElement("actor_2_facebook_likes")]
        public int? Actor2FacebookLikes { get; set; }

        [BsonElement("imdb_score")]
        public double? ImdbScore { get; set; }

        [BsonElement("aspect_ratio")]
        public double? AspectRatio { get; set; }

        [BsonElement("movie_facebook_likes")]
        public int? MovieFacebookLikes { get; set; }

    }
}
