namespace Take.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public Uri? Uri { get; set; }

        public IEnumerable<string> Genres { get; set; } = null!;
    }
}
