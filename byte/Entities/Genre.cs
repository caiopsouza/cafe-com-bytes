namespace Take.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

        private Genre()
        {
            Name = null!;
            Movies = null!;
        }

        public Genre(string name)
        {
            Name = name;
            Movies = new List<Movie>();
        }
    }
}
