namespace Take.Entities
{
    public class Rate
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public Stars Stars { get; set; }

        public DateTime Date { get; set; }

        private Rate()
        {
            User = null!;
            Movie = null!;
        }

        public Rate(User user, Movie movie, Stars stars, DateTime date)
        {
            User = user;
            Movie = movie;
            Stars = stars;
            Date = date;
        }
    }
}
