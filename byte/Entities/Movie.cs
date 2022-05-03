namespace Take.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Uri? Uri { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Rate> Rates { get; set; }

        private Movie()
        {
            Name = null!;
            Rates = null!;
            Genres = null!;
        }

        public Movie(string name)
        {
            Name = name;
            Rates = new List<Rate>();
            Genres = new List<Genre>();
        }
    }
}
